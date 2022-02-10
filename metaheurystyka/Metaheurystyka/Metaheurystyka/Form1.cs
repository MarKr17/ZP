using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metaheurystyka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Global.crossing_prob = 0.01;
            Global.mutation_prob = 0.05;
            Global.iteracje_max = 100;
            Global.population_size = 20;
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nazwa;
            if (textBoxNazwa.Text != null)
            {
                nazwa = textBoxNazwa.Text;
                Wczytywanie_instancji.Wczytywanie(nazwa);


                try
                {
                    textBoxInstancja.Text = string.Join(",", Global.instancja.Lista.ToArray());

                    textBoxP.Text = Global.Dlugosc_rozwiazania.ToString();

                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBoxCrossing.Text!=null)
            {
                Global.crossing_prob = Double.Parse(textBoxCrossing.Text);
            }
            if(textBoxIteracje.Text!=null)
            {
                Global.iteracje_max = Int32.Parse(textBoxIteracje.Text);
            }
            if(textBoxPopulacja.Text!=null)
            {
                Global.population_size = Int32.Parse(textBoxPopulacja.Text);
            }
            if(textBoxMutations.Text!=null)
            {
                Global.mutation_prob = Double.Parse(textBoxMutations.Text);
            }

            Pierwsza_populacja.Generuj();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Rozwiązanie", typeof(string));
            dt.Columns.Add("Fitnes", typeof(double));

            for (int i = 0; i < Global.Populacja.Count(); i++)
            {
                dt.Rows.Add(new object[] { i, string.Join(",", Global.Populacja[i].Lista.ToArray()), Global.Populacja[i].fitnes });
            }

            dataGridViewPopulacja.DataSource = dt;
            dataGridViewPopulacja.Update();

            Rodzice.Wybor();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Obliczanie.Rozpocznij();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Rozwiązanie", typeof(string));
            dt.Columns.Add("Fitnes", typeof(double));

            for (int i = 0; i < Global.Populacja.Count(); i++)
            {
                dt.Rows.Add(new object[] { i, string.Join(",", Global.Populacja[i].Lista.ToArray()), Global.Populacja[i].fitnes });
            }

            dataGridViewPopulacja.DataSource = dt;
            dataGridViewPopulacja.Update();
        }
    }
}
