namespace RimOptiList
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bazaDanychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajUsuńModyfikujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyszukajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontaktToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przewódToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustawieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bazaDanychToolStripMenuItem,
            this.ustawieniaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(213, 1101);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bazaDanychToolStripMenuItem
            // 
            this.bazaDanychToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajUsuńModyfikujToolStripMenuItem,
            this.wyszukajToolStripMenuItem});
            this.bazaDanychToolStripMenuItem.Name = "bazaDanychToolStripMenuItem";
            this.bazaDanychToolStripMenuItem.Size = new System.Drawing.Size(200, 45);
            this.bazaDanychToolStripMenuItem.Text = "Baza danych";
            // 
            // dodajUsuńModyfikujToolStripMenuItem
            // 
            this.dodajUsuńModyfikujToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kontaktToolStripMenuItem,
            this.przewódToolStripMenuItem,
            this.sealToolStripMenuItem});
            this.dodajUsuńModyfikujToolStripMenuItem.Name = "dodajUsuńModyfikujToolStripMenuItem";
            this.dodajUsuńModyfikujToolStripMenuItem.Size = new System.Drawing.Size(512, 54);
            this.dodajUsuńModyfikujToolStripMenuItem.Text = "dodaj / usuń / modyfikuj";
            // 
            // wyszukajToolStripMenuItem
            // 
            this.wyszukajToolStripMenuItem.Name = "wyszukajToolStripMenuItem";
            this.wyszukajToolStripMenuItem.Size = new System.Drawing.Size(512, 54);
            this.wyszukajToolStripMenuItem.Text = "wyszukaj";
            // 
            // kontaktToolStripMenuItem
            // 
            this.kontaktToolStripMenuItem.Name = "kontaktToolStripMenuItem";
            this.kontaktToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.kontaktToolStripMenuItem.Text = "kontakt";
            // 
            // przewódToolStripMenuItem
            // 
            this.przewódToolStripMenuItem.Name = "przewódToolStripMenuItem";
            this.przewódToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.przewódToolStripMenuItem.Text = "przewód";
            // 
            // sealToolStripMenuItem
            // 
            this.sealToolStripMenuItem.Name = "sealToolStripMenuItem";
            this.sealToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.sealToolStripMenuItem.Text = "seal";
            // 
            // ustawieniaToolStripMenuItem
            // 
            this.ustawieniaToolStripMenuItem.Name = "ustawieniaToolStripMenuItem";
            this.ustawieniaToolStripMenuItem.Size = new System.Drawing.Size(200, 45);
            this.ustawieniaToolStripMenuItem.Text = "Ustawienia";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(834, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 155);
            this.button1.TabIndex = 1;
            this.button1.Text = "Załaduj listę połączeń";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2004, 1101);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RimOptiList";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bazaDanychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajUsuńModyfikujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kontaktToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przewódToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyszukajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustawieniaToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
    }
}

