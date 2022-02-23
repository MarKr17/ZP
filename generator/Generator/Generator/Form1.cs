using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator
{
    public partial class Form1 : Form
    {
        Instancje instancje;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k=10;
            int m = 20;
            int b= 1;
            int ile = 1;
            if (textBoxK.Text!="")
            {
                k = Int32.Parse(textBoxK.Text);
            }
            if (textBoxM.Text != "")
            {
                m = Int32.Parse(textBoxM.Text);
            }
            if(textBoxMis.Text!="")
            {
                b= Int32.Parse(textBoxMis.Text);
            }
            if (textBoxIle.Text != "")
            {
                ile = Int32.Parse(textBoxIle.Text);
            }
            instancje = new Instancje(k, m, b, ile);

            textBoxMR.Text = string.Join(",", instancje.Instancje_lista[0].P.ToArray());
            //textBoxD.Text = instancje.size_D.ToString();
            textBoxIns.Text= string.Join(",", instancje.Instancje_lista[0].D.ToArray());

            textBoxBledy.Text= string.Join(",", instancje.Instancje_lista[0].D_mis.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Saver.Zapisz_wszystkie(instancje, textBox_nazwa.Text, textBoxFolder.Text);
        }
    }
}
