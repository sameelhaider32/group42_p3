namespace InventoryApp
{
    partial class OrderTotalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.btnCheckTotal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order ID:";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Location = new System.Drawing.Point(116, 46);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(100, 22);
            this.txtOrderId.TabIndex = 1;
            // 
            // btnCheckTotal
            // 
            this.btnCheckTotal.Location = new System.Drawing.Point(160, 219);
            this.btnCheckTotal.Name = "btnCheckTotal";
            this.btnCheckTotal.Size = new System.Drawing.Size(104, 23);
            this.btnCheckTotal.TabIndex = 2;
            this.btnCheckTotal.Text = "Check Total";
            this.btnCheckTotal.UseVisualStyleBackColor = true;
            this.btnCheckTotal.Click += new System.EventHandler(this.btnCheckTotal_Click);
            // 
            // OrderTotalForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.btnCheckTotal);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.label1);
            this.Name = "OrderTotalForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button btnCheckTotal;
    }
}