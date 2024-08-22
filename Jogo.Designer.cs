using System.Windows.Forms;

namespace JogoDasDamas
{
    partial class Jogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jogo));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPontosJogador2 = new System.Windows.Forms.Label();
            this.lblPontosJogador1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNomeJogador2 = new System.Windows.Forms.Label();
            this.lblNomeJogador1 = new System.Windows.Forms.Label();
            this.JogadorAJogar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(40)))), ((int)(((byte)(20)))));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 712);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblPontosJogador2
            // 
            this.lblPontosJogador2.AutoSize = true;
            this.lblPontosJogador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontosJogador2.ForeColor = System.Drawing.Color.White;
            this.lblPontosJogador2.Location = new System.Drawing.Point(947, 139);
            this.lblPontosJogador2.Name = "lblPontosJogador2";
            this.lblPontosJogador2.Size = new System.Drawing.Size(69, 76);
            this.lblPontosJogador2.TabIndex = 5;
            this.lblPontosJogador2.Text = "0";
            // 
            // lblPontosJogador1
            // 
            this.lblPontosJogador1.AutoSize = true;
            this.lblPontosJogador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPontosJogador1.ForeColor = System.Drawing.Color.White;
            this.lblPontosJogador1.Location = new System.Drawing.Point(947, 422);
            this.lblPontosJogador1.Name = "lblPontosJogador1";
            this.lblPontosJogador1.Size = new System.Drawing.Size(69, 76);
            this.lblPontosJogador1.TabIndex = 6;
            this.lblPontosJogador1.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::JogoDasDamas.Properties.Resources.Black;
            this.pictureBox2.Location = new System.Drawing.Point(861, 422);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 78);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JogoDasDamas.Properties.Resources.White;
            this.pictureBox1.Location = new System.Drawing.Point(861, 139);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblNomeJogador2
            // 
            this.lblNomeJogador2.AutoSize = true;
            this.lblNomeJogador2.Font = new System.Drawing.Font("Segoe UI Black", 15F);
            this.lblNomeJogador2.ForeColor = System.Drawing.Color.White;
            this.lblNomeJogador2.Location = new System.Drawing.Point(861, 99);
            this.lblNomeJogador2.Name = "lblNomeJogador2";
            this.lblNomeJogador2.Size = new System.Drawing.Size(69, 28);
            this.lblNomeJogador2.TabIndex = 7;
            this.lblNomeJogador2.Text = "label1";
            // 
            // lblNomeJogador1
            // 
            this.lblNomeJogador1.AutoSize = true;
            this.lblNomeJogador1.Font = new System.Drawing.Font("Segoe UI Black", 15F);
            this.lblNomeJogador1.ForeColor = System.Drawing.Color.White;
            this.lblNomeJogador1.Location = new System.Drawing.Point(861, 381);
            this.lblNomeJogador1.Name = "lblNomeJogador1";
            this.lblNomeJogador1.Size = new System.Drawing.Size(69, 28);
            this.lblNomeJogador1.TabIndex = 8;
            this.lblNomeJogador1.Text = "label1";
            // 
            // JogadorAJogar
            // 
            this.JogadorAJogar.AutoSize = true;
            this.JogadorAJogar.Font = new System.Drawing.Font("Segoe UI Black", 15F);
            this.JogadorAJogar.ForeColor = System.Drawing.Color.White;
            this.JogadorAJogar.Location = new System.Drawing.Point(793, 13);
            this.JogadorAJogar.Name = "JogadorAJogar";
            this.JogadorAJogar.Size = new System.Drawing.Size(69, 28);
            this.JogadorAJogar.TabIndex = 9;
            this.JogadorAJogar.Text = "label1";
            // 
            // Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(1163, 736);
            this.Controls.Add(this.JogadorAJogar);
            this.Controls.Add(this.lblNomeJogador1);
            this.Controls.Add(this.lblNomeJogador2);
            this.Controls.Add(this.lblPontosJogador1);
            this.Controls.Add(this.lblPontosJogador2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1179, 775);
            this.MinimumSize = new System.Drawing.Size(1179, 775);
            this.Name = "Jogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo Das Damas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblPontosJogador2;
        private Label lblPontosJogador1;
        private Label lblNomeJogador2;
        private Label lblNomeJogador1;
        private Label JogadorAJogar;
    }
}

