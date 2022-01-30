using CapaEntidad;
using CapaNegocio;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace para2017
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Negocio neg = new Negocio();
            Entidad enti = new Entidad();
            neg.NegoToPresentacio(enti);
            materialLabel4.Text = enti._TotalPeriodo;
            materialLabel1.Text = enti._TotalDiario;
            materialLabel6.Text = DateTime.Today.Date.Month.ToString()+ DateTime.Today.Date.Year.ToString();

        }
    }
}
