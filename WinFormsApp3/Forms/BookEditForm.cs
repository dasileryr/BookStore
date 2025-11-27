using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class BookEditForm : Form
    {
        private Book? _book;
        private DatabaseHelper _dbHelper;

        public BookEditForm(Book? book, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _book = book;
            _dbHelper = dbHelper;
            LoadBooksForContinuation();
            if (_book != null)
            {
                LoadBookData();
                Text = "Редактирование книги";
            }
            else
            {
                Text = "Добавление книги";
            }
        }

        private void LoadBooksForContinuation()
        {
            var books = _dbHelper.GetAllBooks();
            cmbContinuation.Items.Add("(Не является продолжением)");
            cmbContinuation.Items.AddRange(books.ToArray());
            cmbContinuation.DisplayMember = "Title";
            cmbContinuation.SelectedIndex = 0;
        }

        private void LoadBookData()
        {
            if (_book == null) return;

            txtTitle.Text = _book.Title;
            txtAuthor.Text = _book.AuthorFullName;
            txtPublisher.Text = _book.Publisher;
            numPages.Value = _book.PageCount;
            txtGenre.Text = _book.Genre;
            numYear.Value = _book.PublicationYear;
            numCostPrice.Value = _book.CostPrice;
            numSalePrice.Value = _book.SalePrice;
            numQuantity.Value = _book.Quantity;
            chkOnSale.Checked = _book.IsOnSale;
            if (_book.SaleDiscount.HasValue)
                numDiscount.Value = _book.SaleDiscount.Value;

            if (_book.ContinuationOfBookId.HasValue)
            {
                for (int i = 0; i < cmbContinuation.Items.Count; i++)
                {
                    if (cmbContinuation.Items[i] is Book b && b.Id == _book.ContinuationOfBookId.Value)
                    {
                        cmbContinuation.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            var book = _book ?? new Book();
            book.Title = txtTitle.Text.Trim();
            book.AuthorFullName = txtAuthor.Text.Trim();
            book.Publisher = txtPublisher.Text.Trim();
            book.PageCount = (int)numPages.Value;
            book.Genre = txtGenre.Text.Trim();
            book.PublicationYear = (int)numYear.Value;
            book.CostPrice = numCostPrice.Value;
            book.SalePrice = numSalePrice.Value;
            book.Quantity = (int)numQuantity.Value;
            book.IsOnSale = chkOnSale.Checked;
            book.SaleDiscount = chkOnSale.Checked ? numDiscount.Value : null;

            if (cmbContinuation.SelectedItem is Book continuationBook)
            {
                book.ContinuationOfBookId = continuationBook.Id;
            }
            else
            {
                book.ContinuationOfBookId = null;
            }

            try
            {
                if (_book == null)
                {
                    _dbHelper.AddBook(book);
                }
                else
                {
                    _dbHelper.UpdateBook(book);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название книги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Введите ФИО автора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Введите жанр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numSalePrice.Value < numCostPrice.Value)
            {
                MessageBox.Show("Цена продажи не может быть меньше себестоимости", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkOnSale_CheckedChanged(object sender, EventArgs e)
        {
            numDiscount.Enabled = chkOnSale.Checked;
        }
    }
}

