using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class BookSaleForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblBookTitle;
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
            lblBookTitle = new Label();
            chkOnSale = new CheckBox();
            lblDiscount = new Label();
            numDiscount = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            SuspendLayout();
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBookTitle.Location = new Point(20, 20);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(0, 19);
            lblBookTitle.TabIndex = 0;
            // 
            // chkOnSale
            // 
            chkOnSale.AutoSize = true;
            chkOnSale.Location = new Point(20, 50);
            chkOnSale.Name = "chkOnSale";
            chkOnSale.Size = new Size(125, 19);
            chkOnSale.TabIndex = 1;
            chkOnSale.Text = "Участвует в акции";
            chkOnSale.UseVisualStyleBackColor = true;
            chkOnSale.CheckedChanged += chkOnSale_CheckedChanged;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(20, 80);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(52, 15);
            lblDiscount.TabIndex = 2;
            lblDiscount.Text = "Скидка %:";
            // 
            // numDiscount
            // 
            numDiscount.DecimalPlaces = 2;
            numDiscount.Location = new Point(90, 77);
            numDiscount.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numDiscount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(120, 23);
            numDiscount.TabIndex = 3;
            numDiscount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.Location = new Point(90, 120);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 120);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookSaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 170);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numDiscount);
            Controls.Add(lblDiscount);
            Controls.Add(chkOnSale);
            Controls.Add(lblBookTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookSaleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Акция на книгу";
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

