
namespace LogicCalculator
{
    partial class TrueTable
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
            this.result_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // result_textBox
            // 
            this.result_textBox.BackColor = System.Drawing.Color.White;
            this.result_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.result_textBox.Location = new System.Drawing.Point(12, 12);
            this.result_textBox.Multiline = true;
            this.result_textBox.Name = "result_textBox";
            this.result_textBox.ReadOnly = true;
            this.result_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result_textBox.Size = new System.Drawing.Size(776, 426);
            this.result_textBox.TabIndex = 0;
            // 
            // TrueTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.result_textBox);
            this.Name = "TrueTable";
            this.Text = "TrueTable";
            this.Load += new System.EventHandler(this.TrueTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox result_textBox;
    }
}