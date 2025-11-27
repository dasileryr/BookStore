using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblBookTitle;
        private Label lblAvailableQuantity;
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private Label lblCustomerPhone;
        private TextBox txtCustomerPhone;
        private Label lblExpiryDate;
        private DateTimePicker dtpExpiryDate;
        private Button btnReserve;
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
            lblAvailableQuantity = new Label();
            lblCustomerName = new Label();
            txtCustomerName = new TextBox();
            lblCustomerPhone = new Label();
            txtCustomerPhone = new TextBox();
            lblExpiryDate = new Label();
            dtpExpiryDate = new DateTimePicker();
            btnReserve = new Button();
            btnCancel = new Button();
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
            // lblAvailableQuantity
            // 
            lblAvailableQuantity.AutoSize = true;
            lblAvailableQuantity.Location = new Point(20, 50);
            lblAvailableQuantity.Name = "lblAvailableQuantity";
            lblAvailableQuantity.Size = new Size(0, 15);
            lblAvailableQuantity.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(20, 80);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(100, 15);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Имя покупателя:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(130, 77);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(200, 23);
            txtCustomerName.TabIndex = 3;
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(20, 110);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(110, 15);
            lblCustomerPhone.TabIndex = 4;
            lblCustomerPhone.Text = "Телефон покупателя:";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(130, 107);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(200, 23);
            txtCustomerPhone.TabIndex = 5;
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Location = new Point(20, 140);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new Size(100, 15);
            lblExpiryDate.TabIndex = 6;
            lblExpiryDate.Text = "Срок действия:";
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Location = new Point(130, 137);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(200, 23);
            dtpExpiryDate.TabIndex = 7;
            // 
            // btnReserve
            // 
            btnReserve.Location = new Point(130, 180);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(90, 30);
            btnReserve.TabIndex = 8;
            btnReserve.Text = "Отложить";
            btnReserve.UseVisualStyleBackColor = true;
            btnReserve.Click += btnReserve_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(240, 180);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 230);
            Controls.Add(btnCancel);
            Controls.Add(btnReserve);
            Controls.Add(dtpExpiryDate);
            Controls.Add(lblExpiryDate);
            Controls.Add(txtCustomerPhone);
            Controls.Add(lblCustomerPhone);
            Controls.Add(txtCustomerName);
            Controls.Add(lblCustomerName);
            Controls.Add(lblAvailableQuantity);
            Controls.Add(lblBookTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отложить книгу";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

