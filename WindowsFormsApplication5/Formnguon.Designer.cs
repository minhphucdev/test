namespace WindowsFormsApplication5
{
    partial class Formnguon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formnguon));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hien = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.RANGE = new System.Windows.Forms.Label();
            this.DISPLA = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button13 = new System.Windows.Forms.Button();
            this.PICBOX2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PICBOX2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hien
            // 
            this.hien.AutoSize = true;
            this.hien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hien.ForeColor = System.Drawing.Color.Lime;
            this.hien.Location = new System.Drawing.Point(457, 258);
            this.hien.Name = "hien";
            this.hien.Size = new System.Drawing.Size(71, 25);
            this.hien.TabIndex = 70;
            this.hien.Text = "00:00";
            this.hien.Visible = false;
            this.hien.Click += new System.EventHandler(this.hien_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Lime;
            this.label23.Location = new System.Drawing.Point(377, 293);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(234, 25);
            this.label23.TabIndex = 146;
            this.label23.Text = "ON TIME 345210.6 H";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Lime;
            this.label26.Location = new System.Drawing.Point(377, 330);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(230, 25);
            this.label26.TabIndex = 147;
            this.label26.Text = "TX TIME 332210.6 H";
            // 
            // RANGE
            // 
            this.RANGE.AutoSize = true;
            this.RANGE.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RANGE.ForeColor = System.Drawing.Color.Lime;
            this.RANGE.Location = new System.Drawing.Point(40, 1);
            this.RANGE.Name = "RANGE";
            this.RANGE.Size = new System.Drawing.Size(0, 24);
            this.RANGE.TabIndex = 163;
            // 
            // DISPLA
            // 
            this.DISPLA.AutoSize = true;
            this.DISPLA.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DISPLA.ForeColor = System.Drawing.Color.Aqua;
            this.DISPLA.Location = new System.Drawing.Point(198, 36);
            this.DISPLA.Name = "DISPLA";
            this.DISPLA.Size = new System.Drawing.Size(0, 15);
            this.DISPLA.TabIndex = 190;
            this.DISPLA.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1314, 88);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(62, 33);
            this.flowLayoutPanel1.TabIndex = 504;
            // 
            // button13
            // 
            this.button13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button13.BackgroundImage")));
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(8, 689);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(81, 56);
            this.button13.TabIndex = 571;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // PICBOX2
            // 
            this.PICBOX2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PICBOX2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PICBOX2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PICBOX2.Location = new System.Drawing.Point(235, 12);
            this.PICBOX2.MinimumSize = new System.Drawing.Size(10, 15);
            this.PICBOX2.Name = "PICBOX2";
            this.PICBOX2.Size = new System.Drawing.Size(548, 528);
            this.PICBOX2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PICBOX2.TabIndex = 37;
            this.PICBOX2.TabStop = false;
            // 
            // Formnguon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.DISPLA);
            this.Controls.Add(this.RANGE);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.hien);
            this.Controls.Add(this.PICBOX2);
            this.Name = "Formnguon";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Formnguon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Formnguon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PICBOX2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label hien;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label RANGE;
        private System.Windows.Forms.Label DISPLA;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.PictureBox PICBOX2;
    }
}