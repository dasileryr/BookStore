using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private GroupBox gbSearchType;
        private RadioButton rbTitle;
        private RadioButton rbAuthor;
        private RadioButton rbGenre;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClear;
        private DataGridView dgvResults;
        private Label lblResultsCount;

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
            gbSearchType = new GroupBox();
            rbTitle = new RadioButton();
            rbAuthor = new RadioButton();
            rbGenre = new RadioButton();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            dgvResults = new DataGridView();
            lblResultsCount = new Label();
            gbSearchType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            SuspendLayout();
            // 
            // gbSearchType
            // 
            gbSearchType.Controls.Add(rbGenre);
            gbSearchType.Controls.Add(rbAuthor);
            gbSearchType.Controls.Add(rbTitle);
            gbSearchType.Location = new Point(20, 20);
            gbSearchType.Name = "gbSearchType";
            gbSearchType.Size = new Size(200, 100);
            gbSearchType.TabIndex = 0;
            gbSearchType.TabStop = false;
            gbSearchType.Text = "Тип поиска";
            // 
            // rbTitle
            // 
            rbTitle.AutoSize = true;
            rbTitle.Checked = true;
            rbTitle.Location = new Point(15, 25);
            rbTitle.Name = "rbTitle";
            rbTitle.Size = new Size(120, 19);
            rbTitle.TabIndex = 0;
            rbTitle.TabStop = true;
            rbTitle.Text = "По названию";
            rbTitle.UseVisualStyleBackColor = true;
            // 
            // rbAuthor
            // 
            rbAuthor.AutoSize = true;
            rbAuthor.Location = new Point(15, 50);
            rbAuthor.Name = "rbAuthor";
            rbAuthor.Size = new Size(90, 19);
            rbAuthor.TabIndex = 1;
            rbAuthor.Text = "По автору";
            rbAuthor.UseVisualStyleBackColor = true;
            // 
            // rbGenre
            // 
            rbGenre.AutoSize = true;
            rbGenre.Location = new Point(15, 75);
            rbGenre.Name = "rbGenre";
            rbGenre.Size = new Size(85, 19);
            rbGenre.TabIndex = 2;
            rbGenre.Text = "По жанру";
            rbGenre.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(240, 30);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(100, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Поисковый запрос:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(240, 50);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(240, 85);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(350, 85);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 4;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Location = new Point(20, 140);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.Size = new Size(720, 300);
            dgvResults.TabIndex = 5;
            // 
            // lblResultsCount
            // 
            lblResultsCount.AutoSize = true;
            lblResultsCount.Location = new Point(20, 450);
            lblResultsCount.Name = "lblResultsCount";
            lblResultsCount.Size = new Size(70, 15);
            lblResultsCount.TabIndex = 6;
            lblResultsCount.Text = "Найдено: 0";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 480);
            Controls.Add(lblResultsCount);
            Controls.Add(dgvResults);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(gbSearchType);
            Name = "SearchForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Поиск книг";
            gbSearchType.ResumeLayout(false);
            gbSearchType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

