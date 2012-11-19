namespace YAGUI_GESTION_CIRCUIT
{
    partial class EcranControle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_version_voiture = new System.Windows.Forms.Label();
            this.label_version_circuit = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.ImageCircuit = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Affichage_donnees_Case = new System.Windows.Forms.DataGridView();
            this.NUMERO_CASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLASSEMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COOR_X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COOR_Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADJACENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CASE_GAUCHE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CASE_DROITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CASE_ENFACE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CASE_MURET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Administration = new System.Windows.Forms.TabPage();
            this.Position_Voiture1 = new System.Windows.Forms.Label();
            this.ENF_V1 = new System.Windows.Forms.Button();
            this.GAU_V1 = new System.Windows.Forms.Button();
            this.DRO_V1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCircuit)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Affichage_donnees_Case)).BeginInit();
            this.Administration.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.Administration);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 393);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_version_voiture);
            this.tabPage1.Controls.Add(this.label_version_circuit);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "YAGUI - Version";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_version_voiture
            // 
            this.label_version_voiture.AutoSize = true;
            this.label_version_voiture.Location = new System.Drawing.Point(111, 60);
            this.label_version_voiture.Name = "label_version_voiture";
            this.label_version_voiture.Size = new System.Drawing.Size(78, 13);
            this.label_version_voiture.TabIndex = 3;
            this.label_version_voiture.Text = "Version Voiture";
            // 
            // label_version_circuit
            // 
            this.label_version_circuit.AutoSize = true;
            this.label_version_circuit.Location = new System.Drawing.Point(111, 27);
            this.label_version_circuit.Name = "label_version_circuit";
            this.label_version_circuit.Size = new System.Drawing.Size(74, 13);
            this.label_version_circuit.TabIndex = 2;
            this.label_version_circuit.Text = "Version Circuit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gestion_Voiture :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion_Circuit :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.ImageCircuit);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(536, 367);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "GSC - Image Circuit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            // 
            // ImageCircuit
            // 
            this.ImageCircuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImageCircuit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageCircuit.Location = new System.Drawing.Point(3, 3);
            this.ImageCircuit.Name = "ImageCircuit";
            this.ImageCircuit.Size = new System.Drawing.Size(530, 361);
            this.ImageCircuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageCircuit.TabIndex = 0;
            this.ImageCircuit.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Affichage_donnees_Case);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(536, 367);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "GSC - Données Cases";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Affichage_donnees_Case
            // 
            this.Affichage_donnees_Case.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Affichage_donnees_Case.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Affichage_donnees_Case.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Affichage_donnees_Case.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NUMERO_CASE,
            this.CLASSEMENT,
            this.COOR_X,
            this.COOR_Y,
            this.ADJACENTE,
            this.CASE_GAUCHE,
            this.CASE_DROITE,
            this.CASE_ENFACE,
            this.CASE_MURET});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Affichage_donnees_Case.DefaultCellStyle = dataGridViewCellStyle2;
            this.Affichage_donnees_Case.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Affichage_donnees_Case.Location = new System.Drawing.Point(3, 3);
            this.Affichage_donnees_Case.Name = "Affichage_donnees_Case";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Affichage_donnees_Case.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Affichage_donnees_Case.Size = new System.Drawing.Size(530, 361);
            this.Affichage_donnees_Case.TabIndex = 0;
            // 
            // NUMERO_CASE
            // 
            this.NUMERO_CASE.HeaderText = "NUMERO_CASE";
            this.NUMERO_CASE.Name = "NUMERO_CASE";
            this.NUMERO_CASE.ReadOnly = true;
            // 
            // CLASSEMENT
            // 
            this.CLASSEMENT.HeaderText = "CLASSEMENT";
            this.CLASSEMENT.Name = "CLASSEMENT";
            this.CLASSEMENT.ReadOnly = true;
            // 
            // COOR_X
            // 
            this.COOR_X.HeaderText = "COOR_X";
            this.COOR_X.Name = "COOR_X";
            this.COOR_X.ReadOnly = true;
            // 
            // COOR_Y
            // 
            this.COOR_Y.HeaderText = "COOR_Y";
            this.COOR_Y.Name = "COOR_Y";
            this.COOR_Y.ReadOnly = true;
            // 
            // ADJACENTE
            // 
            this.ADJACENTE.HeaderText = "ADJACENTE";
            this.ADJACENTE.Name = "ADJACENTE";
            this.ADJACENTE.ReadOnly = true;
            // 
            // CASE_GAUCHE
            // 
            this.CASE_GAUCHE.HeaderText = "CASE_GAUCHE";
            this.CASE_GAUCHE.Name = "CASE_GAUCHE";
            // 
            // CASE_DROITE
            // 
            this.CASE_DROITE.HeaderText = "CASE_DROITE";
            this.CASE_DROITE.Name = "CASE_DROITE";
            // 
            // CASE_ENFACE
            // 
            this.CASE_ENFACE.HeaderText = "CASE_ENFACE";
            this.CASE_ENFACE.Name = "CASE_ENFACE";
            // 
            // CASE_MURET
            // 
            this.CASE_MURET.HeaderText = "CASE_MURET";
            this.CASE_MURET.Name = "CASE_MURET";
            // 
            // Administration
            // 
            this.Administration.Controls.Add(this.Position_Voiture1);
            this.Administration.Controls.Add(this.ENF_V1);
            this.Administration.Controls.Add(this.GAU_V1);
            this.Administration.Controls.Add(this.DRO_V1);
            this.Administration.Location = new System.Drawing.Point(4, 22);
            this.Administration.Name = "Administration";
            this.Administration.Padding = new System.Windows.Forms.Padding(3);
            this.Administration.Size = new System.Drawing.Size(536, 367);
            this.Administration.TabIndex = 3;
            this.Administration.Text = "GSV - Tableau voiture";
            this.Administration.UseVisualStyleBackColor = true;
            // 
            // Position_Voiture1
            // 
            this.Position_Voiture1.AutoSize = true;
            this.Position_Voiture1.Location = new System.Drawing.Point(78, 156);
            this.Position_Voiture1.Name = "Position_Voiture1";
            this.Position_Voiture1.Size = new System.Drawing.Size(48, 13);
            this.Position_Voiture1.TabIndex = 3;
            this.Position_Voiture1.Text = "POS_V1";
            this.Position_Voiture1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ENF_V1
            // 
            this.ENF_V1.Location = new System.Drawing.Point(78, 77);
            this.ENF_V1.Name = "ENF_V1";
            this.ENF_V1.Size = new System.Drawing.Size(35, 35);
            this.ENF_V1.TabIndex = 2;
            this.ENF_V1.Text = "^";
            this.ENF_V1.UseVisualStyleBackColor = true;
            this.ENF_V1.Click += new System.EventHandler(this.ENF_V1_Click);
            // 
            // GAU_V1
            // 
            this.GAU_V1.Location = new System.Drawing.Point(44, 118);
            this.GAU_V1.Name = "GAU_V1";
            this.GAU_V1.Size = new System.Drawing.Size(35, 35);
            this.GAU_V1.TabIndex = 1;
            this.GAU_V1.Text = "<=";
            this.GAU_V1.UseVisualStyleBackColor = true;
            this.GAU_V1.Click += new System.EventHandler(this.GAU_V1_Click);
            // 
            // DRO_V1
            // 
            this.DRO_V1.Location = new System.Drawing.Point(113, 118);
            this.DRO_V1.Name = "DRO_V1";
            this.DRO_V1.Size = new System.Drawing.Size(35, 35);
            this.DRO_V1.TabIndex = 0;
            this.DRO_V1.Text = "=>";
            this.DRO_V1.UseVisualStyleBackColor = true;
            this.DRO_V1.Click += new System.EventHandler(this.DRO_V1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(536, 367);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "TEST XNA";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.affichageToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // ouToolStripMenuItem
            // 
            this.ouToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLCircuitToolStripMenuItem});
            this.ouToolStripMenuItem.Name = "ouToolStripMenuItem";
            this.ouToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ouToolStripMenuItem.Text = "Gestion Cricuit";
            // 
            // xMLCircuitToolStripMenuItem
            // 
            this.xMLCircuitToolStripMenuItem.Name = "xMLCircuitToolStripMenuItem";
            this.xMLCircuitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.xMLCircuitToolStripMenuItem.Text = "XML Circuit";
            this.xMLCircuitToolStripMenuItem.Click += new System.EventHandler(this.xMLCircuitToolStripMenuItem_Click);
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem});
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "Affichage";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aProposToolStripMenuItem1
            // 
            this.aProposToolStripMenuItem1.Checked = true;
            this.aProposToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aProposToolStripMenuItem1.Name = "aProposToolStripMenuItem1";
            this.aProposToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.aProposToolStripMenuItem1.Text = "A propos";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.aProposToolStripMenuItem.Text = "A propos";
            // 
            // EcranControle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 417);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EcranControle";
            this.Text = "FormulaWeb X";
            this.Load += new System.EventHandler(this.EcranControle_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCircuit)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Affichage_donnees_Case)).EndInit();
            this.Administration.ResumeLayout(false);
            this.Administration.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox ImageCircuit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLCircuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.DataGridView Affichage_donnees_Case;
        private System.Windows.Forms.TabPage Administration;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO_CASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLASSEMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COOR_X;
        private System.Windows.Forms.DataGridViewTextBoxColumn COOR_Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADJACENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CASE_GAUCHE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CASE_DROITE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CASE_ENFACE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CASE_MURET;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label_version_voiture;
        private System.Windows.Forms.Label label_version_circuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GAU_V1;
        private System.Windows.Forms.Button DRO_V1;
        private System.Windows.Forms.Label Position_Voiture1;
        private System.Windows.Forms.Button ENF_V1;


    }
}

