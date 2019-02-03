namespace MobileGrid
{
    partial class MainForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.mobileGridControl1 = new MobileGrid.MobileGridControl();
            this.mobileGridRow1 = new MobileGrid.MobileGridRow();
            this.mobileGridRow2 = new MobileGrid.MobileGridRow();
            this.mobileGridRow3 = new MobileGrid.MobileGridRow();
            this.mobileGridRow4 = new MobileGrid.MobileGridRow();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(221, 11);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(164, 212);
            this.listBox1.TabIndex = 1;
            // 
            // mobileGridControl1
            // 
            this.mobileGridControl1.ActiveRowColor = System.Drawing.Color.LightBlue;
            this.mobileGridControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mobileGridControl1.DataSource = null;
            this.mobileGridControl1.DefaultRowColor = System.Drawing.SystemColors.Control;
            this.mobileGridControl1.GridRowType = null;
            this.mobileGridControl1.Location = new System.Drawing.Point(8, 8);
            this.mobileGridControl1.Margin = new System.Windows.Forms.Padding(1);
            this.mobileGridControl1.Name = "mobileGridControl1";
            this.mobileGridControl1.SelectedRow = null;
            this.mobileGridControl1.Size = new System.Drawing.Size(201, 196);
            this.mobileGridControl1.TabIndex = 0;

            // 
            // mobileGridRow1
            // 
            this.mobileGridRow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mobileGridRow1.Data = null;
            this.mobileGridRow1.GridControl = null;
            this.mobileGridRow1.Location = new System.Drawing.Point(0, 0);
            this.mobileGridRow1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mobileGridRow1.Name = "mobileGridRow1";
            this.mobileGridRow1.Size = new System.Drawing.Size(300, 60);
            this.mobileGridRow1.TabIndex = 0;
            // 
            // mobileGridRow2
            // 
            this.mobileGridRow2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mobileGridRow2.Data = null;
            this.mobileGridRow2.GridControl = null;
            this.mobileGridRow2.Location = new System.Drawing.Point(0, 0);
            this.mobileGridRow2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mobileGridRow2.Name = "mobileGridRow2";
            this.mobileGridRow2.Size = new System.Drawing.Size(300, 60);
            this.mobileGridRow2.TabIndex = 0;
            // 
            // mobileGridRow3
            // 
            this.mobileGridRow3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mobileGridRow3.Data = null;
            this.mobileGridRow3.GridControl = null;
            this.mobileGridRow3.Location = new System.Drawing.Point(0, 0);
            this.mobileGridRow3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mobileGridRow3.Name = "mobileGridRow3";
            this.mobileGridRow3.Size = new System.Drawing.Size(300, 60);
            this.mobileGridRow3.TabIndex = 0;
            // 
            // mobileGridRow4
            // 
            this.mobileGridRow4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mobileGridRow4.Data = null;
            this.mobileGridRow4.GridControl = null;
            this.mobileGridRow4.Location = new System.Drawing.Point(0, 0);
            this.mobileGridRow4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mobileGridRow4.Name = "mobileGridRow4";
            this.mobileGridRow4.Size = new System.Drawing.Size(300, 60);
            this.mobileGridRow4.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 337);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.mobileGridControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MobileGridControl mobileGridControl1;
        private System.Windows.Forms.ListBox listBox1;
        private MobileGridRow mobileGridRow1;
        private MobileGridRow mobileGridRow2;
        private MobileGridRow mobileGridRow3;
        private MobileGridRow mobileGridRow4;
    }
}

