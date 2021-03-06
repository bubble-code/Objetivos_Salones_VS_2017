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
using Google.Cloud.Firestore;
using System.Data.SqlClient;
using Gewetes.Class.Connection;

namespace para2017
{
    public partial class Form1 : Form
    {
        readonly SqlConnectionStringBuilder Alcobendas = new SqlConnectionStringBuilder
        {
            DataSource = "2.136.192.129,51304",
            UserID = "logs",
            Password = "af532a8f8b",
            InitialCatalog = "SIRIUS",

        };
        readonly SqlConnectionStringBuilder Oca22 = new SqlConnectionStringBuilder
        {
            DataSource = "2.136.188.147,51304",
            UserID = "logs",
            Password = "ecb347f134",
            InitialCatalog = "SIRIUS",

        };
        readonly SqlConnectionStringBuilder Alcala260 = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.1.120,51304",
            UserID = "logs",
            Password = "3df622ddba",
            InitialCatalog = "SIRIUS",

        };
        readonly SqlConnectionStringBuilder Alcala610 = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.1.120,51304",
            UserID = "logs",
            Password = "54382df704",
            InitialCatalog = "SIRIUS",

        };      
        readonly SqlConnectionStringBuilder Carabanchel = new SqlConnectionStringBuilder
        {
            DataSource = "2.136.77.49,51304",
            UserID = "logs",
            Password = "90ee68111d",
            InitialCatalog = "SIRIUS",

        };
        readonly SqlConnectionStringBuilder Mejorada = new SqlConnectionStringBuilder
        {
            DataSource = "2.136.163.107,51304",
            UserID = "logs",
            Password = "d70f0ed829",
            InitialCatalog = "SIRIUS",

        };
        readonly SqlConnectionStringBuilder Villanueva = new SqlConnectionStringBuilder
        {
            DataSource = "2.136.80.122,51304",
            UserID = "logs",
            Password = "11f90d8d24",
            InitialCatalog = "SIRIUS",

        };

        //Santander
        readonly SqlConnectionStringBuilder Santander = new SqlConnectionStringBuilder
        {
            DataSource = "2.136.189.233,51304",
            UserID = "logs",
            Password = "571bb914e5",
            InitialCatalog = "SIRIUS",

        };
        //Torrelavega
        readonly SqlConnectionStringBuilder Torrelavega = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.0.120,51304",
            UserID = "logs",
            Password = "815065777e",
            InitialCatalog = "SIRIUS",

        };
        //Santoña
        readonly SqlConnectionStringBuilder Santoña = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.1.120,51304",
            UserID = "logs",
            Password = "24ddb1cbc7",
            InitialCatalog = "SIRIUS",

        };
        //Tudela
        readonly SqlConnectionStringBuilder Tudela = new SqlConnectionStringBuilder
        {
            DataSource = "83.48.30.30,51304",
            UserID = "logs",
            Password = "1ad58910e2",
            InitialCatalog = "SIRIUS",

        };
        //Alsasua
        readonly SqlConnectionStringBuilder Alsasua = new SqlConnectionStringBuilder
        {
            DataSource = "2.136.163.103,51304",
            UserID = "logs",
            Password = "475096f01f",
            InitialCatalog = "SIRIUS",

        };
        //Mendevaldea
        readonly SqlConnectionStringBuilder Mendevaldea = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.1.120,51304",
            UserID = "logs",
            Password = "260d461305",
            InitialCatalog = "SIRIUS",

        };
        //Olite
        readonly SqlConnectionStringBuilder Olite = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.1.120,51304",
            UserID = "logs",
            Password = "770be0b60a",
            InitialCatalog = "SIRIUS",

        };
        readonly SqlConnectionStringBuilder Tropicana = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.0.120,51304",
            UserID = "logs",
            Password = "ff0fcab1c9",
            InitialCatalog = "SIRIUS",
        };
        readonly SqlConnectionStringBuilder Riviera = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.0.120,51304",
            UserID = "logs",
            Password = "ff0fcab1c9",
            InitialCatalog = "SIRIUS",
        };
        readonly SqlConnectionStringBuilder Fortuna = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.0.120,51304",
            UserID = "logs",
            Password = "fbdce170b2",
            InitialCatalog = "SIRIUS",
        };
        readonly SqlConnectionStringBuilder Malibu = new SqlConnectionStringBuilder
        {
            DataSource = "192.168.0.120,51304",
            UserID = "logs",
            Password = "7d2781103d",
            InitialCatalog = "SIRIUS",
        };
        //string paht = "C:\\Users\\g401897\\Desktop\\Bolsa.mdb";
        string paht = "C:\\ProgramData\\Tecnausa\\Gran Bolsa\\Bolsa.mdb";
        //string paht = "C:\\Users\\g401897\\Desktop\\Bolsa.mdb"; 
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
                                label11.Text = enti._TotalDiario != null ? double.Parse(enti._TotalDiario).ToString("#,##0.00") : "";
                                label17.Text = enti._TotalPeriodo != null ? double.Parse(enti._TotalPeriodo).ToString("#,##0.00") : "";
                                label14.Text = enti._MesActual != null ? double.Parse(enti._MesActual).ToString("#,##0.00") : "";                                
                                machineState(enti.rankingMaquina);
                                transpDataGridView3.Rows.Clear();
                                transpDataGridView2.Rows.Clear();
                                transpDataGridView1.Rows.Clear();
                                fetchData(Alcobendas);
                            }
                            catch
                            {
                                MessageBox.Show(enti._ErrorCode.ToString());                            }
                            
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

        
        private void machineState(Dictionary<int, double> rankMaqui)
        {
            try
            {
                int alpha = 250;
                for (int y = 0; y <= 24; y++)
                {
                    dataGridView1.Rows[0].Cells[y].Value = rankMaqui.ElementAt(y).Key;
                    dataGridView1.Rows[0].Cells[y].Style.BackColor = Color.FromArgb(29, 19, alpha);
                    alpha -= 8;
                    //dataGridView1.Rows[x].Cells[y].Style.BackColor = tableState.Rows[y]["EstadoModulo"].ToString() == "1" ? Color.DarkGreen : Color.DarkRed;
                }
            }catch(Exception ex)
            {

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
           
        }

        private void comenzarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 25;
            dataGridView1.RowCount = 2;
            if (isStart)
            {
                GetData();
                transpDataGridView3.Rows.Clear();
                transpDataGridView2.Rows.Clear();
                transpDataGridView1.Rows.Clear();
                fetchData(Alcobendas);
            }
                
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            transpDataGridView3.Rows.Clear();
            transpDataGridView2.Rows.Clear();
            transpDataGridView1.Rows.Clear();            
            fetchData(Fortuna);
        }
        //=======================================================
        // Logica
        //=======================================================
        private void fetchData(SqlConnectionStringBuilder conectioString)
        {
            Consultas cc = new Consultas();
            CsLogin login = new CsLogin(conectioString);
            //List<Stock> listStock = new List<Stock>();
            //List<Stock> listCashBox = new List<Stock>();
            //List<Ticket> listTicket = new List<Ticket>();
            //List<Tecnausa> listTecnausa = new List<Tecnausa>();
            float total = 0;
            float filo = 0;
            DataSet dataSet = new DataSet();
            if (login._ErrorCode == 0)
            {
                //cashBox
                login._cmd = new SqlCommand(cc.cashbox, login._con);
                login._ad = new SqlDataAdapter(login._cmd);
                login._ad.Fill(dataSet, "cashBox");
                //Stock
                login._cmd = new SqlCommand(cc.stock, login._con);
                login._ad = new SqlDataAdapter(login._cmd);
                login._ad.Fill(dataSet, "stock");
                //Tickets
                login._cmd = new SqlCommand(cc.ticket, login._con);
                login._ad = new SqlDataAdapter(login._cmd);
                login._ad.Fill(dataSet, "ticket");
                //Tecnausa
                //login._cmd = new SqlCommand(cc.tecnausa, login._con);
                //login._ad = new SqlDataAdapter(login._cmd);
                //login._ad.Fill(dataSet, "tecnausa");
                //Fill dataGridView
                foreach (DataRow ele in dataSet.Tables["stock"].Rows)
                {
                    var idex = transpDataGridView3.Rows.Add(ele["TYPE"].ToString(), ele["CANT"].ToString(), ele["VALUE"]);
                    switch (float.Parse(ele["TYPE"].ToString()))
                    {
                        case 50:
                            if (Int32.Parse(ele["CANT"].ToString()) < 200)
                            {
                                transpDataGridView3.Rows[idex].Cells[2].Style.BackColor = Color.FromArgb(250, 20, 20);
                            }
                            break;
                        case 20:
                            if (Int32.Parse(ele["CANT"].ToString()) < 250)
                            {
                                transpDataGridView3.Rows[idex].Cells[2].Style.BackColor = Color.FromArgb(250, 20, 20);
                            }
                            break;
                        case 10:
                            if (Int32.Parse(ele["CANT"].ToString()) < 20)
                            {
                                transpDataGridView3.Rows[idex].Cells[2].Style.BackColor = Color.FromArgb(250, 20, 20);
                            }
                            break;
                        default:
                            break;
                    }
                   
                    //listStock.Add(new Stock() { TYPE = ele["TYPE"].ToString(), CANT = ele["CANT"].ToString(), VALUE = ele["VALUE"].ToString()});
                    total += float.Parse(ele["VALUE"].ToString());
                }
                transpDataGridView3.Rows.Add("TOTAL", "", total);
                transpDataGridView3.Rows[transpDataGridView3.RowCount - 1].Cells[2].Style.BackColor = Color.FromArgb(1, 0, 150);
                filo += total;
                total = 0;
                //var bindingList = new BindingList<Stock>(listStock);
                //var source = new BindingSource(bindingList, null);
                //dataGridView1.DataSource = source;
                //dataGridView1.Columns["VALUE"].DefaultCellStyle.Format = "#.#,##";

                //CASHBOX
                foreach (DataRow ele in dataSet.Tables["cashBox"].Rows)
                {
                    transpDataGridView2.Rows.Add(ele["TYPE"].ToString(), ele["CANT"].ToString(), ele["VALUE"]);
                    total += float.Parse(ele["VALUE"].ToString());
                }
                transpDataGridView2.Rows.Add("TOTAL", "", total);
                transpDataGridView2.Rows[transpDataGridView2.RowCount - 1].Cells[2].Style.BackColor = Color.FromArgb(1, 0, 150);
                filo += total;
                total = 0;
                //dataGridView2.Rows[dataGridView2.RowCount - 1].Cells["TOTAL"].Style.BackColor = Color.FromArgb(214, 234, 248);
                //Y
                //TICKET

                foreach (DataRow ele in dataSet.Tables["ticket"].Rows)
                {
                    transpDataGridView1.Rows.Add(ele["TYPE"].ToString(), ele["TOTAL"]);
                    total += float.Parse(ele["TOTAL"].ToString());
                }
                transpDataGridView1.Rows.Add("TOTAL", total);
                transpDataGridView1.Rows[transpDataGridView1.RowCount - 1].Cells[1].Style.BackColor = Color.FromArgb(1, 0, 150);
                //dataGridView3.Columns["TOTAL"].DefaultCellStyle.Format = "#.#,##";
                filo += total;

                //Tecnausa
                //var sourcerTecnausa = new BindingSource();
                //foreach (DataRow ele in dataSet.Tables["tecnausa"].Rows)
                //{
                //    dataGridView3.Rows.Add(ele["TTimeStamp"].ToString(), ele["MachineNumber"].ToString(), ele["TEXT"].ToString(), ele["Betrag"]);

                //    // sourcerTecnausa.Add(new Tecnausa() { date = ele["TTimeStamp"].ToString(), qualification = ele["TEXT"].ToString(), pay = ele["Betrag"].ToString() });
                //    //listTecnausa.Add(new Tecnausa() { date = ele["TTimeStamp"].ToString(), qualification = ele["TEXT"].ToString(), pay = ele["Betrag"].ToString() });
                //}
                //dataGridView3.Columns[2].DefaultCellStyle.Format = "C2";
                label9.Text = filo.ToString();
                //var bindinTecnausa = new BindingList<Tecnausa>(listTecnausa);
                // tecnausa.DataSource = sourcerTecnausa;
                //dataGridView1.DataSource = dataSet.Tables["stock"];
                //dataGridView2.DataSource = dataSet.Tables["ticket"];
                //dataGridView3.DataSource = dataSet.Tables["cashbox"];

                //MessageBox.Show("Login Ok");
            }
            else
            {
                MessageBox.Show(login._ErrorMsg);
            }
        }

        private void fILEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click_1(object sender, EventArgs e)
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
            MessageBox.Show(openFileDialog1.FileName);
       
        }

        //private async void button1_Click (object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string path = AppDomain.CurrentDomain.BaseDirectory + @"keyFireStore.json";
        //        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        //        FirestoreDb db = FirestoreDb.Create("fluttergewete");
        //         Query dbref = db.Collection("users").Document("aobregon@merkur-casino.com").Collection("salones");

        //        QuerySnapshot snap = await dbref.GetSnapshotAsync();
        //        foreach(DocumentSnapshot docsnap in snap)
        //        {
        //            if (docsnap.Exists)
        //            {
        //                richTextBox1.Text += "[Salon Name: " + docsnap.Id + "]\n";
        //            }
        //        }
        //        //if (este.Exists)
        //        //{
        //        //    Dictionary<string, object> datas = este.ToDictionary();
        //        //    foreach(var item in datas)
        //        //    {
        //        //        richTextBox1.Text += string.Format("{0}:{1}\n", item.Key, item.Value);

        //        //    }
        //        //}
        //        MessageBox.Show("bien");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}
    }
}
