namespace DiningManagementSystem
{
    partial class TransactionManagementForm
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
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMealID = new System.Windows.Forms.ComboBox();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTokenID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStudentID = new System.Windows.Forms.ComboBox();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(379, 79);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersWidth = 62;
            this.dgvTransactions.RowTemplate.Height = 28;
            this.dgvTransactions.Size = new System.Drawing.Size(787, 251);
            this.dgvTransactions.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "Meal ID";
            // 
            // cmbMealID
            // 
            this.cmbMealID.FormattingEnabled = true;
            this.cmbMealID.Location = new System.Drawing.Point(237, 334);
            this.cmbMealID.Name = "cmbMealID";
            this.cmbMealID.Size = new System.Drawing.Size(121, 28);
            this.cmbMealID.TabIndex = 49;
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Location = new System.Drawing.Point(258, 279);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(100, 26);
            this.txtTransactionID.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Transactions Id";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(716, 567);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 61);
            this.button4.TabIndex = 44;
            this.button4.Text = "delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(932, 567);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 61);
            this.button3.TabIndex = 43;
            this.button3.Text = "back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnback_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(379, 567);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 61);
            this.button2.TabIndex = 42;
            this.button2.Text = "update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 61);
            this.button1.TabIndex = 41;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Token ID";
            // 
            // cmbTokenID
            // 
            this.cmbTokenID.FormattingEnabled = true;
            this.cmbTokenID.Location = new System.Drawing.Point(237, 434);
            this.cmbTokenID.Name = "cmbTokenID";
            this.cmbTokenID.Size = new System.Drawing.Size(121, 28);
            this.cmbTokenID.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Student ID";
            // 
            // cmbStudentID
            // 
            this.cmbStudentID.FormattingEnabled = true;
            this.cmbStudentID.Location = new System.Drawing.Point(237, 381);
            this.cmbStudentID.Name = "cmbStudentID";
            this.cmbStudentID.Size = new System.Drawing.Size(121, 28);
            this.cmbStudentID.TabIndex = 55;
            // 
            // dtpTransactionDate
            // 
            this.dtpTransactionDate.Location = new System.Drawing.Point(237, 482);
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            this.dtpTransactionDate.Size = new System.Drawing.Size(200, 26);
            this.dtpTransactionDate.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 58;
            this.label5.Text = "Transactions Date";
            // 
            // TransactionManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 685);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpTransactionDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStudentID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTokenID);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMealID);
            this.Controls.Add(this.txtTransactionID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "TransactionManagementForm";
            this.Text = "TransactionManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMealID;
        private System.Windows.Forms.TextBox txtTransactionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTokenID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStudentID;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
        private System.Windows.Forms.Label label5;
    }
}