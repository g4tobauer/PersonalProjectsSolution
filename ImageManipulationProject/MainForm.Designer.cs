namespace ImageManipulationProject
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
            this.pnl_Draw = new System.Windows.Forms.Panel();
            this.btn_ProcuraImagem = new System.Windows.Forms.Button();
            this.btn_AddImage = new System.Windows.Forms.Button();
            this.btn_SubImage = new System.Windows.Forms.Button();
            this.btn_SaveImage = new System.Windows.Forms.Button();
            this.btn_Div = new System.Windows.Forms.Button();
            this.btn_Mult = new System.Windows.Forms.Button();
            this.chk_ResetColor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pnl_Draw
            // 
            this.pnl_Draw.Location = new System.Drawing.Point(12, 12);
            this.pnl_Draw.Name = "pnl_Draw";
            this.pnl_Draw.Size = new System.Drawing.Size(765, 498);
            this.pnl_Draw.TabIndex = 0;
            // 
            // btn_ProcuraImagem
            // 
            this.btn_ProcuraImagem.Location = new System.Drawing.Point(578, 527);
            this.btn_ProcuraImagem.Name = "btn_ProcuraImagem";
            this.btn_ProcuraImagem.Size = new System.Drawing.Size(199, 23);
            this.btn_ProcuraImagem.TabIndex = 1;
            this.btn_ProcuraImagem.Text = "Procura Imagem";
            this.btn_ProcuraImagem.UseVisualStyleBackColor = true;
            this.btn_ProcuraImagem.Click += new System.EventHandler(this.btn_ProcuraImagem_Click);
            // 
            // btn_AddImage
            // 
            this.btn_AddImage.Location = new System.Drawing.Point(12, 527);
            this.btn_AddImage.Name = "btn_AddImage";
            this.btn_AddImage.Size = new System.Drawing.Size(85, 23);
            this.btn_AddImage.TabIndex = 2;
            this.btn_AddImage.Text = "ADD";
            this.btn_AddImage.UseVisualStyleBackColor = true;
            this.btn_AddImage.Click += new System.EventHandler(this.btn_AddImage_Click);
            // 
            // btn_SubImage
            // 
            this.btn_SubImage.Location = new System.Drawing.Point(103, 527);
            this.btn_SubImage.Name = "btn_SubImage";
            this.btn_SubImage.Size = new System.Drawing.Size(85, 23);
            this.btn_SubImage.TabIndex = 3;
            this.btn_SubImage.Text = "SUB";
            this.btn_SubImage.UseVisualStyleBackColor = true;
            this.btn_SubImage.Click += new System.EventHandler(this.btn_SubImage_Click);
            // 
            // btn_SaveImage
            // 
            this.btn_SaveImage.Location = new System.Drawing.Point(487, 527);
            this.btn_SaveImage.Name = "btn_SaveImage";
            this.btn_SaveImage.Size = new System.Drawing.Size(85, 23);
            this.btn_SaveImage.TabIndex = 6;
            this.btn_SaveImage.Text = "SAVE";
            this.btn_SaveImage.UseVisualStyleBackColor = true;
            this.btn_SaveImage.Click += new System.EventHandler(this.btn_SaveImage_Click);
            // 
            // btn_Div
            // 
            this.btn_Div.Location = new System.Drawing.Point(285, 527);
            this.btn_Div.Name = "btn_Div";
            this.btn_Div.Size = new System.Drawing.Size(85, 23);
            this.btn_Div.TabIndex = 8;
            this.btn_Div.Text = "DIV";
            this.btn_Div.UseVisualStyleBackColor = true;
            this.btn_Div.Click += new System.EventHandler(this.btn_Div_Click);
            // 
            // btn_Mult
            // 
            this.btn_Mult.Location = new System.Drawing.Point(194, 527);
            this.btn_Mult.Name = "btn_Mult";
            this.btn_Mult.Size = new System.Drawing.Size(85, 23);
            this.btn_Mult.TabIndex = 7;
            this.btn_Mult.Text = "MULT";
            this.btn_Mult.UseVisualStyleBackColor = true;
            this.btn_Mult.Click += new System.EventHandler(this.btn_Mult_Click);
            // 
            // chk_ResetColor
            // 
            this.chk_ResetColor.AutoSize = true;
            this.chk_ResetColor.Location = new System.Drawing.Point(387, 531);
            this.chk_ResetColor.Name = "chk_ResetColor";
            this.chk_ResetColor.Size = new System.Drawing.Size(82, 17);
            this.chk_ResetColor.TabIndex = 9;
            this.chk_ResetColor.Text = "Resetar Cor";
            this.chk_ResetColor.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 562);
            this.Controls.Add(this.chk_ResetColor);
            this.Controls.Add(this.btn_Div);
            this.Controls.Add(this.btn_Mult);
            this.Controls.Add(this.btn_SaveImage);
            this.Controls.Add(this.btn_SubImage);
            this.Controls.Add(this.btn_AddImage);
            this.Controls.Add(this.btn_ProcuraImagem);
            this.Controls.Add(this.pnl_Draw);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Draw;
        private System.Windows.Forms.Button btn_ProcuraImagem;
        private System.Windows.Forms.Button btn_AddImage;
        private System.Windows.Forms.Button btn_SubImage;
        private System.Windows.Forms.Button btn_SaveImage;
        private System.Windows.Forms.Button btn_Div;
        private System.Windows.Forms.Button btn_Mult;
        private System.Windows.Forms.CheckBox chk_ResetColor;
    }
}