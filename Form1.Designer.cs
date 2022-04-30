namespace Enrollment_Sorter
{
    partial class EnrollmentSorter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.processCSV = new System.Windows.Forms.Button();
            this.exportCSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Enrollment  File";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(357, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // processCSV
            // 
            this.processCSV.Location = new System.Drawing.Point(65, 104);
            this.processCSV.Name = "processCSV";
            this.processCSV.Size = new System.Drawing.Size(114, 23);
            this.processCSV.TabIndex = 2;
            this.processCSV.Text = "Process CSV File";
            this.processCSV.UseVisualStyleBackColor = true;
            this.processCSV.Click += new System.EventHandler(this.processCSV_Click);
            // 
            // exportCSV
            // 
            this.exportCSV.Location = new System.Drawing.Point(233, 104);
            this.exportCSV.Name = "exportCSV";
            this.exportCSV.Size = new System.Drawing.Size(158, 23);
            this.exportCSV.TabIndex = 3;
            this.exportCSV.Text = "Export Processed CSV File";
            this.exportCSV.UseVisualStyleBackColor = true;
            this.exportCSV.Click += new System.EventHandler(this.exportCSV_Click);
            // 
            // EnrollmentSorter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 450);
            this.Controls.Add(this.exportCSV);
            this.Controls.Add(this.processCSV);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "EnrollmentSorter";
            this.Text = "Enrollment Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button processCSV;
        private Button exportCSV;
    }
}