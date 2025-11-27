using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class MainForm : Form
    {
        private DatabaseHelper _dbHelper;
        private User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _currentUser = user;
            lblUser.Text = $"Пользователь: {user.FullName}";
            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _dbHelper.GetAllBooks();
            dgvBooks.DataSource = books;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using var form = new BookEditForm(null, _dbHelper);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadBooks();
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.DataBoundItem is Book book)
            {
                using var form = new BookEditForm(book, _dbHelper);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.DataBoundItem is Book book)
            {
                if (MessageBox.Show($"Удалить книгу '{book.Title}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _dbHelper.DeleteBook(book.Id);
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSellBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.DataBoundItem is Book book)
            {
                using var form = new SaleForm(book, _dbHelper);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для продажи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnWriteOff_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.DataBoundItem is Book book)
            {
                using var form = new WriteOffForm(book, _dbHelper);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для списания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.DataBoundItem is Book book)
            {
                using var form = new ReservationForm(book, _dbHelper);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите книгу для резервирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow?.DataBoundItem is Book book)
            {
                using var form = new BookSaleForm(book, _dbHelper);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для акции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using var form = new SearchForm(_dbHelper);
            form.ShowDialog();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            using var form = new StatisticsForm(_dbHelper);
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

