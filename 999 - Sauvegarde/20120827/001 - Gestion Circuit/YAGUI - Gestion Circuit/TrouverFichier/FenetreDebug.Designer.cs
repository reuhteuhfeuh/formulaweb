namespace YAGUI_GESTION_CIRCUIT
{
    partial class FenetreDebug
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
            this.Fenetre_Debug = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Fenetre_Debug
            // 
            this.Fenetre_Debug.AcceptsReturn = true;
            this.Fenetre_Debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fenetre_Debug.Location = new System.Drawing.Point(0, 0);
            this.Fenetre_Debug.Multiline = true;
            this.Fenetre_Debug.Name = "Fenetre_Debug";
            this.Fenetre_Debug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Fenetre_Debug.Size = new System.Drawing.Size(284, 262);
            this.Fenetre_Debug.TabIndex = 0;
            // 
            // FenetreDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.Fenetre_Debug);
            this.Name = "FenetreDebug";
            this.Text = "Fenetre de debug";
            this.Load += new System.EventHandler(this.Debug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Fenetre_Debug;
    }
}