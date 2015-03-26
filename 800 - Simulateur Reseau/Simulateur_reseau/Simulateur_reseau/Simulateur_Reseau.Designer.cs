namespace Simulateur_reseau
{
    partial class Simulateur_Reseau
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Japan_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Japan_button
            // 
            this.Japan_button.Location = new System.Drawing.Point(225, 496);
            this.Japan_button.Name = "Japan_button";
            this.Japan_button.Size = new System.Drawing.Size(167, 23);
            this.Japan_button.TabIndex = 0;
            this.Japan_button.Text = "Japan button (sers à rien) !";
            this.Japan_button.UseVisualStyleBackColor = true;
            this.Japan_button.Click += new System.EventHandler(this.Japan_button_Click);
            // 
            // Simulateur_Reseau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 531);
            this.Controls.Add(this.Japan_button);
            this.Name = "Simulateur_Reseau";
            this.Text = "Simulateur_reseau_FWEB";
            this.Load += new System.EventHandler(this.Simulateur_Reseau_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Japan_button;
    }
}

