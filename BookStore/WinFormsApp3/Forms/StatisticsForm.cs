using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class StatisticsForm : Form
    {
        private DatabaseHelper _dbHelper;

        public StatisticsForm(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            LoadNewBooks();
            LoadBestSelling();
            LoadPopularAuthors();
            LoadPopularGenres();
        }

        private void LoadNewBooks()
        {
            int currentYear = DateTime.Now.Year;
            var newBooks = _dbHelper.GetNewBooks(currentYear);
            dgvNewBooks.DataSource = newBooks;
            dgvNewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadBestSelling()
        {
            DateTime startDate = GetStartDate();
            DateTime endDate = DateTime.Now;
            var bestSelling = _dbHelper.GetBestSellingBooks(startDate, endDate);
            
            var displayData = bestSelling.Select(bs => new
            {
                Книга = bs.Book.Title,
                Автор = bs.Book.AuthorFullName,
                Продано = bs.TotalSold
            }).ToList();

            dgvBestSelling.DataSource = displayData;
            dgvBestSelling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadPopularAuthors()
        {
            DateTime startDate = GetStartDate();
            DateTime endDate = DateTime.Now;
            var authors = _dbHelper.GetPopularAuthors(startDate, endDate);
            
            var displayData = authors.Select(a => new
            {
                Автор = a.Author,
                Продано = a.TotalSold
            }).ToList();

            dgvPopularAuthors.DataSource = displayData;
            dgvPopularAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadPopularGenres()
        {
            DateTime startDate = GetStartDate();
            DateTime endDate = DateTime.Now;
            var genres = _dbHelper.GetPopularGenres(startDate, endDate);
            
            var displayData = genres.Select(g => new
            {
                Жанр = g.Genre,
                Продано = g.TotalSold
            }).ToList();

            dgvPopularGenres.DataSource = displayData;
            dgvPopularGenres.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DateTime GetStartDate()
        {
            if (rbDay.Checked)
                return DateTime.Now.Date;
            else if (rbWeek.Checked)
                return DateTime.Now.AddDays(-7);
            else if (rbMonth.Checked)
                return DateTime.Now.AddMonths(-1);
            else if (rbYear.Checked)
                return DateTime.Now.AddYears(-1);
            else
                return DateTime.Now.Date;
        }

        private void PeriodChanged(object sender, EventArgs e)
        {
            LoadBestSelling();
            LoadPopularAuthors();
            LoadPopularGenres();
        }
    }
}

