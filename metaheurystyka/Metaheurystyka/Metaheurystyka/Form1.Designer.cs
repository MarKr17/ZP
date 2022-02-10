
namespace Metaheurystyka
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInstancja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNazwa = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewPopulacja = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxMutations = new System.Windows.Forms.TextBox();
            this.textBoxIteracje = new System.Windows.Forms.TextBox();
            this.textBoxCrossing = new System.Windows.Forms.TextBox();
            this.textBoxPopulacja = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulacja)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1271, 772);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBoxP);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxInstancja);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxNazwa);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1263, 739);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Start";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 62);
            this.button1.TabIndex = 11;
            this.button1.Text = "Wczytaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dłługość rozwiązania";
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(6, 240);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(100, 26);
            this.textBoxP.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Instancja";
            // 
            // textBoxInstancja
            // 
            this.textBoxInstancja.Location = new System.Drawing.Point(6, 146);
            this.textBoxInstancja.Name = "textBoxInstancja";
            this.textBoxInstancja.Size = new System.Drawing.Size(510, 26);
            this.textBoxInstancja.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nazwa instancji";
            // 
            // textBoxNazwa
            // 
            this.textBoxNazwa.Location = new System.Drawing.Point(6, 57);
            this.textBoxNazwa.Name = "textBoxNazwa";
            this.textBoxNazwa.Size = new System.Drawing.Size(297, 26);
            this.textBoxNazwa.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonRefresh);
            this.tabPage2.Controls.Add(this.dataGridViewPopulacja);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1263, 739);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Populacja";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPopulacja
            // 
            this.dataGridViewPopulacja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPopulacja.Location = new System.Drawing.Point(14, 69);
            this.dataGridViewPopulacja.Name = "dataGridViewPopulacja";
            this.dataGridViewPopulacja.RowHeadersWidth = 62;
            this.dataGridViewPopulacja.RowTemplate.Height = 28;
            this.dataGridViewPopulacja.Size = new System.Drawing.Size(601, 424);
            this.dataGridViewPopulacja.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Populacja";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.textBoxMutations);
            this.tabPage3.Controls.Add(this.textBoxIteracje);
            this.tabPage3.Controls.Add(this.textBoxCrossing);
            this.tabPage3.Controls.Add(this.textBoxPopulacja);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1263, 739);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Parametry";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Prawdopodobieństwo krzyżowania";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Prawdopodobieństwo mutacji";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Cykle Reprodukcyjne";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Wielkość Populacji";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(278, 83);
            this.button2.TabIndex = 5;
            this.button2.Text = "Zastosuj Parametry";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxMutations
            // 
            this.textBoxMutations.Location = new System.Drawing.Point(10, 165);
            this.textBoxMutations.Name = "textBoxMutations";
            this.textBoxMutations.Size = new System.Drawing.Size(100, 26);
            this.textBoxMutations.TabIndex = 4;
            this.textBoxMutations.Text = "0,01";
            // 
            // textBoxIteracje
            // 
            this.textBoxIteracje.Location = new System.Drawing.Point(312, 74);
            this.textBoxIteracje.Name = "textBoxIteracje";
            this.textBoxIteracje.Size = new System.Drawing.Size(100, 26);
            this.textBoxIteracje.TabIndex = 3;
            this.textBoxIteracje.Text = "100";
            // 
            // textBoxCrossing
            // 
            this.textBoxCrossing.Location = new System.Drawing.Point(312, 165);
            this.textBoxCrossing.Name = "textBoxCrossing";
            this.textBoxCrossing.Size = new System.Drawing.Size(100, 26);
            this.textBoxCrossing.TabIndex = 2;
            this.textBoxCrossing.Text = "0,05";
            // 
            // textBoxPopulacja
            // 
            this.textBoxPopulacja.Location = new System.Drawing.Point(10, 74);
            this.textBoxPopulacja.Name = "textBoxPopulacja";
            this.textBoxPopulacja.Size = new System.Drawing.Size(100, 26);
            this.textBoxPopulacja.TabIndex = 0;
            this.textBoxPopulacja.Text = "20";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonStart);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1263, 739);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Obliczanie";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(10, 14);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(204, 71);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Rozpocznij";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(740, 69);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(224, 59);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Odświerz";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 769);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Metaheurystyka";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPopulacja)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxInstancja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNazwa;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewPopulacja;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxMutations;
        private System.Windows.Forms.TextBox textBoxIteracje;
        private System.Windows.Forms.TextBox textBoxCrossing;
        private System.Windows.Forms.TextBox textBoxPopulacja;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonRefresh;
    }
}

