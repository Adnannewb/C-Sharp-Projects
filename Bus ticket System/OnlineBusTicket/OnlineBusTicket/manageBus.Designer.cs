namespace OnlineBusTicket
{
    partial class manageBus
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
            this.txtBusName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRouteTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRouteFrom = new System.Windows.Forms.TextBox();
            this.dgvBuses = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalSeats = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAvailableSeats = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAddBus_Click);
            // 
            // txtBusName
            // 
            this.txtBusName.Location = new System.Drawing.Point(138, 77);
            this.txtBusName.Name = "txtBusName";
            this.txtBusName.Size = new System.Drawing.Size(100, 26);
            this.txtBusName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bus name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ticket Price ";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(138, 244);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 26);
            this.txtPrice.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "TO";
            // 
            // txtRouteTo
            // 
            this.txtRouteTo.Location = new System.Drawing.Point(138, 182);
            this.txtRouteTo.Name = "txtRouteTo";
            this.txtRouteTo.Size = new System.Drawing.Size(100, 26);
            this.txtRouteTo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "From";
            // 
            // txtRouteFrom
            // 
            this.txtRouteFrom.Location = new System.Drawing.Point(138, 128);
            this.txtRouteFrom.Name = "txtRouteFrom";
            this.txtRouteFrom.Size = new System.Drawing.Size(100, 26);
            this.txtRouteFrom.TabIndex = 7;
            // 
            // dgvBuses
            // 
            this.dgvBuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuses.Location = new System.Drawing.Point(395, 31);
            this.dgvBuses.Name = "dgvBuses";
            this.dgvBuses.RowHeadersWidth = 62;
            this.dgvBuses.RowTemplate.Height = 28;
            this.dgvBuses.Size = new System.Drawing.Size(587, 264);
            this.dgvBuses.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 478);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 51);
            this.button2.TabIndex = 10;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnEditBus_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(601, 478);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 51);
            this.button3.TabIndex = 11;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDeleteBus_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(862, 478);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 51);
            this.button4.TabIndex = 12;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total Seats";
            // 
            // txtTotalSeats
            // 
            this.txtTotalSeats.Location = new System.Drawing.Point(138, 285);
            this.txtTotalSeats.Name = "txtTotalSeats";
            this.txtTotalSeats.Size = new System.Drawing.Size(100, 26);
            this.txtTotalSeats.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Available Seats";
            // 
            // txtAvailableSeats
            // 
            this.txtAvailableSeats.Location = new System.Drawing.Point(138, 347);
            this.txtAvailableSeats.Name = "txtAvailableSeats";
            this.txtAvailableSeats.Size = new System.Drawing.Size(100, 26);
            this.txtAvailableSeats.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(43, 401);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 51);
            this.button5.TabIndex = 17;
            this.button5.Text = "Manage Seats";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnmanageseats_Click);
            // 
            // manageBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 602);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalSeats);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAvailableSeats);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvBuses);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRouteFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRouteTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBusName);
            this.Controls.Add(this.button1);
            this.Name = "manageBus";
            this.Text = "manageBus";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBusName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRouteTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRouteFrom;
        private System.Windows.Forms.DataGridView dgvBuses;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalSeats;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAvailableSeats;
        private System.Windows.Forms.Button button5;
    }
}