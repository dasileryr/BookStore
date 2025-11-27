using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvBooks;
        private Label lblUser;
        private Button btnAddBook;
        private Button btnEditBook;
        private Button btnDeleteBook;
        private Button btnSellBook;
        private Button btnWriteOff;
        private Button btnReserve;
        private Button btnSale;
        private Button btnSearch;
        private Button btnStatistics;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvBooks = new DataGridView();
            lblUser = new Label();
            btnAddBook = new Button();
            btnEditBook = new Button();
            btnDeleteBook = new Button();
            btnSellBook = new Button();
            btnWriteOff = new Button();
            btnReserve = new Button();
            btnSale = new Button();
            btnSearch = new Button();
            btnStatistics = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(12, 50);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(960, 400);
            dgvBooks.TabIndex = 0;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(12, 15);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 15);
            lblUser.TabIndex = 1;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(12, 470);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(100, 30);
            btnAddBook.TabIndex = 2;
            btnAddBook.Text = "Добавить";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnEditBook
            // 
            btnEditBook.Location = new Point(118, 470);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(100, 30);
            btnEditBook.TabIndex = 3;
            btnEditBook.Text = "Редактировать";
            btnEditBook.UseVisualStyleBackColor = true;
            btnEditBook.Click += btnEditBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(224, 470);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(100, 30);
            btnDeleteBook.TabIndex = 4;
            btnDeleteBook.Text = "Удалить";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // btnSellBook
            // 
            btnSellBook.Location = new Point(330, 470);
            btnSellBook.Name = "btnSellBook";
            btnSellBook.Size = new Size(100, 30);
            btnSellBook.TabIndex = 5;
            btnSellBook.Text = "Продать";
            btnSellBook.UseVisualStyleBackColor = true;
            btnSellBook.Click += btnSellBook_Click;
            // 
            // btnWriteOff
            // 
            btnWriteOff.Location = new Point(436, 470);
            btnWriteOff.Name = "btnWriteOff";
            btnWriteOff.Size = new Size(100, 30);
            btnWriteOff.TabIndex = 6;
            btnWriteOff.Text = "Списать";
            btnWriteOff.UseVisualStyleBackColor = true;
            btnWriteOff.Click += btnWriteOff_Click;
            // 
            // btnReserve
            // 
            btnReserve.Location = new Point(542, 470);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(100, 30);
            btnReserve.TabIndex = 7;
            btnReserve.Text = "Отложить";
            btnReserve.UseVisualStyleBackColor = true;
            btnReserve.Click += btnReserve_Click;
            // 
            // btnSale
            // 
            btnSale.Location = new Point(648, 470);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(100, 30);
            btnSale.TabIndex = 8;
            btnSale.Text = "Акция";
            btnSale.UseVisualStyleBackColor = true;
            btnSale.Click += btnSale_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(754, 470);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.Location = new Point(860, 470);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(100, 30);
            btnStatistics.TabIndex = 10;
            btnStatistics.Text = "Статистика";
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(872, 15);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 30);
            btnExit.TabIndex = 11;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 512);
            Controls.Add(btnExit);
            Controls.Add(btnStatistics);
            Controls.Add(btnSearch);
            Controls.Add(btnSale);
            Controls.Add(btnReserve);
            Controls.Add(btnWriteOff);
            Controls.Add(btnSellBook);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnEditBook);
            Controls.Add(btnAddBook);
            Controls.Add(lblUser);
            Controls.Add(dgvBooks);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Книжный магазин";
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

