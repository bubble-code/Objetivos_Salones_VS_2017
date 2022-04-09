using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
     public class ContaTemp
    {
        private string fechaDesde;
        private string idMaquina;
        private string totalEntradas;
        private string totalSalidas;
        private string diferencia;

        public ContaTemp(string fechaDesde, string idMaquina, string totalEntradas, string totalSalidas, string diferencia)
        {
            this.fechaDesde = fechaDesde;
            this.idMaquina = idMaquina;
            this.totalEntradas = totalEntradas;
            this.totalSalidas = totalSalidas;
            this.diferencia = diferencia;
        }

        public string IdMaquina { get => idMaquina; set => idMaquina = value; }
        public string TotalEntradas { get => totalEntradas; set => totalEntradas = value; }
        public string TotalSalidas { get => totalSalidas; set => totalSalidas = value; }
        public string Diferencia { get => diferencia; set => diferencia = value; }
        public string FechaDesde { get => fechaDesde; set => fechaDesde = value; }
    }
}
