namespace ProjectManagementSystem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAssignment = new System.Windows.Forms.Button();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.btnManageTasks = new System.Windows.Forms.Button();
            this.btnManageProjects = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Bisque;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 45);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20);
            this.label1.Size = new System.Drawing.Size(596, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To Admin Panel";
            // 
            // btnAssignment
            // 
            this.btnAssignment.BackColor = System.Drawing.SystemColors.Control;
            this.btnAssignment.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignment.Image")));
            this.btnAssignment.Location = new System.Drawing.Point(859, 363);
            this.btnAssignment.Name = "btnAssignment";
            this.btnAssignment.Size = new System.Drawing.Size(153, 100);
            this.btnAssignment.TabIndex = 4;
            this.btnAssignment.Text = "ASSIGNMENTS";
            this.btnAssignment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAssignment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAssignment.UseVisualStyleBackColor = false;
            this.btnAssignment.Click += new System.EventHandler(this.btnAssignment_Click);
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.BackColor = System.Drawing.SystemColors.Control;
            this.btnManageEmployees.Image = ((System.Drawing.Image)(resources.GetObject("btnManageEmployees.Image")));
            this.btnManageEmployees.Location = new System.Drawing.Point(617, 363);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(148, 100);
            this.btnManageEmployees.TabIndex = 3;
            this.btnManageEmployees.Text = "EMPLOYEES";
            this.btnManageEmployees.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManageEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManageEmployees.UseVisualStyleBackColor = false;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // btnManageTasks
            // 
            this.btnManageTasks.BackColor = System.Drawing.SystemColors.Control;
            this.btnManageTasks.Image = ((System.Drawing.Image)(resources.GetObject("btnManageTasks.Image")));
            this.btnManageTasks.Location = new System.Drawing.Point(354, 363);
            this.btnManageTasks.Name = "btnManageTasks";
            this.btnManageTasks.Size = new System.Drawing.Size(142, 100);
            this.btnManageTasks.TabIndex = 2;
            this.btnManageTasks.Text = "TASK";
            this.btnManageTasks.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManageTasks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManageTasks.UseVisualStyleBackColor = false;
            this.btnManageTasks.Click += new System.EventHandler(this.btnManageTasks_Click);
            // 
            // btnManageProjects
            // 
            this.btnManageProjects.BackColor = System.Drawing.SystemColors.Control;
            this.btnManageProjects.Image = ((System.Drawing.Image)(resources.GetObject("btnManageProjects.Image")));
            this.btnManageProjects.Location = new System.Drawing.Point(88, 363);
            this.btnManageProjects.Name = "btnManageProjects";
            this.btnManageProjects.Size = new System.Drawing.Size(133, 100);
            this.btnManageProjects.TabIndex = 1;
            this.btnManageProjects.Text = "PROJECT";
            this.btnManageProjects.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManageProjects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManageProjects.UseVisualStyleBackColor = false;
            this.btnManageProjects.Click += new System.EventHandler(this.btnManageProjects_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1011, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1080, 650);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAssignment);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.btnManageTasks);
            this.Controls.Add(this.btnManageProjects);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManageProjects;
        private System.Windows.Forms.Button btnManageTasks;
        private System.Windows.Forms.Button btnManageEmployees;
        private System.Windows.Forms.Button btnAssignment;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

