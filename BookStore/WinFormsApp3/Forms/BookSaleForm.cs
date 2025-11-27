using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class BookSaleForm : Form
    {
        private Book _book;
        private DatabaseHelper _dbHelper;

        public BookSaleForm(Book book, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _book = book;
            _dbHelper = dbHelper;
            LoadBookInfo();
        }

        private void LoadBookInfo()
        {
            lblBookTitle.Text = _book.Title;
            chkOnSale.Checked = _book.IsOnSale;
            if (_book.SaleDiscount.HasValue)
            {
                numDiscount.Value = _book.SaleDiscount.Value;
            }
            numDiscount.Enabled = chkOnSale.Checked;
        }

        private void chkOnSale_CheckedChanged(object sender, EventArgs e)
        {
            numDiscount.Enabled = chkOnSale.Checked;
            if (!chkOnSale.Checked)
            {
                numDiscount.Value = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkOnSale.Checked)
                {
                    if (numDiscount.Value <= 0 || numDiscount.Value >= 100)
                    {
                        MessageBox.Show("Скидка должна быть от 1 до 99%", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    _dbHelper.SetBookOnSale(_book.Id, numDiscount.Value);
                }
                else
                {
                    _dbHelper.RemoveBookFromSale(_book.Id);
                }
                MessageBox.Show("Изменения сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

