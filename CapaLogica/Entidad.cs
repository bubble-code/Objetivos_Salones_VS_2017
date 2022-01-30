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

    }
}
