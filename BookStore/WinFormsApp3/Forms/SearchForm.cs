using WinFormsApp3.Data;
using WinFormsApp3.Models;

namespace WinFormsApp3.Forms
{
    public partial class SearchForm : Form
    {
        private DatabaseHelper _dbHelper;

        public SearchForm(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Book> results = new List<Book>();

            if (rbTitle.Checked && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                results = _dbHelper.SearchBooksByTitle(txtSearch.Text.Trim());
            }
            else if (rbAuthor.Checked && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                results = _dbHelper.SearchBooksByAuthor(txtSearch.Text.Trim());
            }
            else if (rbGenre.Checked && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                results = _dbHelper.SearchBooksByGenre(txtSearch.Text.Trim());
            }
            else
            {
                MessageBox.Show("Выберите тип поиска и введите поисковый запрос", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvResults.DataSource = results;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblResultsCount.Text = $"Найдено: {results.Count}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgvResults.DataSource = null;
            lblResultsCount.Text = "Найдено: 0";
        }
    }
}

