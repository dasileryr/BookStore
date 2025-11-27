-- Скрипт создания базы данных "Книжный магазин"
-- Для выполнения в SQL Server Management Studio (SSMS)

-- =============================================
-- 1. Создание базы данных
-- =============================================
USE master;
GO

-- ВАЖНО: Если база данных spanish_league уже существует и содержит другие таблицы,
-- скрипт создаст только необходимые таблицы для приложения "Книжный магазин"
-- Если база данных не существует, раскомментируйте следующие строки:

-- IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'spanish_league')
-- BEGIN
--     CREATE DATABASE spanish_league;
-- END
-- GO

-- Используем существующую базу данных
USE spanish_league;
GO

-- =============================================
-- 2. Создание таблиц
-- =============================================

-- Таблица: Books (Книги)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Books]') AND type in (N'U'))
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
    );
    PRINT 'Таблица Books создана успешно';
END
ELSE
BEGIN
    PRINT 'Таблица Books уже существует';
END
GO

-- Таблица: Sales (Продажи)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sales]') AND type in (N'U'))
BEGIN
    CREATE TABLE Sales (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        BookId INT NOT NULL,
        Quantity INT NOT NULL,
        Price DECIMAL(18,2) NOT NULL,
        SaleDate DATETIME NOT NULL,
        CustomerName NVARCHAR(200) NULL,
        FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
    );
    PRINT 'Таблица Sales создана успешно';
END
ELSE
BEGIN
    PRINT 'Таблица Sales уже существует';
END
GO

-- Таблица: WriteOffs (Списания)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WriteOffs]') AND type in (N'U'))
BEGIN
    CREATE TABLE WriteOffs (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        BookId INT NOT NULL,
        Quantity INT NOT NULL,
        WriteOffDate DATETIME NOT NULL,
        Reason NVARCHAR(500) NOT NULL,
        FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
    );
    PRINT 'Таблица WriteOffs создана успешно';
END
ELSE
BEGIN
    PRINT 'Таблица WriteOffs уже существует';
END
GO

-- Таблица: Reservations (Резервирования)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservations]') AND type in (N'U'))
BEGIN
    CREATE TABLE Reservations (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        BookId INT NOT NULL,
        CustomerName NVARCHAR(200) NOT NULL,
        CustomerPhone NVARCHAR(50) NOT NULL,
        ReservationDate DATETIME NOT NULL,
        ExpiryDate DATETIME NULL,
        IsCompleted BIT NOT NULL DEFAULT 0,
        FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
    );
    PRINT 'Таблица Reservations создана успешно';
END
ELSE
BEGIN
    PRINT 'Таблица Reservations уже существует';
END
GO

-- Таблица: Users (Пользователи)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Login NVARCHAR(100) NOT NULL UNIQUE,
        Password NVARCHAR(200) NOT NULL,
        FullName NVARCHAR(200) NOT NULL,
        Role NVARCHAR(50) NOT NULL DEFAULT 'User'
    );
    PRINT 'Таблица Users создана успешно';
END
ELSE
BEGIN
    PRINT 'Таблица Users уже существует';
END
GO

-- =============================================
-- 3. Создание внешнего ключа для ContinuationOfBookId
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Books_ContinuationOfBookId')
BEGIN
    ALTER TABLE Books 
    ADD CONSTRAINT FK_Books_ContinuationOfBookId 
    FOREIGN KEY (ContinuationOfBookId) REFERENCES Books(Id);
    PRINT 'Внешний ключ FK_Books_ContinuationOfBookId создан успешно';
END
ELSE
BEGIN
    PRINT 'Внешний ключ FK_Books_ContinuationOfBookId уже существует';
END
GO

-- =============================================
-- 4. Создание пользователя по умолчанию
-- =============================================
IF NOT EXISTS (SELECT * FROM Users WHERE Login = 'admin')
BEGIN
    INSERT INTO Users (Login, Password, FullName, Role)
    VALUES ('admin', 'admin', N'Администратор', 'Admin');
    PRINT 'Пользователь admin создан успешно';
END
ELSE
BEGIN
    PRINT 'Пользователь admin уже существует';
END
GO

-- =============================================
-- 5. Создание индексов для улучшения производительности (опционально)
-- =============================================

-- Индекс для поиска по названию книги
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Books_Title')
BEGIN
    CREATE INDEX IX_Books_Title ON Books(Title);
    PRINT 'Индекс IX_Books_Title создан успешно';
END
GO

-- Индекс для поиска по автору
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Books_Author')
BEGIN
    CREATE INDEX IX_Books_Author ON Books(AuthorFullName);
    PRINT 'Индекс IX_Books_Author создан успешно';
END
GO

-- Индекс для поиска по жанру
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Books_Genre')
BEGIN
    CREATE INDEX IX_Books_Genre ON Books(Genre);
    PRINT 'Индекс IX_Books_Genre создан успешно';
END
GO

-- Индекс для поиска продаж по дате
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Sales_SaleDate')
BEGIN
    CREATE INDEX IX_Sales_SaleDate ON Sales(SaleDate);
    PRINT 'Индекс IX_Sales_SaleDate создан успешно';
END
GO

-- =============================================
-- Готово!
-- =============================================
PRINT '========================================';
PRINT 'База данных успешно создана!';
PRINT 'Логин: admin';
PRINT 'Пароль: admin';
PRINT '========================================';
GO

