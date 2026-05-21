namespace DiningManagementSystem
{
    partial class TokenManagementForm
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTokenID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStudentID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTokenDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(649, 548);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 61);
            this.button4.TabIndex = 18;
            this.button4.Text = "delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(866, 548);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 61);
            this.button3.TabIndex = 17;
            this.button3.Text = "back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnback_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 548);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 61);
            this.button2.TabIndex = 16;
            this.button2.Text = "update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 557);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 61);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(185, 365);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 26);
            this.txtStatus.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Status";
            // 
            // txtTokenID
            // 
            this.txtTokenID.Location = new System.Drawing.Point(185, 313);
            this.txtTokenID.Name = "txtTokenID";
            this.txtTokenID.Size = new System.Drawing.Size(100, 26);
            this.txtTokenID.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Token Id";
            // 
            // cmbStudentID
            // 
            this.cmbStudentID.FormattingEnabled = true;
            this.cmbStudentID.Location = new System.Drawing.Point(185, 432);
            this.cmbStudentID.Name = "cmbStudentID";
            this.cmbStudentID.Size = new System.Drawing.Size(121, 28);
            this.cmbStudentID.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Student";
            // 
            // dtpTokenDate
            // 
            this.dtpTokenDate.Location = new System.Drawing.Point(185, 488);
            this.dtpTokenDate.Name = "dtpTokenDate";
            this.dtpTokenDate.Size = new System.Drawing.Size(200, 26);
            this.dtpTokenDate.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 494);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Token Date";
            // 
            // dgvTokens
            // 
            this.dgvTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokens.Location = new System.Drawing.Point(128, 66);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.RowHeadersWidth = 62;
            this.dgvTokens.RowTemplate.Height = 28;
            this.dgvTokens.Size = new System.Drawing.Size(670, 170);
            this.dgvTokens.TabIndex = 27;
            // 
            // TokenManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 631);
            this.Controls.Add(this.dgvTokens);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpTokenDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStudentID);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTokenID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "TokenManagementForm";
            this.Text = "TokenManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTokenID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStudentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTokenDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTokens;
    }
}