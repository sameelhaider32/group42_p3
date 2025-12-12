namespace InventoryApp
{
    partial class Form1
    {
        
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLINQ = new System.Windows.Forms.RadioButton();
            this.rbSP = new System.Windows.Forms.RadioButton();
            this.btnLoadSales = new System.Windows.Forms.Button();
            this.btnLoadTopCustomers = new System.Windows.Forms.Button();
            this.btnOpenOrderForm = new System.Windows.Forms.Button();
            this.btnOpenProductForm = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowOrderDetails = new System.Windows.Forms.Button();
            this.btnCheckOrderTotal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLINQ);
            this.groupBox1.Controls.Add(this.rbSP);
            this.groupBox1.Location = new System.Drawing.Point(5, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(220, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logic Selection";
            // 
            // rbLINQ
            // 
            this.rbLINQ.AutoSize = true;
            this.rbLINQ.Checked = true;
            this.rbLINQ.Location = new System.Drawing.Point(5, 19);
            this.rbLINQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbLINQ.Name = "rbLINQ";
            this.rbLINQ.Size = new System.Drawing.Size(122, 20);
            this.rbLINQ.TabIndex = 1;
            this.rbLINQ.TabStop = true;
            this.rbLINQ.Text = "Use LINQ Logic";
            this.rbLINQ.UseVisualStyleBackColor = true;
            // 
            // rbSP
            // 
            this.rbSP.AutoSize = true;
            this.rbSP.Location = new System.Drawing.Point(5, 43);
            this.rbSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSP.Name = "rbSP";
            this.rbSP.Size = new System.Drawing.Size(162, 20);
            this.rbSP.TabIndex = 2;
            this.rbSP.Text = "Use Stored Procedure";
            this.rbSP.UseVisualStyleBackColor = true;
            // 
            // btnLoadSales
            // 
            this.btnLoadSales.Location = new System.Drawing.Point(5, 82);
            this.btnLoadSales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadSales.Name = "btnLoadSales";
            this.btnLoadSales.Size = new System.Drawing.Size(214, 33);
            this.btnLoadSales.TabIndex = 1;
            this.btnLoadSales.Text = "Load Sales Report";
            this.btnLoadSales.UseVisualStyleBackColor = true;
            this.btnLoadSales.Click += new System.EventHandler(this.btnLoadSales_Click);
            // 
            // btnLoadTopCustomers
            // 
            this.btnLoadTopCustomers.Location = new System.Drawing.Point(5, 119);
            this.btnLoadTopCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadTopCustomers.Name = "btnLoadTopCustomers";
            this.btnLoadTopCustomers.Size = new System.Drawing.Size(214, 33);
            this.btnLoadTopCustomers.TabIndex = 2;
            this.btnLoadTopCustomers.Text = "Top Customers (CTE)";
            this.btnLoadTopCustomers.UseVisualStyleBackColor = true;
            this.btnLoadTopCustomers.Click += new System.EventHandler(this.btnLoadTopCustomers_Click);
            // 
            // btnOpenOrderForm
            // 
            this.btnOpenOrderForm.Location = new System.Drawing.Point(5, 157);
            this.btnOpenOrderForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenOrderForm.Name = "btnOpenOrderForm";
            this.btnOpenOrderForm.Size = new System.Drawing.Size(214, 29);
            this.btnOpenOrderForm.TabIndex = 3;
            this.btnOpenOrderForm.Text = "Place New Order";
            this.btnOpenOrderForm.UseVisualStyleBackColor = true;
            this.btnOpenOrderForm.Click += new System.EventHandler(this.btnOpenOrderForm_Click);
            // 
            // btnOpenProductForm
            // 
            this.btnOpenProductForm.Location = new System.Drawing.Point(5, 190);
            this.btnOpenProductForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenProductForm.Name = "btnOpenProductForm";
            this.btnOpenProductForm.Size = new System.Drawing.Size(214, 30);
            this.btnOpenProductForm.TabIndex = 4;
            this.btnOpenProductForm.Text = "Manage Products";
            this.btnOpenProductForm.UseVisualStyleBackColor = true;
            this.btnOpenProductForm.Click += new System.EventHandler(this.btnOpenProductForm_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(225, 26);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 62;
            this.dgvReport.RowTemplate.Height = 28;
            this.dgvReport.Size = new System.Drawing.Size(476, 302);
            this.dgvReport.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Report Results";
            // 
            // btnShowOrderDetails
            // 
            this.btnShowOrderDetails.Location = new System.Drawing.Point(5, 225);
            this.btnShowOrderDetails.Name = "btnShowOrderDetails";
            this.btnShowOrderDetails.Size = new System.Drawing.Size(214, 29);
            this.btnShowOrderDetails.TabIndex = 7;
            this.btnShowOrderDetails.Text = "Show Order Details";
            this.btnShowOrderDetails.UseVisualStyleBackColor = true;
            this.btnShowOrderDetails.Click += new System.EventHandler(this.btnShowOrderDetails_Click);
            // 
            // btnCheckOrderTotal
            // 
            this.btnCheckOrderTotal.Location = new System.Drawing.Point(10, 260);
            this.btnCheckOrderTotal.Name = "btnCheckOrderTotal";
            this.btnCheckOrderTotal.Size = new System.Drawing.Size(209, 26);
            this.btnCheckOrderTotal.TabIndex = 8;
            this.btnCheckOrderTotal.Text = "Check Order Total";
            this.btnCheckOrderTotal.UseVisualStyleBackColor = true;
            this.btnCheckOrderTotal.Click += new System.EventHandler(this.btnCheckOrderTotal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 334);
            this.Controls.Add(this.btnCheckOrderTotal);
            this.Controls.Add(this.btnShowOrderDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnOpenProductForm);
            this.Controls.Add(this.btnOpenOrderForm);
            this.Controls.Add(this.btnLoadTopCustomers);
            this.Controls.Add(this.btnLoadSales);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLINQ;
        private System.Windows.Forms.RadioButton rbSP;
        private System.Windows.Forms.Button btnLoadSales;
        private System.Windows.Forms.Button btnLoadTopCustomers;
        private System.Windows.Forms.Button btnOpenOrderForm;
        private System.Windows.Forms.Button btnOpenProductForm;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowOrderDetails;
        private System.Windows.Forms.Button btnCheckOrderTotal;
    }
}