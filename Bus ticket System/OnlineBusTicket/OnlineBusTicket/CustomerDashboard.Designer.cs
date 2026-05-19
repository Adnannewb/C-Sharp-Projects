namespace OnlineBusTicket
{
    partial class CustomerDashboard
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBusList = new System.Windows.Forms.DataGridView();
            this.cmbRouteFrom = new System.Windows.Forms.ComboBox();
            this.dgvSeats = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRouteTo = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusID = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.lblTicketPrice = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // dgvBusList
            // 
            this.dgvBusList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusList.Location = new System.Drawing.Point(378, 46);
            this.dgvBusList.Name = "dgvBusList";
            this.dgvBusList.RowHeadersWidth = 62;
            this.dgvBusList.RowTemplate.Height = 28;
            this.dgvBusList.Size = new System.Drawing.Size(644, 199);
            this.dgvBusList.TabIndex = 2;
            // 
            // cmbRouteFrom
            // 
            this.cmbRouteFrom.FormattingEnabled = true;
            this.cmbRouteFrom.Location = new System.Drawing.Point(151, 79);
            this.cmbRouteFrom.Name = "cmbRouteFrom";
            this.cmbRouteFrom.Size = new System.Drawing.Size(121, 28);
            this.cmbRouteFrom.TabIndex = 4;
            // 
            // dgvSeats
            // 
            this.dgvSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeats.Location = new System.Drawing.Point(520, 287);
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.RowHeadersWidth = 62;
            this.dgvSeats.RowTemplate.Height = 28;
            this.dgvSeats.Size = new System.Drawing.Size(368, 199);
            this.dgvSeats.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // cmbRouteTo
            // 
            this.cmbRouteTo.FormattingEnabled = true;
            this.cmbRouteTo.Location = new System.Drawing.Point(151, 147);
            this.cmbRouteTo.Name = "cmbRouteTo";
            this.cmbRouteTo.Size = new System.Drawing.Size(121, 28);
            this.cmbRouteTo.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 570);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 49);
            this.button2.TabIndex = 9;
            this.button2.Text = "Book";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 539);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 49);
            this.button3.TabIndex = 10;
            this.button3.Text = "Log out";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bus Id";
            // 
            // txtBusID
            // 
            this.txtBusID.Location = new System.Drawing.Point(378, 370);
            this.txtBusID.Name = "txtBusID";
            this.txtBusID.Size = new System.Drawing.Size(100, 26);
            this.txtBusID.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(365, 418);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 68);
            this.button4.TabIndex = 13;
            this.button4.Text = "Available Seats";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnSearchSeats_Click);
            // 
            // lblTicketPrice
            // 
            this.lblTicketPrice.AutoSize = true;
            this.lblTicketPrice.Location = new System.Drawing.Point(903, 264);
            this.lblTicketPrice.Name = "lblTicketPrice";
            this.lblTicketPrice.Size = new System.Drawing.Size(0, 20);
            this.lblTicketPrice.TabIndex = 14;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Card"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(572, 512);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(121, 28);
            this.cmbPaymentMethod.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 512);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Payment Method";
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 631);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTicketPrice);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBusID);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbRouteTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSeats);
            this.Controls.Add(this.cmbRouteFrom);
            this.Controls.Add(this.dgvBusList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "CustomerDashboard";
            this.Text = "CustomerDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBusList;
        private System.Windows.Forms.ComboBox cmbRouteFrom;
        private System.Windows.Forms.DataGridView dgvSeats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRouteTo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusID;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblTicketPrice;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label4;
    }
}