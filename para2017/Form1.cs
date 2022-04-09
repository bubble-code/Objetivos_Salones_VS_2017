using CapaEntidad;
using CapaNegocio;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace para2017
{
    public partial class Form1 : Form
    {
        string paht="";
        public Form1()
        {
            InitializeComponent();
            
        }

        #region Datos de Actualizacion  de subproceso  de dataGrid

        private Thread th;
        private bool isStart = true;
       private void GetData()
        {
            th = new Thread(new ThreadStart(StartData))
            {
                IsBackground = true
            };
            th.Start();
        }
        private delegate void InvokeHandler();
        private void StartData()
        {
            try
            {
                while (true)
                {
                    if (this.IsHandleCreated)
                    {
                       
                        this.Invoke(new InvokeHandler(delegate ()
                        {
                            Entidad enti = new Entidad();
                            try
                            {
                                Negocio neg = new Negocio(enti, paht);
                                materialLabel1.Text = enti._TotalDiario != null ? double.Parse(enti._TotalDiario).ToString("#,##0.00") : "";
                                materialLabel6.Text = enti._TotalPeriodo != null ? double.Parse(enti._TotalPeriodo).ToString("#,##0.00") : "";
                                materialLabel4.Text = enti._MesActual != null ? double.Parse(enti._MesActual).ToString("#,##0.00") : "";
                            }
                            catch
                            {
                                MessageBox.Show(enti._ErrorMsg);                            }
                            
                        }));
                    }
                    Thread.Sleep(60000);
                }
            }
            catch
            {
                return;
            }
        }

        #endregion
        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void openDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Access 2000-2003 (*.mdb)| *.mdb";
            openFileDialog1.Title = "Por favor selecciona la base de datos";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                paht = openFileDialog1.FileName;                
            }
        }

        private void comenzarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (isStart)
                GetData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
