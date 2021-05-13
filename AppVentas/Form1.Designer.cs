
namespace AppVentas
{
    partial class FrmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnEntrar = new System.Windows.Forms.Button();
            this.LblGmail = new System.Windows.Forms.Label();
            this.LblPass = new System.Windows.Forms.Label();
            this.TxtGmail = new System.Windows.Forms.TextBox();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnEntrar
            // 
            this.BtnEntrar.Location = new System.Drawing.Point(86, 149);
            this.BtnEntrar.Name = "BtnEntrar";
            this.BtnEntrar.Size = new System.Drawing.Size(75, 23);
            this.BtnEntrar.TabIndex = 0;
            this.BtnEntrar.Text = "Entrar";
            this.BtnEntrar.UseVisualStyleBackColor = true;
            this.BtnEntrar.Click += new System.EventHandler(this.BtnEntrar_Click);
            // 
            // LblGmail
            // 
            this.LblGmail.AutoSize = true;
            this.LblGmail.Location = new System.Drawing.Point(15, 50);
            this.LblGmail.Name = "LblGmail";
            this.LblGmail.Size = new System.Drawing.Size(33, 13);
            this.LblGmail.TabIndex = 1;
            this.LblGmail.Text = "Gmail";
            // 
            // LblPass
            // 
            this.LblPass.AutoSize = true;
            this.LblPass.Location = new System.Drawing.Point(15, 98);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(53, 13);
            this.LblPass.TabIndex = 2;
            this.LblPass.Text = "Password";
            // 
            // TxtGmail
            // 
            this.TxtGmail.Location = new System.Drawing.Point(74, 50);
            this.TxtGmail.Name = "TxtGmail";
            this.TxtGmail.Size = new System.Drawing.Size(117, 20);
            this.TxtGmail.TabIndex = 3;
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(74, 98);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(117, 20);
            this.TxtPass.TabIndex = 4;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 212);
            this.Controls.Add(this.TxtPass);
            this.Controls.Add(this.TxtGmail);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.LblGmail);
            this.Controls.Add(this.BtnEntrar);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEntrar;
        private System.Windows.Forms.Label LblGmail;
        private System.Windows.Forms.Label LblPass;
        private System.Windows.Forms.TextBox TxtGmail;
        private System.Windows.Forms.TextBox TxtPass;
    }
}

