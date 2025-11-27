using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl;
        private TabPage tabNewBooks;
        private TabPage tabBestSelling;
        private TabPage tabPopularAuthors;
        private TabPage tabPopularGenres;
        private DataGridView dgvNewBooks;
        private DataGridView dgvBestSelling;
        private DataGridView dgvPopularAuthors;
        private DataGridView dgvPopularGenres;
        private GroupBox gbPeriod;
        private RadioButton rbDay;
        private RadioButton rbWeek;
        private RadioButton rbMonth;
        private RadioButton rbYear;

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
            tabControl = new TabControl();
            tabNewBooks = new TabPage();
            tabBestSelling = new TabPage();
            tabPopularAuthors = new TabPage();
            tabPopularGenres = new TabPage();
            dgvNewBooks = new DataGridView();
            dgvBestSelling = new DataGridView();
            dgvPopularAuthors = new DataGridView();
            dgvPopularGenres = new DataGridView();
            gbPeriod = new GroupBox();
            rbDay = new RadioButton();
            rbWeek = new RadioButton();
            rbMonth = new RadioButton();
            rbYear = new RadioButton();
            tabControl.SuspendLayout();
            tabNewBooks.SuspendLayout();
            tabBestSelling.SuspendLayout();
            tabPopularAuthors.SuspendLayout();
            tabPopularGenres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNewBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBestSelling).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPopularAuthors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPopularGenres).BeginInit();
            gbPeriod.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabNewBooks);
            tabControl.Controls.Add(tabBestSelling);
            tabControl.Controls.Add(tabPopularAuthors);
            tabControl.Controls.Add(tabPopularGenres);
            tabControl.Location = new Point(12, 80);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(960, 420);
            tabControl.TabIndex = 0;
            // 
            // tabNewBooks
            // 
            tabNewBooks.Controls.Add(dgvNewBooks);
            tabNewBooks.Location = new Point(4, 24);
            tabNewBooks.Name = "tabNewBooks";
            tabNewBooks.Padding = new Padding(3);
            tabNewBooks.Size = new Size(952, 392);
            tabNewBooks.TabIndex = 0;
            tabNewBooks.Text = "Новинки";
            tabNewBooks.UseVisualStyleBackColor = true;
            // 
            // tabBestSelling
            // 
            tabBestSelling.Controls.Add(dgvBestSelling);
            tabBestSelling.Location = new Point(4, 24);
            tabBestSelling.Name = "tabBestSelling";
            tabBestSelling.Padding = new Padding(3);
            tabBestSelling.Size = new Size(952, 392);
            tabBestSelling.TabIndex = 1;
            tabBestSelling.Text = "Самые продаваемые";
            tabBestSelling.UseVisualStyleBackColor = true;
            // 
            // tabPopularAuthors
            // 
            tabPopularAuthors.Controls.Add(dgvPopularAuthors);
            tabPopularAuthors.Location = new Point(4, 24);
            tabPopularAuthors.Name = "tabPopularAuthors";
            tabPopularAuthors.Size = new Size(952, 392);
            tabPopularAuthors.TabIndex = 2;
            tabPopularAuthors.Text = "Популярные авторы";
            tabPopularAuthors.UseVisualStyleBackColor = true;
            // 
            // tabPopularGenres
            // 
            tabPopularGenres.Controls.Add(dgvPopularGenres);
            tabPopularGenres.Location = new Point(4, 24);
            tabPopularGenres.Name = "tabPopularGenres";
            tabPopularGenres.Size = new Size(952, 392);
            tabPopularGenres.TabIndex = 3;
            tabPopularGenres.Text = "Популярные жанры";
            tabPopularGenres.UseVisualStyleBackColor = true;
            // 
            // dgvNewBooks
            // 
            dgvNewBooks.AllowUserToAddRows = false;
            dgvNewBooks.AllowUserToDeleteRows = false;
            dgvNewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNewBooks.Dock = DockStyle.Fill;
            dgvNewBooks.Location = new Point(3, 3);
            dgvNewBooks.Name = "dgvNewBooks";
            dgvNewBooks.ReadOnly = true;
            dgvNewBooks.Size = new Size(946, 386);
            dgvNewBooks.TabIndex = 0;
            // 
            // dgvBestSelling
            // 
            dgvBestSelling.AllowUserToAddRows = false;
            dgvBestSelling.AllowUserToDeleteRows = false;
            dgvBestSelling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBestSelling.Dock = DockStyle.Fill;
            dgvBestSelling.Location = new Point(3, 3);
            dgvBestSelling.Name = "dgvBestSelling";
            dgvBestSelling.ReadOnly = true;
            dgvBestSelling.Size = new Size(946, 386);
            dgvBestSelling.TabIndex = 0;
            // 
            // dgvPopularAuthors
            // 
            dgvPopularAuthors.AllowUserToAddRows = false;
            dgvPopularAuthors.AllowUserToDeleteRows = false;
            dgvPopularAuthors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPopularAuthors.Dock = DockStyle.Fill;
            dgvPopularAuthors.Location = new Point(0, 0);
            dgvPopularAuthors.Name = "dgvPopularAuthors";
            dgvPopularAuthors.ReadOnly = true;
            dgvPopularAuthors.Size = new Size(952, 392);
            dgvPopularAuthors.TabIndex = 0;
            // 
            // dgvPopularGenres
            // 
            dgvPopularGenres.AllowUserToAddRows = false;
            dgvPopularGenres.AllowUserToDeleteRows = false;
            dgvPopularGenres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPopularGenres.Dock = DockStyle.Fill;
            dgvPopularGenres.Location = new Point(0, 0);
            dgvPopularGenres.Name = "dgvPopularGenres";
            dgvPopularGenres.ReadOnly = true;
            dgvPopularGenres.Size = new Size(952, 392);
            dgvPopularGenres.TabIndex = 0;
            // 
            // gbPeriod
            // 
            gbPeriod.Controls.Add(rbYear);
            gbPeriod.Controls.Add(rbMonth);
            gbPeriod.Controls.Add(rbWeek);
            gbPeriod.Controls.Add(rbDay);
            gbPeriod.Location = new Point(12, 12);
            gbPeriod.Name = "gbPeriod";
            gbPeriod.Size = new Size(400, 60);
            gbPeriod.TabIndex = 1;
            gbPeriod.TabStop = false;
            gbPeriod.Text = "Период";
            // 
            // rbDay
            // 
            rbDay.AutoSize = true;
            rbDay.Checked = true;
            rbDay.Location = new Point(15, 25);
            rbDay.Name = "rbDay";
            rbDay.Size = new Size(50, 19);
            rbDay.TabIndex = 0;
            rbDay.TabStop = true;
            rbDay.Text = "День";
            rbDay.UseVisualStyleBackColor = true;
            rbDay.CheckedChanged += PeriodChanged;
            // 
            // rbWeek
            // 
            rbWeek.AutoSize = true;
            rbWeek.Location = new Point(80, 25);
            rbWeek.Name = "rbWeek";
            rbWeek.Size = new Size(60, 19);
            rbWeek.TabIndex = 1;
            rbWeek.Text = "Неделя";
            rbWeek.UseVisualStyleBackColor = true;
            rbWeek.CheckedChanged += PeriodChanged;
            // 
            // rbMonth
            // 
            rbMonth.AutoSize = true;
            rbMonth.Location = new Point(160, 25);
            rbMonth.Name = "rbMonth";
            rbMonth.Size = new Size(60, 19);
            rbMonth.TabIndex = 2;
            rbMonth.Text = "Месяц";
            rbMonth.UseVisualStyleBackColor = true;
            rbMonth.CheckedChanged += PeriodChanged;
            // 
            // rbYear
            // 
            rbYear.AutoSize = true;
            rbYear.Location = new Point(240, 25);
            rbYear.Name = "rbYear";
            rbYear.Size = new Size(50, 19);
            rbYear.TabIndex = 3;
            rbYear.Text = "Год";
            rbYear.UseVisualStyleBackColor = true;
            rbYear.CheckedChanged += PeriodChanged;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 512);
            Controls.Add(gbPeriod);
            Controls.Add(tabControl);
            Name = "StatisticsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Статистика";
            tabControl.ResumeLayout(false);
            tabNewBooks.ResumeLayout(false);
            tabBestSelling.ResumeLayout(false);
            tabPopularAuthors.ResumeLayout(false);
            tabPopularGenres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNewBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBestSelling).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPopularAuthors).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPopularGenres).EndInit();
            gbPeriod.ResumeLayout(false);
            gbPeriod.PerformLayout();
            ResumeLayout(false);
        }
    }
}

