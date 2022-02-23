using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Metaheurystyka
{
    public partial class Form1 : Form
    {
        bool completed = true;

        public Form1()
        {
            InitializeComponent();

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            completed = false;
            for(int i=Global.instancja.iteracja; i<Global.instancja.iteracje_max; i++)
            {
                if (backgroundWorker1.CancellationPending) break;
                try
                {
                    Global.instancja.Obliczanie();
                }
                catch
                {
                    break;
                }
               
                backgroundWorker1.ReportProgress(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nazwa;
            if (textBoxNazwa.Text != null)
            {
                nazwa = textBoxNazwa.Text;
                
                Global.instancja=new Instancja(nazwa);

                try
                {
                    textBoxInstancja.Text = string.Join(",", Global.instancja.Lista.ToArray());

                    textBoxP.Text = Global.instancja.Dlugosc_rozwiazania.ToString();

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
                Global.instancja.crossing_prob = Double.Parse(textBoxCrossing.Text);
            }
            if(textBoxIteracje.Text!=null)
            {
                Global.instancja.iteracje_max = Int32.Parse(textBoxIteracje.Text);
            }
            if(textBoxPopulacja.Text!=null)
            {
                Global.instancja.population_size = Int32.Parse(textBoxPopulacja.Text);
            }
            if(textBoxMutations.Text!=null)
            {
                Global.instancja.mutation_prob = Double.Parse(textBoxMutations.Text);
            }
            Global.instancja.populacja.Gen_pierwsza(Global.instancja);

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Rozwiązanie", typeof(string));
            dt.Columns.Add("Fitnes", typeof(double));

            for (int i = 0; i < Global.instancja.populacja.Lista.Count(); i++)
            {
                dt.Rows.Add(new object[] { i, string.Join(",",
                    Global.instancja.populacja.Lista[i].Lista.ToArray()),
                    Global.instancja.populacja.Lista[i].fitnes });
            }

            dataGridViewPopulacja.DataSource = dt;
            dataGridViewPopulacja.Update();

            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            

            try
            {
                if(completed)
                {
                    backgroundWorker1.RunWorkerAsync();
                    Global.instancja.Stop = false;
                    label9.Text = "Itetacja " + Global.instancja.iteracja.ToString() + " z " + Global.instancja.iteracje_max.ToString();
                    progressBar1.Maximum = Global.instancja.iteracje_max;
                }
                
            }
            catch(Exception ex)
            {

            }
            
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Rozwiązanie", typeof(string));
            dt.Columns.Add("Fitnes", typeof(double));

            for (int i = 0; i < Global.instancja.populacja.Lista.Count(); i++)
            {
                dt.Rows.Add(new object[] { i, string.Join(",", Global.instancja.populacja.Lista[i].Lista.ToArray()), 
                    Global.instancja.populacja.Lista[i].fitnes });
            }

            dataGridViewPopulacja.DataSource = dt;
            dataGridViewPopulacja.Update();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            Global.instancja.Stop = true;
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            completed = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label9.Text = "Iteracja " + Global.instancja.iteracja.ToString() + " z " + Global.instancja.iteracje_max.ToString();
            progressBar1.Value += 1;

            textBox1.Text= string.Join(",", Global.instancja.Najlepsze.Lista.ToArray());
            textBox2.Text = Global.instancja.Najlepsze.fitnes.ToString();

            textBoxTime.Text = Global.instancja.czas.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                
                try
                {
                    string path = Directory.GetCurrentDirectory();
                    string substr = "metaheurystyka";
                    int index = path.IndexOf(substr);
                    path = path.Substring(0, index);
                    path += textBox7.Text + "\\";
                    string[] dirs = Directory.GetDirectories(path);
                    Global.dirs = dirs;

                    label18.Text = "Instancja 0 z " + (dirs.Count() * 10).ToString();
                    //test.Obliczenia();

                    if (!backgroundWorker2.IsBusy)
                    {
                        
                        backgroundWorker2.RunWorkerAsync();

                        progressBar2.Maximum = dirs.Count() * 10;
                    }
                }
                catch
                {
                    MessageBox.Show("Nieprawidłowa nazwa folderu");
                }
            }
        }

        public void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            

            string folder_w = "p" + textBox6.Text +
                "_i" + textBox4.Text +
                "_m" + textBox3.Text + "_c"
                + textBox5.Text;
            string path = Directory.GetCurrentDirectory();
            string substr = "metaheurystyka";
            int index = path.IndexOf(substr);
            path = path.Substring(0, index);
            path += "Wyniki\\";
            path += folder_w + "\\";
            Directory.CreateDirectory(path);
            path += textBox7.Text;
            path += ".txt";

            TextWriter tw = new StreamWriter(path);
            
            foreach (string d in Global.dirs)
            {
                string[] files = Directory.GetFiles(d);
                string name = d;
                
                name = name.Split('\\').Last();
                Test test = new Test(Int32.Parse(textBox6.Text), Int32.Parse(textBox4.Text),
                Double.Parse(textBox3.Text), Double.Parse(textBox5.Text), name);

                double wynik = 0;
                double czas = 0;
                for(int i=0; i<10; i++)
                {
                    string nazwa = name + "\\instancja" + i.ToString();
                    Instancja ins = new Instancja(nazwa);
                    ins.population_size = test.populacja;
                    ins.iteracje_max = test.iteracje;
                    ins.mutation_prob = test.mutation_prob;
                    ins.crossing_prob = test.cross_prob;
                    ins.populacja.Gen_pierwsza(ins);
                    for (int j = 0; j < test.iteracje; j++)
                    {
                        try
                        {
                            ins.Obliczanie();
                        }
                        catch
                        {
                            break;
                        }
                    }
                    wynik += ins.Najlepsze.fitnes;
                    czas += ins.czas;
                    backgroundWorker2.ReportProgress(0);
                }
                test.wyniki.Add(wynik / 10);
                test.czasy.Add(czas / 10);

                tw.WriteLine(test.folder+
                    "\t"+test.wyniki[0].ToString()+
                    "\t"+ test.czasy[0].ToString());
               
            }
            tw.Close();
            //e.Result = 0;
            //backgroundWorker2.ReportProgress(0);

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            if(progressBar2.Value!=progressBar2.Maximum) progressBar2.Value +=1;
            label18.Text = "Instancja "+progressBar2.Value.ToString()+" z " + (Global.dirs.Count() * 10).ToString();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar2.Value = 0;
            MessageBox.Show("Zakończono obliczenia");
            
           

        }
    }
}
