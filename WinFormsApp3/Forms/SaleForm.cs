using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class SaleForm : Form
    {
        private Book _book;
        private DatabaseHelper _dbHelper;

        public SaleForm(Book book, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _book = book;
            _dbHelper = dbHelper;
            LoadBookInfo();
        }

        private void LoadBookInfo()
        {
            lblBookTitle.Text = _book.Title;
            lblAuthor.Text = _book.AuthorFullName;
            lblAvailableQuantity.Text = $"Доступно: {_book.Quantity}";
            numQuantity.Maximum = _book.Quantity;
            numQuantity.Value = 1;
            
            decimal price = _book.SalePrice;
            if (_book.IsOnSale && _book.SaleDiscount.HasValue)
            {
                price = price * (1 - _book.SaleDiscount.Value / 100);
            }
            lblPrice.Text = $"Цена: {price:F2} руб.";
            _currentPrice = price;
        }

        private decimal _currentPrice;

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = $"Итого: {_currentPrice * numQuantity.Value:F2} руб.";
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            int quantity = (int)numQuantity.Value;
            if (quantity > _book.Quantity)
            {
                MessageBox.Show("Недостаточно книг на складе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sale = new Sale
                {
                    BookId = _book.Id,
                    Quantity = quantity,
                    Price = _currentPrice,
                    SaleDate = DateTime.Now,
                    CustomerName = string.IsNullOrWhiteSpace(txtCustomer.Text) ? null : txtCustomer.Text.Trim()
                };

                _dbHelper.AddSale(sale);
                MessageBox.Show("Книга успешно продана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при продаже: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

