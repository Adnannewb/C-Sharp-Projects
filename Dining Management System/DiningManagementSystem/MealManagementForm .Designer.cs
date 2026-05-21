namespace DiningManagementSystem
{
    partial class MealManagementForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMealTime = new System.Windows.Forms.ComboBox();
            this.txtMealName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMealID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvMeals = new System.Windows.Forms.DataGridView();
            this.txtPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeals)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 533);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Meal Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Price";
            // 
            // cmbMealTime
            // 
            this.cmbMealTime.FormattingEnabled = true;
            this.cmbMealTime.Items.AddRange(new object[] {
            "Breakfast",
            "Lunch",
            "Dinner"});
            this.cmbMealTime.Location = new System.Drawing.Point(216, 525);
            this.cmbMealTime.Name = "cmbMealTime";
            this.cmbMealTime.Size = new System.Drawing.Size(121, 28);
            this.cmbMealTime.TabIndex = 35;
            // 
            // txtMealName
            // 
            this.txtMealName.Location = new System.Drawing.Point(216, 404);
            this.txtMealName.Name = "txtMealName";
            this.txtMealName.Size = new System.Drawing.Size(100, 26);
            this.txtMealName.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Meal name";
            // 
            // txtMealID
            // 
            this.txtMealID.Location = new System.Drawing.Point(216, 352);
            this.txtMealID.Name = "txtMealID";
            this.txtMealID.Size = new System.Drawing.Size(100, 26);
            this.txtMealID.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Meal Id";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(680, 587);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 61);
            this.button4.TabIndex = 30;
            this.button4.Text = "delete";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(897, 587);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 61);
            this.button3.TabIndex = 29;
            this.button3.Text = "back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnback_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 587);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 61);
            this.button2.TabIndex = 28;
            this.button2.Text = "update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 596);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 61);
            this.button1.TabIndex = 27;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvMeals
            // 
            this.dgvMeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeals.Location = new System.Drawing.Point(160, 46);
            this.dgvMeals.Name = "dgvMeals";
            this.dgvMeals.RowHeadersWidth = 62;
            this.dgvMeals.RowTemplate.Height = 28;
            this.dgvMeals.Size = new System.Drawing.Size(787, 251);
            this.dgvMeals.TabIndex = 39;
            this.dgvMeals.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(216, 474);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 26);
            this.txtPrice.TabIndex = 40;
            // 
            // MealManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 681);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.dgvMeals);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMealTime);
            this.Controls.Add(this.txtMealName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMealID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MealManagementForm";
            this.Text = "MealManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMealTime;
        private System.Windows.Forms.TextBox txtMealName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMealID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvMeals;
        private System.Windows.Forms.TextBox txtPrice;
    }
}