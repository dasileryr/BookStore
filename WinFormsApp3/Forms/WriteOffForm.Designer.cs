using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Forms
{
    partial class WriteOffForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblBookTitle;
        private Label lblAvailableQuantity;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblReason;
        private TextBox txtReason;
        private Button btnWriteOff;
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
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblReason = new Label();
            txtReason = new TextBox();
            btnWriteOff = new Button();
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
            // lblAvailableQuantity
            // 
            lblAvailableQuantity.AutoSize = true;
            lblAvailableQuantity.Location = new Point(20, 50);
            lblAvailableQuantity.Name = "lblAvailableQuantity";
            lblAvailableQuantity.Size = new Size(0, 15);
            lblAvailableQuantity.TabIndex = 1;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(20, 80);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 15);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Количество:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(130, 77);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(20, 110);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(100, 15);
            lblReason.TabIndex = 4;
            lblReason.Text = "Причина списания:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(20, 130);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(320, 80);
            txtReason.TabIndex = 5;
            // 
            // btnWriteOff
            // 
            btnWriteOff.Location = new Point(130, 230);
            btnWriteOff.Name = "btnWriteOff";
            btnWriteOff.Size = new Size(90, 30);
            btnWriteOff.TabIndex = 6;
            btnWriteOff.Text = "Списать";
            btnWriteOff.UseVisualStyleBackColor = true;
            btnWriteOff.Click += btnWriteOff_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(240, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // WriteOffForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 280);
            Controls.Add(btnCancel);
            Controls.Add(btnWriteOff);
            Controls.Add(txtReason);
            Controls.Add(lblReason);
            Controls.Add(numQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(lblAvailableQuantity);
            Controls.Add(lblBookTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "WriteOffForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Списание книги";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

