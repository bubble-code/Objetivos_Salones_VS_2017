using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entidad
    {
        public int _ErrorCode { get; set; }
        public string _ErrorMsg { get; set; }
        public string _TotalDiario { get; set; }
        public string _TotalPeriodo { get; set; }
        public string _Objetivo { get; set; }
        public string _MesActual { get; set; }
        public DataTable curr = new DataTable();
        public DataTable _EstadoMaquina = new DataTable();
        public List<ContaTemp> coTemp = new List<ContaTemp>();
        public Dictionary<int, double> rankingMaquina = new Dictionary<int, double>();


    }
}
