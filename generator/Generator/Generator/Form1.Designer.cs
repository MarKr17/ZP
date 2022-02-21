
namespace Generator
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
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIns = new System.Windows.Forms.TextBox();
            this.textBoxBledy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMis = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxIle = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_nazwa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(32, 78);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(125, 26);
            this.textBoxK.TabIndex = 0;
            this.textBoxK.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ilość miejsc restrykcyjnych (K)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rozmiar instancji";
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(32, 145);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(100, 26);
            this.textBoxD.TabIndex = 4;
            this.textBoxD.Text = "10";
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(293, 78);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(100, 26);
            this.textBoxM.TabIndex = 5;
            this.textBoxM.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zakres górny";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Miejsca restrykcyjne (P)";
            // 
            // textBoxMR
            // 
            this.textBoxMR.Location = new System.Drawing.Point(31, 229);
            this.textBoxMR.Name = "textBoxMR";
            this.textBoxMR.Size = new System.Drawing.Size(189, 26);
            this.textBoxMR.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Instancja(D)";
            // 
            // textBoxIns
            // 
            this.textBoxIns.Location = new System.Drawing.Point(293, 229);
            this.textBoxIns.Name = "textBoxIns";
            this.textBoxIns.Size = new System.Drawing.Size(220, 26);
            this.textBoxIns.TabIndex = 10;
            // 
            // textBoxBledy
            // 
            this.textBoxBledy.Location = new System.Drawing.Point(587, 229);
            this.textBoxBledy.Name = "textBoxBledy";
            this.textBoxBledy.Size = new System.Drawing.Size(219, 26);
            this.textBoxBledy.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Instancja z błędami(D)";
            // 
            // textBoxMis
            // 
            this.textBoxMis.Location = new System.Drawing.Point(293, 145);
            this.textBoxMis.Name = "textBoxMis";
            this.textBoxMis.Size = new System.Drawing.Size(100, 26);
            this.textBoxMis.TabIndex = 13;
            this.textBoxMis.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ilośc błędów";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(460, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ilość instancji";
            // 
            // textBoxIle
            // 
            this.textBoxIle.Location = new System.Drawing.Point(463, 78);
            this.textBoxIle.Name = "textBoxIle";
            this.textBoxIle.Size = new System.Drawing.Size(100, 26);
            this.textBoxIle.TabIndex = 16;
            this.textBoxIle.Text = "1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 45);
            this.button2.TabIndex = 17;
            this.button2.Text = "Zapisz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_nazwa
            // 
            this.textBox_nazwa.Location = new System.Drawing.Point(31, 326);
            this.textBox_nazwa.Name = "textBox_nazwa";
            this.textBox_nazwa.Size = new System.Drawing.Size(189, 26);
            this.textBox_nazwa.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Nazwa Pilku";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Folder";
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(297, 326);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(216, 26);
            this.textBoxFolder.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_nazwa);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxIle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMis);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxBledy);
            this.Controls.Add(this.textBoxIns);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxMR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxK);
            this.Name = "Form1";
            this.Text = "Generator instancji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIns;
        private System.Windows.Forms.TextBox textBoxBledy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMis;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxIle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_nazwa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxFolder;
    }
}

