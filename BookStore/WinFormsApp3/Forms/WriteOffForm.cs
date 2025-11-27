using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class WriteOffForm : Form
    {
        private Book _book;
        private DatabaseHelper _dbHelper;

        public WriteOffForm(Book book, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _book = book;
            _dbHelper = dbHelper;
            LoadBookInfo();
        }

        private void LoadBookInfo()
        {
            lblBookTitle.Text = _book.Title;
            lblAvailableQuantity.Text = $"Доступно: {_book.Quantity}";
            numQuantity.Maximum = _book.Quantity;
            numQuantity.Value = 1;
        }

        private void btnWriteOff_Click(object sender, EventArgs e)
        {
            int quantity = (int)numQuantity.Value;
            if (quantity > _book.Quantity)
            {
                MessageBox.Show("Недостаточно книг на складе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Укажите причину списания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var writeOff = new WriteOff
                {
                    BookId = _book.Id,
                    Quantity = quantity,
                    WriteOffDate = DateTime.Now,
                    Reason = txtReason.Text.Trim()
                };

                _dbHelper.AddWriteOff(writeOff);
                MessageBox.Show("Книга успешно списана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при списании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

