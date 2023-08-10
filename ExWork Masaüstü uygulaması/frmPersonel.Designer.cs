namespace Exwork
{
    partial class frmPersonel
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGorevTakibi = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.icerikPaneli = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.icerikPaneli.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Exwork.Properties.Resources.exwork_top;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(1297, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = " Çıkış Yap";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // btnGorevTakibi
            // 
            this.btnGorevTakibi.BackgroundImage = global::Exwork.Properties.Resources.gorevTakip;
            this.btnGorevTakibi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGorevTakibi.FlatAppearance.BorderSize = 0;
            this.btnGorevTakibi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGorevTakibi.Location = new System.Drawing.Point(229, 93);
            this.btnGorevTakibi.Name = "btnGorevTakibi";
            this.btnGorevTakibi.Size = new System.Drawing.Size(220, 114);
            this.btnGorevTakibi.TabIndex = 21;
            this.btnGorevTakibi.UseVisualStyleBackColor = true;
            this.btnGorevTakibi.Click += new System.EventHandler(this.btnGorevTakibi_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackgroundImage = global::Exwork.Properties.Resources.ayarlar;
            this.btnAyarlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAyarlar.FlatAppearance.BorderSize = 0;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Location = new System.Drawing.Point(455, 93);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(220, 114);
            this.btnAyarlar.TabIndex = 25;
            this.btnAyarlar.UseVisualStyleBackColor = true;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // icerikPaneli
            // 
            this.icerikPaneli.BackColor = System.Drawing.Color.Wheat;
            this.icerikPaneli.Controls.Add(this.label8);
            this.icerikPaneli.Location = new System.Drawing.Point(7, 213);
            this.icerikPaneli.Name = "icerikPaneli";
            this.icerikPaneli.Size = new System.Drawing.Size(1350, 575);
            this.icerikPaneli.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(462, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(581, 73);
            this.label8.TabIndex = 0;
            this.label8.Text = "İÇERİK GELECEK";
            // 
            // frmPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(164)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.ControlBox = false;
            this.Controls.Add(this.icerikPaneli);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnGorevTakibi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPersonel";
            this.Text = "frmPersonel";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPersonel_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.icerikPaneli.ResumeLayout(false);
            this.icerikPaneli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGorevTakibi;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Panel icerikPaneli;
        private System.Windows.Forms.Label label8;
    }
}