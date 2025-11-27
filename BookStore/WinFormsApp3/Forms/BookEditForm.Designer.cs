using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class BookEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblPublisher;
        private Label lblPages;
        private Label lblGenre;
        private Label lblYear;
        private Label lblCostPrice;
        private Label lblSalePrice;
        private Label lblQuantity;
        private Label lblContinuation;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtPublisher;
        private NumericUpDown numPages;
        private TextBox txtGenre;
        private NumericUpDown numYear;
        private NumericUpDown numCostPrice;
        private NumericUpDown numSalePrice;
        private NumericUpDown numQuantity;
        private ComboBox cmbContinuation;
        private CheckBox chkOnSale;
        private Label lblDiscount;
        private NumericUpDown numDiscount;
        private Button btnSave;
        private Button btnCancel;

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
            lblTitle = new Label();
            lblAuthor = new Label();
            lblPublisher = new Label();
            lblPages = new Label();
            lblGenre = new Label();
            lblYear = new Label();
            lblCostPrice = new Label();
            lblSalePrice = new Label();
            lblQuantity = new Label();
            lblContinuation = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtPublisher = new TextBox();
            numPages = new NumericUpDown();
            txtGenre = new TextBox();
            numYear = new NumericUpDown();
            numCostPrice = new NumericUpDown();
            numSalePrice = new NumericUpDown();
            numQuantity = new NumericUpDown();
            cmbContinuation = new ComboBox();
            chkOnSale = new CheckBox();
            lblDiscount = new Label();
            numDiscount = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCostPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(98, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Название книги:";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(20, 50);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(75, 15);
            lblAuthor.TabIndex = 1;
            lblAuthor.Text = "ФИО автора:";
            // 
            // lblPublisher
            // 
            lblPublisher.AutoSize = true;
            lblPublisher.Location = new Point(20, 80);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(95, 15);
            lblPublisher.TabIndex = 2;
            lblPublisher.Text = "Издательство:";
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Location = new Point(20, 110);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(108, 15);
            lblPages.TabIndex = 3;
            lblPages.Text = "Количество страниц:";
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(20, 140);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(42, 15);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "Жанр:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(20, 170);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(75, 15);
            lblYear.TabIndex = 5;
            lblYear.Text = "Год издания:";
            // 
            // lblCostPrice
            // 
            lblCostPrice.AutoSize = true;
            lblCostPrice.Location = new Point(20, 200);
            lblCostPrice.Name = "lblCostPrice";
            lblCostPrice.Size = new Size(84, 15);
            lblCostPrice.TabIndex = 6;
            lblCostPrice.Text = "Себестоимость:";
            // 
            // lblSalePrice
            // 
            lblSalePrice.AutoSize = true;
            lblSalePrice.Location = new Point(20, 230);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(100, 15);
            lblSalePrice.TabIndex = 7;
            lblSalePrice.Text = "Цена для продажи:";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 260);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(70, 15);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Количество:";
            // 
            // lblContinuation
            // 
            lblContinuation.AutoSize = true;
            lblContinuation.Location = new Point(20, 290);
            lblContinuation.Name = "lblContinuation";
            lblContinuation.Size = new Size(150, 15);
            lblContinuation.TabIndex = 9;
            lblContinuation.Text = "Продолжение книги:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(180, 17);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 23);
            txtTitle.TabIndex = 10;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(180, 47);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(300, 23);
            txtAuthor.TabIndex = 11;
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(180, 77);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(300, 23);
            txtPublisher.TabIndex = 12;
            // 
            // numPages
            // 
            numPages.Location = new Point(180, 107);
            numPages.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPages.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPages.Name = "numPages";
            numPages.Size = new Size(120, 23);
            numPages.TabIndex = 13;
            numPages.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(180, 137);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(300, 23);
            txtGenre.TabIndex = 14;
            // 
            // numYear
            // 
            numYear.Location = new Point(180, 167);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(120, 23);
            numYear.TabIndex = 15;
            numYear.Value = new decimal(new int[] { 2024, 0, 0, 0 });
            // 
            // numCostPrice
            // 
            numCostPrice.DecimalPlaces = 2;
            numCostPrice.Location = new Point(180, 197);
            numCostPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numCostPrice.Name = "numCostPrice";
            numCostPrice.Size = new Size(120, 23);
            numCostPrice.TabIndex = 16;
            // 
            // numSalePrice
            // 
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Location = new Point(180, 227);
            numSalePrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numSalePrice.Name = "numSalePrice";
            numSalePrice.Size = new Size(120, 23);
            numSalePrice.TabIndex = 17;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(180, 257);
            numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 18;
            // 
            // cmbContinuation
            // 
            cmbContinuation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContinuation.FormattingEnabled = true;
            cmbContinuation.Location = new Point(180, 287);
            cmbContinuation.Name = "cmbContinuation";
            cmbContinuation.Size = new Size(300, 23);
            cmbContinuation.TabIndex = 19;
            // 
            // chkOnSale
            // 
            chkOnSale.AutoSize = true;
            chkOnSale.Location = new Point(20, 320);
            chkOnSale.Name = "chkOnSale";
            chkOnSale.Size = new Size(125, 19);
            chkOnSale.TabIndex = 20;
            chkOnSale.Text = "Участвует в акции";
            chkOnSale.UseVisualStyleBackColor = true;
            chkOnSale.CheckedChanged += chkOnSale_CheckedChanged;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(20, 350);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(52, 15);
            lblDiscount.TabIndex = 21;
            lblDiscount.Text = "Скидка %:";
            // 
            // numDiscount
            // 
            numDiscount.DecimalPlaces = 2;
            numDiscount.Enabled = false;
            numDiscount.Location = new Point(180, 347);
            numDiscount.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(120, 23);
            numDiscount.TabIndex = 22;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(180, 390);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 23;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(290, 390);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 440);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numDiscount);
            Controls.Add(lblDiscount);
            Controls.Add(chkOnSale);
            Controls.Add(cmbContinuation);
            Controls.Add(numQuantity);
            Controls.Add(numSalePrice);
            Controls.Add(numCostPrice);
            Controls.Add(numYear);
            Controls.Add(txtGenre);
            Controls.Add(numPages);
            Controls.Add(txtPublisher);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblContinuation);
            Controls.Add(lblQuantity);
            Controls.Add(lblSalePrice);
            Controls.Add(lblCostPrice);
            Controls.Add(lblYear);
            Controls.Add(lblGenre);
            Controls.Add(lblPages);
            Controls.Add(lblPublisher);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление книги";
            ((System.ComponentModel.ISupportInitialize)numPages).EndInit();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCostPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

