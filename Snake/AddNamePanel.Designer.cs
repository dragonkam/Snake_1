namespace SnakeGame
{
    partial class AddNamePanel
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

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.description = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.scoresLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(22, 53);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(58, 13);
            this.description.TabIndex = 0;
            this.description.Text = "description";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 2;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(25, 76);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(98, 23);
            this.ok.TabIndex = 3;
            this.ok.Text = "Ok !!";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // scoresLabel
            // 
            this.scoresLabel.AutoSize = true;
            this.scoresLabel.Location = new System.Drawing.Point(244, 53);
            this.scoresLabel.Name = "scoresLabel";
            this.scoresLabel.Size = new System.Drawing.Size(35, 13);
            this.scoresLabel.TabIndex = 4;
            this.scoresLabel.Text = "label1";
            // 
            // AddNamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.scoresLabel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.description);
            this.Location = new System.Drawing.Point(100, 150);
            this.Name = "AddNamePanel";
            this.Size = new System.Drawing.Size(338, 142);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label description;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label scoresLabel;
    }
}
