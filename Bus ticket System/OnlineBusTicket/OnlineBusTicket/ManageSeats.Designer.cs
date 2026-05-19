namespace OnlineBusTicket
{
    partial class ManageSeats
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
            this.cmbBusNames = new System.Windows.Forms.ComboBox();
            this.dgvSeats = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeatNumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBusNames
            // 
            this.cmbBusNames.FormattingEnabled = true;
            this.cmbBusNames.Location = new System.Drawing.Point(143, 108);
            this.cmbBusNames.Name = "cmbBusNames";
            this.cmbBusNames.Size = new System.Drawing.Size(121, 28);
            this.cmbBusNames.TabIndex = 0;
            this.cmbBusNames.Click += new System.EventHandler(this.ManageSeats_Load);
            // 
            // dgvSeats
            // 
            this.dgvSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeats.Location = new System.Drawing.Point(362, 24);
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.RowHeadersWidth = 62;
            this.dgvSeats.RowTemplate.Height = 28;
            this.dgvSeats.Size = new System.Drawing.Size(507, 224);
            this.dgvSeats.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bus Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seat Number";
            // 
            // txtSeatNumber
            // 
            this.txtSeatNumber.Location = new System.Drawing.Point(143, 177);
            this.txtSeatNumber.Name = "txtSeatNumber";
            this.txtSeatNumber.Size = new System.Drawing.Size(100, 26);
            this.txtSeatNumber.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAddSeat_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 432);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 53);
            this.button2.TabIndex = 6;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnEditSeat_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(507, 432);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 53);
            this.button3.TabIndex = 7;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDeleteSeat_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(743, 432);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 53);
            this.button4.TabIndex = 8;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnback_Click);
            // 
            // ManageSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 575);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSeatNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSeats);
            this.Controls.Add(this.cmbBusNames);
            this.Name = "ManageSeats";
            this.Text = "ManageSeats";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBusNames;
        private System.Windows.Forms.DataGridView dgvSeats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeatNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}