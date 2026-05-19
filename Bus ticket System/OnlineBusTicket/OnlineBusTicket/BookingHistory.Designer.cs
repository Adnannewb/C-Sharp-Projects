namespace OnlineBusTicket
{
    partial class BookingHistory
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
            this.dgvBookingHistory = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBookingHistory
            // 
            this.dgvBookingHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookingHistory.Location = new System.Drawing.Point(203, 60);
            this.dgvBookingHistory.Name = "dgvBookingHistory";
            this.dgvBookingHistory.RowHeadersWidth = 62;
            this.dgvBookingHistory.RowTemplate.Height = 28;
            this.dgvBookingHistory.Size = new System.Drawing.Size(594, 266);
            this.dgvBookingHistory.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(772, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 54);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // BookingHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 503);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvBookingHistory);
            this.Name = "BookingHistory";
            this.Text = "BookingHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookingHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookingHistory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}