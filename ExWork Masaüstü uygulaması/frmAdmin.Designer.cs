namespace Exwork
{
    partial class frmAdmin
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
            this.label2 = new System.Windows.Forms.Label();
            this.icerikPaneli = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btnPersonelAyarları = new System.Windows.Forms.Button();
            this.btnAjandam = new System.Windows.Forms.Button();
            this.btnGorevTakibi = new System.Windows.Forms.Button();
            this.btnGorevVer = new System.Windows.Forms.Button();
            this.btnGenel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.yoneticiMenu = new System.Windows.Forms.Panel();
            this.icerikPaneli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.yoneticiMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(40, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "GÖREV VER";
            // 
            // icerikPaneli
            // 
            this.icerikPaneli.BackColor = System.Drawing.Color.Wheat;
            this.icerikPaneli.Controls.Add(this.label8);
            this.icerikPaneli.Location = new System.Drawing.Point(7, 213);
            this.icerikPaneli.Name = "icerikPaneli";
            this.icerikPaneli.Size = new System.Drawing.Size(1350, 575);
            this.icerikPaneli.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(462, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(566, 72);
            this.label8.TabIndex = 0;
            this.label8.Text = "İÇERİK GELECEK";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(1283, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = " Çıkış Yap";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackgroundImage = global::Exwork.Properties.Resources.ayarlar;
            this.btnAyarlar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAyarlar.FlatAppearance.BorderSize = 0;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Location = new System.Drawing.Point(687, 93);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(220, 114);
            this.btnAyarlar.TabIndex = 24;
            this.btnAyarlar.UseVisualStyleBackColor = true;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // btnPersonelAyarları
            // 
            this.btnPersonelAyarları.BackgroundImage = global::Exwork.Properties.Resources.uyeekle;
            this.btnPersonelAyarları.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPersonelAyarları.FlatAppearance.BorderSize = 0;
            this.btnPersonelAyarları.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonelAyarları.Location = new System.Drawing.Point(0, 0);
            this.btnPersonelAyarları.Name = "btnPersonelAyarları";
            this.btnPersonelAyarları.Size = new System.Drawing.Size(220, 114);
            this.btnPersonelAyarları.TabIndex = 23;
            this.btnPersonelAyarları.UseVisualStyleBackColor = true;
            this.btnPersonelAyarları.Click += new System.EventHandler(this.btnPersonelAyarları_Click);
            // 
            // btnAjandam
            // 
            this.btnAjandam.BackgroundImage = global::Exwork.Properties.Resources.ajandam;
            this.btnAjandam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAjandam.FlatAppearance.BorderSize = 0;
            this.btnAjandam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjandam.Location = new System.Drawing.Point(235, 93);
            this.btnAjandam.Name = "btnAjandam";
            this.btnAjandam.Size = new System.Drawing.Size(220, 114);
            this.btnAjandam.TabIndex = 22;
            this.btnAjandam.UseVisualStyleBackColor = true;
            this.btnAjandam.Click += new System.EventHandler(this.btnAjandam_Click);
            // 
            // btnGorevTakibi
            // 
            this.btnGorevTakibi.BackgroundImage = global::Exwork.Properties.Resources.gorevTakip;
            this.btnGorevTakibi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGorevTakibi.FlatAppearance.BorderSize = 0;
            this.btnGorevTakibi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGorevTakibi.Location = new System.Drawing.Point(461, 93);
            this.btnGorevTakibi.Name = "btnGorevTakibi";
            this.btnGorevTakibi.Size = new System.Drawing.Size(220, 114);
            this.btnGorevTakibi.TabIndex = 20;
            this.btnGorevTakibi.UseVisualStyleBackColor = true;
            this.btnGorevTakibi.Click += new System.EventHandler(this.btnGorevTakibi_Click_1);
            // 
            // btnGorevVer
            // 
            this.btnGorevVer.BackgroundImage = global::Exwork.Properties.Resources.gorevver;
            this.btnGorevVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGorevVer.FlatAppearance.BorderSize = 0;
            this.btnGorevVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGorevVer.Location = new System.Drawing.Point(226, 0);
            this.btnGorevVer.Name = "btnGorevVer";
            this.btnGorevVer.Size = new System.Drawing.Size(220, 114);
            this.btnGorevVer.TabIndex = 15;
            this.btnGorevVer.UseVisualStyleBackColor = true;
            this.btnGorevVer.Click += new System.EventHandler(this.btnGorevVer_Click);
            // 
            // btnGenel
            // 
            this.btnGenel.BackgroundImage = global::Exwork.Properties.Resources.genel;
            this.btnGenel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGenel.FlatAppearance.BorderSize = 0;
            this.btnGenel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenel.Location = new System.Drawing.Point(7, 93);
            this.btnGenel.Name = "btnGenel";
            this.btnGenel.Size = new System.Drawing.Size(220, 114);
            this.btnGenel.TabIndex = 13;
            this.btnGenel.UseVisualStyleBackColor = true;
            this.btnGenel.Click += new System.EventHandler(this.btnGenel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Exwork.Properties.Resources.exwork_top;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Exwork.Properties.Resources.to_do_list;
            this.pictureBox3.Location = new System.Drawing.Point(58, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // yoneticiMenu
            // 
            this.yoneticiMenu.BackColor = System.Drawing.Color.Transparent;
            this.yoneticiMenu.Controls.Add(this.btnGorevVer);
            this.yoneticiMenu.Controls.Add(this.btnPersonelAyarları);
            this.yoneticiMenu.Location = new System.Drawing.Point(913, 93);
            this.yoneticiMenu.Name = "yoneticiMenu";
            this.yoneticiMenu.Size = new System.Drawing.Size(579, 114);
            this.yoneticiMenu.TabIndex = 25;
            this.yoneticiMenu.Visible = false;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.yoneticiMenu);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnAjandam);
            this.Controls.Add(this.btnGorevTakibi);
            this.Controls.Add(this.btnGenel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.icerikPaneli);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdmin";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.icerikPaneli.ResumeLayout(false);
            this.icerikPaneli.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.yoneticiMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel icerikPaneli;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGenel;
        private System.Windows.Forms.Button btnGorevVer;
        private System.Windows.Forms.Button btnGorevTakibi;
        private System.Windows.Forms.Button btnAjandam;
        private System.Windows.Forms.Button btnPersonelAyarları;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Panel yoneticiMenu;
    }
}