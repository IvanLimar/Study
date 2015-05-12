namespace Clock
{
    partial class clockForm
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
            this.components = new System.ComponentModel.Container();
            this.clockPictureBox = new System.Windows.Forms.PictureBox();
            this.clockTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clockPictureBox)).BeginInit();
            this.clockTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // clockPictureBox
            // 
            this.clockPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clockPictureBox.BackColor = System.Drawing.Color.White;
            this.clockPictureBox.Location = new System.Drawing.Point(3, 3);
            this.clockPictureBox.Name = "clockPictureBox";
            this.clockPictureBox.Size = new System.Drawing.Size(282, 265);
            this.clockPictureBox.TabIndex = 0;
            this.clockPictureBox.TabStop = false;
            // 
            // clockTableLayout
            // 
            this.clockTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clockTableLayout.ColumnCount = 1;
            this.clockTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.clockTableLayout.Controls.Add(this.clockPictureBox, 0, 0);
            this.clockTableLayout.Location = new System.Drawing.Point(0, -5);
            this.clockTableLayout.Name = "clockTableLayout";
            this.clockTableLayout.RowCount = 1;
            this.clockTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.clockTableLayout.Size = new System.Drawing.Size(288, 271);
            this.clockTableLayout.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Draw);
            // 
            // clockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.clockTableLayout);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "clockForm";
            this.Text = "Clock";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            ((System.ComponentModel.ISupportInitialize)(this.clockPictureBox)).EndInit();
            this.clockTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox clockPictureBox;
        private System.Windows.Forms.TableLayoutPanel clockTableLayout;
        private System.Windows.Forms.Timer timer;




    }
}

