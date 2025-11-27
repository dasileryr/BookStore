using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class SaleForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblBookTitle;
        private Label lblAuthor;
        private Label lblAvailableQuantity;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblPrice;
        private Label lblTotal;
        private Label lblCustomer;
        private TextBox txtCustomer;
        private Button btnSell;
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
            lblAuthor = new Label();
            lblAvailableQuantity = new Label();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblPrice = new Label();
            lblTotal = new Label();
            lblCustomer = new Label();
            txtCustomer = new TextBox();
            btnSell = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
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
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(20, 50);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(0, 15);
            lblAuthor.TabIndex = 1;
            // 
            // lblAvailableQuantity
            // 
            lblAvailableQuantity.AutoSize = true;
            lblAvailableQuantity.Location = new Point(20, 80);
            lblAvailableQuantity.Name = "lblAvailableQuantity";
            lblAvailableQuantity.Size = new Size(0, 15);
            lblAvailableQuantity.TabIndex = 2;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 110);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 15);
            lblQuantity.TabIndex = 3;
            lblQuantity.Text = "Количество:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(130, 107);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 4;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 140);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(0, 15);
            lblPrice.TabIndex = 5;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 170);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 19);
            lblTotal.TabIndex = 6;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(20, 200);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(100, 15);
            lblCustomer.TabIndex = 7;
            lblCustomer.Text = "Имя покупателя:";
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(130, 197);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(200, 23);
            txtCustomer.TabIndex = 8;
            // 
            // btnSell
            // 
            btnSell.Location = new Point(130, 240);
            btnSell.Name = "btnSell";
            btnSell.Size = new Size(90, 30);
            btnSell.TabIndex = 9;
            btnSell.Text = "Продать";
            btnSell.UseVisualStyleBackColor = true;
            btnSell.Click += btnSell_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(240, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 290);
            Controls.Add(btnCancel);
            Controls.Add(btnSell);
            Controls.Add(txtCustomer);
            Controls.Add(lblCustomer);
            Controls.Add(lblTotal);
            Controls.Add(lblPrice);
            Controls.Add(numQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(lblAvailableQuantity);
            Controls.Add(lblAuthor);
            Controls.Add(lblBookTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaleForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Продажа книги";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

