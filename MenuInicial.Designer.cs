namespace JogoDasDamas
{
    partial class MenuInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuInicial));
            this.label1 = new System.Windows.Forms.Label();
            this.tbNomeJogador1 = new System.Windows.Forms.TextBox();
            this.tbNomeJogador2 = new System.Windows.Forms.TextBox();
            this.btnJogar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(146)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Jogador 1";
            // 
            // tbNomeJogador1
            // 
            this.tbNomeJogador1.Location = new System.Drawing.Point(17, 58);
            this.tbNomeJogador1.Name = "tbNomeJogador1";
            this.tbNomeJogador1.Size = new System.Drawing.Size(190, 20);
            this.tbNomeJogador1.TabIndex = 2;
            // 
            // tbNomeJogador2
            // 
            this.tbNomeJogador2.Location = new System.Drawing.Point(292, 58);
            this.tbNomeJogador2.Name = "tbNomeJogador2";
            this.tbNomeJogador2.Size = new System.Drawing.Size(202, 20);
            this.tbNomeJogador2.TabIndex = 3;
            // 
            // btnJogar
            // 
            this.btnJogar.Font = new System.Drawing.Font("Lucida Bright", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogar.Location = new System.Drawing.Point(37, 389);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(93, 34);
            this.btnJogar.TabIndex = 4;
            this.btnJogar.Text = "Jogar";
            this.btnJogar.UseVisualStyleBackColor = true;
            this.btnJogar.Click += new System.EventHandler(this.btnJogar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(146)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(287, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nome do Jogador 2";
            // 
            // btnHistorico
            // 
            this.btnHistorico.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorico.Location = new System.Drawing.Point(362, 389);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(94, 34);
            this.btnHistorico.TabIndex = 7;
            this.btnHistorico.Text = "Historico";
            this.btnHistorico.UseVisualStyleBackColor = true;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // MenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JogoDasDamas.Properties.Resources.LogoDamas;
            this.ClientSize = new System.Drawing.Size(506, 450);
            this.Controls.Add(this.btnHistorico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnJogar);
            this.Controls.Add(this.tbNomeJogador2);
            this.Controls.Add(this.tbNomeJogador1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(522, 489);
            this.MinimumSize = new System.Drawing.Size(522, 489);
            this.Name = "MenuInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogo Das Damas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNomeJogador1;
        private System.Windows.Forms.TextBox tbNomeJogador2;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHistorico;
    }
}