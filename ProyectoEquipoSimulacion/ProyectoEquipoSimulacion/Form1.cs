using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEquipoSimulacion
{
    public partial class Form1 : Form
    {
        //Declaracion de variables
        public static double a;
        public static double c ;
        public static double Xo;
        public static double M ;
        double n, modulo, m = 0, acumulador = 0, promedio, Zo;
        double[] random = new double[100000];
        int ad;


        private void button1_Click(object sender, EventArgs e)
        {
            
            double.TryParse(tbA.Text, out a);
            double.TryParse(tbC.Text, out c);
            double.TryParse(tbXo.Text, out Xo);
            double.TryParse(tbM.Text, out M);
            double.TryParse(tbn.Text, out n);
            //generar numeros 
            for (int i = 0; i < n; i++)
            {
                modulo = (a * Xo + c) % M;
                random[i] = modulo / M;
                double redoneado = (Math.Round(random[i], 5));
                ad = dataGridView1.Rows.Add();
                dataGridView1.Rows[ad].Cells[0].Value = (i+1).ToString();
                dataGridView1.Rows[ad].Cells[1].Value = redoneado.ToString();
               
                acumulador += random[i];

                m = modulo;
                Xo = m;
                
                
            }
            
            //obtenemos el promedio de los números pseodoaleatorios
            promedio = acumulador / n;
            lblpromedio.Text = (Math.Round(promedio,5)).ToString();

            //obtenemos la distribución normal
            Zo = ((Math.Sqrt(n)) * (promedio - 0.5)) / (Math.Sqrt(0.083333333));
            lbldisnor.Text = (Math.Round(Zo, 5)).ToString();



        }

        
        public Form1()
        {
            InitializeComponent();
        }
        
    }
}
