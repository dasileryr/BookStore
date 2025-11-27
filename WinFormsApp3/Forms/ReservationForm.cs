using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class ReservationForm : Form
    {
        private Book _book;
        private DatabaseHelper _dbHelper;

        public ReservationForm(Book book, DatabaseHelper dbHelper)
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
            dtpExpiryDate.Value = DateTime.Now.AddDays(7);
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Введите имя покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
            {
                MessageBox.Show("Введите телефон покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var reservation = new Reservation
                {
                    BookId = _book.Id,
                    CustomerName = txtCustomerName.Text.Trim(),
                    CustomerPhone = txtCustomerPhone.Text.Trim(),
                    ReservationDate = DateTime.Now,
                    ExpiryDate = dtpExpiryDate.Value,
                    IsCompleted = false
                };

                _dbHelper.AddReservation(reservation);
                MessageBox.Show("Книга успешно отложена для покупателя", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при резервировании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

