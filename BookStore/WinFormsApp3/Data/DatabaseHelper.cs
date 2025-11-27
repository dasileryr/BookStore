using System.Data;
using System.Data.SqlClient;
using WinFormsApp3.Models;

namespace WinFormsApp3.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            // Вариант 1: LocalDB (локальная база данных, создается автоматически)
            // _connectionString = @"Server=(localdb)\mssqllocaldb;Database=BookStore;Integrated Security=true;TrustServerCertificate=true;";
            
            // Вариант 2: Подключение к существующему SQL Server (видимому в SSMS)
            // Замените на ваши параметры:
            // - Server: имя сервера (например, "localhost" или "localhost\SQLEXPRESS" для Express)
            // - Database: имя базы данных (если база уже существует) или оставьте пустым для создания
            // - Integrated Security: true для Windows-аутентификации, false для SQL-аутентификации
            // - User ID и Password: если используете SQL-аутентификацию
            
            // Пример для SQL Server Express с Windows-аутентификацией:
            _connectionString = @"Server=DESKTOP-K3OP1CJ;Database=spanish_league;Trusted_Connection=True;";
            
            // Пример для SQL Server с SQL-аутентификацией (раскомментируйте и укажите свои данные):
            // _connectionString = @"Server=localhost\SQLEXPRESS;Database=BookStore;User ID=sa;Password=ваш_пароль;TrustServerCertificate=true;";
            
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                CreateTables(connection);
                CreateDefaultUser(connection);
            }
            catch (SqlException ex) when (ex.Number == 4060) // Database doesn't exist
            {
                // База данных не существует
                // В этом случае нужно создать базу данных вручную через SSMS, используя скрипт CreateBookStoreDatabase.sql
                throw new Exception($"База данных не найдена. Пожалуйста, создайте базу данных в SSMS, используя скрипт CreateBookStoreDatabase.sql. Ошибка: {ex.Message}");
            }
        }

        private void CreateTables(SqlConnection connection)
        {
            var commands = new[]
            {
                @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Books]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE Books (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Title NVARCHAR(500) NOT NULL,
                        AuthorFullName NVARCHAR(200) NOT NULL,
                        Publisher NVARCHAR(200) NOT NULL,
                        PageCount INT NOT NULL,
                        Genre NVARCHAR(100) NOT NULL,
                        PublicationYear INT NOT NULL,
                        CostPrice DECIMAL(18,2) NOT NULL,
                        SalePrice DECIMAL(18,2) NOT NULL,
                        ContinuationOfBookId INT NULL,
                        Quantity INT NOT NULL DEFAULT 0,
                        IsOnSale BIT NOT NULL DEFAULT 0,
                        SaleDiscount DECIMAL(5,2) NULL
                    )
                END",
                @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sales]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE Sales (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        BookId INT NOT NULL,
                        Quantity INT NOT NULL,
                        Price DECIMAL(18,2) NOT NULL,
                        SaleDate DATETIME NOT NULL,
                        CustomerName NVARCHAR(200) NULL,
                        FOREIGN KEY (BookId) REFERENCES Books(Id)
                    )
                END",
                @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WriteOffs]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE WriteOffs (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        BookId INT NOT NULL,
                        Quantity INT NOT NULL,
                        WriteOffDate DATETIME NOT NULL,
                        Reason NVARCHAR(500) NOT NULL,
                        FOREIGN KEY (BookId) REFERENCES Books(Id)
                    )
                END",
                @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE Reservations (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        BookId INT NOT NULL,
                        CustomerName NVARCHAR(200) NOT NULL,
                        CustomerPhone NVARCHAR(50) NOT NULL,
                        ReservationDate DATETIME NOT NULL,
                        ExpiryDate DATETIME NULL,
                        IsCompleted BIT NOT NULL DEFAULT 0,
                        FOREIGN KEY (BookId) REFERENCES Books(Id)
                    )
                END",
                @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE Users (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Login NVARCHAR(100) NOT NULL UNIQUE,
                        Password NVARCHAR(200) NOT NULL,
                        FullName NVARCHAR(200) NOT NULL,
                        Role NVARCHAR(50) NOT NULL DEFAULT 'User'
                    )
                END"
            };

            foreach (var cmdText in commands)
            {
                try
                {
                    using var command = new SqlCommand(cmdText, connection);
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    // Игнорируем ошибки создания таблиц
                }
            }

            // Добавляем внешний ключ для ContinuationOfBookId после создания таблицы Books
            try
            {
                using var fkCommand = new SqlCommand(
                    @"IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Books_ContinuationOfBookId')
                    BEGIN
                        ALTER TABLE Books ADD CONSTRAINT FK_Books_ContinuationOfBookId 
                        FOREIGN KEY (ContinuationOfBookId) REFERENCES Books(Id)
                    END",
                    connection);
                fkCommand.ExecuteNonQuery();
            }
            catch
            {
                // Игнорируем ошибки
            }
        }

        private void CreateDefaultUser(SqlConnection connection)
        {
            try
            {
                using var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Login = 'admin'", connection);
                var count = (int)checkCommand.ExecuteScalar();
                if (count == 0)
                {
                    using var insertCommand = new SqlCommand(
                        "INSERT INTO Users (Login, Password, FullName, Role) VALUES (@login, @password, @fullName, @role)",
                        connection);
                    insertCommand.Parameters.AddWithValue("@login", "admin");
                    insertCommand.Parameters.AddWithValue("@password", "admin"); // В реальном приложении нужно хешировать
                    insertCommand.Parameters.AddWithValue("@fullName", "Администратор");
                    insertCommand.Parameters.AddWithValue("@role", "Admin");
                    insertCommand.ExecuteNonQuery();
                }
            }
            catch
            {
                // Игнорируем ошибки при создании пользователя
            }
        }

        // Методы для работы с книгами
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Books", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                books.Add(MapBook(reader));
            }
            return books;
        }

        public Book? GetBookById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Books WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return MapBook(reader);
            }
            return null;
        }

        public void AddBook(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                @"INSERT INTO Books (Title, AuthorFullName, Publisher, PageCount, Genre, PublicationYear, 
                  CostPrice, SalePrice, ContinuationOfBookId, Quantity, IsOnSale, SaleDiscount)
                  VALUES (@title, @author, @publisher, @pageCount, @genre, @year, @costPrice, @salePrice, 
                  @continuationId, @quantity, @isOnSale, @discount)",
                connection);
            AddBookParameters(command, book);
            command.ExecuteNonQuery();
        }

        public void UpdateBook(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                @"UPDATE Books SET Title = @title, AuthorFullName = @author, Publisher = @publisher, 
                  PageCount = @pageCount, Genre = @genre, PublicationYear = @year, CostPrice = @costPrice, 
                  SalePrice = @salePrice, ContinuationOfBookId = @continuationId, Quantity = @quantity, 
                  IsOnSale = @isOnSale, SaleDiscount = @discount WHERE Id = @id",
                connection);
            command.Parameters.AddWithValue("@id", book.Id);
            AddBookParameters(command, book);
            command.ExecuteNonQuery();
        }

        public void DeleteBook(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("DELETE FROM Books WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        private void AddBookParameters(SqlCommand command, Book book)
        {
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@author", book.AuthorFullName);
            command.Parameters.AddWithValue("@publisher", book.Publisher);
            command.Parameters.AddWithValue("@pageCount", book.PageCount);
            command.Parameters.AddWithValue("@genre", book.Genre);
            command.Parameters.AddWithValue("@year", book.PublicationYear);
            command.Parameters.AddWithValue("@costPrice", book.CostPrice);
            command.Parameters.AddWithValue("@salePrice", book.SalePrice);
            command.Parameters.AddWithValue("@continuationId", (object?)book.ContinuationOfBookId ?? DBNull.Value);
            command.Parameters.AddWithValue("@quantity", book.Quantity);
            command.Parameters.AddWithValue("@isOnSale", book.IsOnSale);
            command.Parameters.AddWithValue("@discount", (object?)book.SaleDiscount ?? DBNull.Value);
        }

        private Book MapBook(SqlDataReader reader)
        {
            var continuationIndex = reader.GetOrdinal("ContinuationOfBookId");
            var discountIndex = reader.GetOrdinal("SaleDiscount");
            
            return new Book
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                AuthorFullName = reader.GetString(reader.GetOrdinal("AuthorFullName")),
                Publisher = reader.GetString(reader.GetOrdinal("Publisher")),
                PageCount = reader.GetInt32(reader.GetOrdinal("PageCount")),
                Genre = reader.GetString(reader.GetOrdinal("Genre")),
                PublicationYear = reader.GetInt32(reader.GetOrdinal("PublicationYear")),
                CostPrice = reader.GetDecimal(reader.GetOrdinal("CostPrice")),
                SalePrice = reader.GetDecimal(reader.GetOrdinal("SalePrice")),
                ContinuationOfBookId = reader.IsDBNull(continuationIndex) ? null : reader.GetInt32(continuationIndex),
                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                IsOnSale = reader.GetBoolean(reader.GetOrdinal("IsOnSale")),
                SaleDiscount = reader.IsDBNull(discountIndex) ? null : reader.GetDecimal(discountIndex)
            };
        }

        // Методы для поиска
        public List<Book> SearchBooksByTitle(string title)
        {
            return SearchBooks("Title LIKE @search", "@search", $"%{title}%");
        }

        public List<Book> SearchBooksByAuthor(string author)
        {
            return SearchBooks("AuthorFullName LIKE @search", "@search", $"%{author}%");
        }

        public List<Book> SearchBooksByGenre(string genre)
        {
            return SearchBooks("Genre LIKE @search", "@search", $"%{genre}%");
        }

        private List<Book> SearchBooks(string whereClause, string paramName, string paramValue)
        {
            var books = new List<Book>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand($"SELECT * FROM Books WHERE {whereClause}", connection);
            command.Parameters.AddWithValue(paramName, paramValue);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                books.Add(MapBook(reader));
            }
            return books;
        }

        // Методы для продаж
        public void AddSale(Sale sale)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                // Добавляем продажу
                using var saleCommand = new SqlCommand(
                    "INSERT INTO Sales (BookId, Quantity, Price, SaleDate, CustomerName) VALUES (@bookId, @quantity, @price, @date, @customer)",
                    connection, transaction);
                saleCommand.Parameters.AddWithValue("@bookId", sale.BookId);
                saleCommand.Parameters.AddWithValue("@quantity", sale.Quantity);
                saleCommand.Parameters.AddWithValue("@price", sale.Price);
                saleCommand.Parameters.AddWithValue("@date", sale.SaleDate);
                saleCommand.Parameters.AddWithValue("@customer", (object?)sale.CustomerName ?? DBNull.Value);
                saleCommand.ExecuteNonQuery();

                // Уменьшаем количество книг
                using var updateCommand = new SqlCommand(
                    "UPDATE Books SET Quantity = Quantity - @quantity WHERE Id = @bookId",
                    connection, transaction);
                updateCommand.Parameters.AddWithValue("@quantity", sale.Quantity);
                updateCommand.Parameters.AddWithValue("@bookId", sale.BookId);
                updateCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // Методы для списания
        public void AddWriteOff(WriteOff writeOff)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                using var writeOffCommand = new SqlCommand(
                    "INSERT INTO WriteOffs (BookId, Quantity, WriteOffDate, Reason) VALUES (@bookId, @quantity, @date, @reason)",
                    connection, transaction);
                writeOffCommand.Parameters.AddWithValue("@bookId", writeOff.BookId);
                writeOffCommand.Parameters.AddWithValue("@quantity", writeOff.Quantity);
                writeOffCommand.Parameters.AddWithValue("@date", writeOff.WriteOffDate);
                writeOffCommand.Parameters.AddWithValue("@reason", writeOff.Reason);
                writeOffCommand.ExecuteNonQuery();

                using var updateCommand = new SqlCommand(
                    "UPDATE Books SET Quantity = Quantity - @quantity WHERE Id = @bookId",
                    connection, transaction);
                updateCommand.Parameters.AddWithValue("@quantity", writeOff.Quantity);
                updateCommand.Parameters.AddWithValue("@bookId", writeOff.BookId);
                updateCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // Методы для резервирования
        public void AddReservation(Reservation reservation)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                "INSERT INTO Reservations (BookId, CustomerName, CustomerPhone, ReservationDate, ExpiryDate, IsCompleted) VALUES (@bookId, @name, @phone, @date, @expiry, @completed)",
                connection);
            command.Parameters.AddWithValue("@bookId", reservation.BookId);
            command.Parameters.AddWithValue("@name", reservation.CustomerName);
            command.Parameters.AddWithValue("@phone", reservation.CustomerPhone);
            command.Parameters.AddWithValue("@date", reservation.ReservationDate);
            command.Parameters.AddWithValue("@expiry", (object?)reservation.ExpiryDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@completed", reservation.IsCompleted);
            command.ExecuteNonQuery();
        }

        public List<Reservation> GetActiveReservations()
        {
            var reservations = new List<Reservation>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Reservations WHERE IsCompleted = 0", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                reservations.Add(new Reservation
                {
                    Id = reader.GetInt32("Id"),
                    BookId = reader.GetInt32("BookId"),
                    CustomerName = reader.GetString("CustomerName"),
                    CustomerPhone = reader.GetString("CustomerPhone"),
                    ReservationDate = reader.GetDateTime("ReservationDate"),
                    ExpiryDate = reader.IsDBNull("ExpiryDate") ? null : reader.GetDateTime("ExpiryDate"),
                    IsCompleted = reader.GetBoolean("IsCompleted")
                });
            }
            return reservations;
        }

        // Методы для акций
        public void SetBookOnSale(int bookId, decimal discount)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                "UPDATE Books SET IsOnSale = 1, SaleDiscount = @discount WHERE Id = @id",
                connection);
            command.Parameters.AddWithValue("@id", bookId);
            command.Parameters.AddWithValue("@discount", discount);
            command.ExecuteNonQuery();
        }

        public void RemoveBookFromSale(int bookId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                "UPDATE Books SET IsOnSale = 0, SaleDiscount = NULL WHERE Id = @id",
                connection);
            command.Parameters.AddWithValue("@id", bookId);
            command.ExecuteNonQuery();
        }

        // Методы для статистики
        public List<Book> GetNewBooks(int year)
        {
            var books = new List<Book>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Books WHERE PublicationYear = @year ORDER BY PublicationYear DESC", connection);
            command.Parameters.AddWithValue("@year", year);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                books.Add(MapBook(reader));
            }
            return books;
        }

        public List<(Book Book, int TotalSold)> GetBestSellingBooks(DateTime startDate, DateTime endDate)
        {
            var results = new List<(Book, int)>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                @"SELECT b.Id, b.Title, b.AuthorFullName, b.Publisher, b.PageCount, b.Genre, 
                           b.PublicationYear, b.CostPrice, b.SalePrice, b.ContinuationOfBookId, 
                           b.Quantity, b.IsOnSale, b.SaleDiscount, SUM(s.Quantity) as TotalSold 
                  FROM Books b
                  INNER JOIN Sales s ON b.Id = s.BookId
                  WHERE s.SaleDate BETWEEN @startDate AND @endDate
                  GROUP BY b.Id, b.Title, b.AuthorFullName, b.Publisher, b.PageCount, b.Genre, 
                           b.PublicationYear, b.CostPrice, b.SalePrice, b.ContinuationOfBookId, 
                           b.Quantity, b.IsOnSale, b.SaleDiscount
                  ORDER BY TotalSold DESC",
                connection);
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@endDate", endDate);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var book = MapBook(reader);
                var totalSold = reader.GetInt32(reader.GetOrdinal("TotalSold"));
                results.Add((book, totalSold));
            }
            return results;
        }

        public List<(string Author, int TotalSold)> GetPopularAuthors(DateTime startDate, DateTime endDate)
        {
            var results = new List<(string, int)>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                @"SELECT b.AuthorFullName, SUM(s.Quantity) as TotalSold 
                  FROM Books b
                  INNER JOIN Sales s ON b.Id = s.BookId
                  WHERE s.SaleDate BETWEEN @startDate AND @endDate
                  GROUP BY b.AuthorFullName
                  ORDER BY TotalSold DESC",
                connection);
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@endDate", endDate);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add((reader.GetString("AuthorFullName"), reader.GetInt32("TotalSold")));
            }
            return results;
        }

        public List<(string Genre, int TotalSold)> GetPopularGenres(DateTime startDate, DateTime endDate)
        {
            var results = new List<(string, int)>();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand(
                @"SELECT b.Genre, SUM(s.Quantity) as TotalSold 
                  FROM Books b
                  INNER JOIN Sales s ON b.Id = s.BookId
                  WHERE s.SaleDate BETWEEN @startDate AND @endDate
                  GROUP BY b.Genre
                  ORDER BY TotalSold DESC",
                connection);
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@endDate", endDate);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add((reader.GetString("Genre"), reader.GetInt32("TotalSold")));
            }
            return results;
        }

        // Методы для авторизации
        public User? AuthenticateUser(string login, string password)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Users WHERE Login = @login AND Password = @password", connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32("Id"),
                    Login = reader.GetString("Login"),
                    Password = reader.GetString("Password"),
                    FullName = reader.GetString("FullName"),
                    Role = reader.GetString("Role")
                };
            }
            return null;
        }
    }
}

