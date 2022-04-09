using System;
using System.Data.OleDb;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class Conexion
    {
        private string stringConnection;
        string mesActual, ConsulTotalDiario, hoy;
        string periodoActual = $"SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasDia  WHERE Val(Format(Fecha,'MM'))>=  Val(01) and Val(Format(Fecha,'YYYY'))>=  Val(2022)";
        string trimestre = $"SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasDia  WHERE Format(Fecha,'yyyy-MM-dd') <= Format('2022-01-01','yyyy-MM-dd')";
        string mes;
        string curre = "select IdMaquina, TotalEntradas, TotalSalidas, Diferencia, FechaDesde from ContabilidadTmp";



        public OleDbConnection _con { get; set; }
        public OleDbCommand _cmd { get; set; }
        public OleDbDataAdapter _ad { get; set; }
        public DataSet _DiarioDataSet = new DataSet();

        public Conexion(Entidad En, string path)
        {
            stringConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Jet OLEDB:Database Password = N68H98A30";
            getConnection(En);
            mesActual = DateTime.Today.Date.Month.ToString("00");
            hoy = DateTime.Now.ToString("yyyy-MM-dd");
            string diasAnteriores = DateTime.Today.AddDays(-10).ToString("yyyy-MM-dd");

            ConsulTotalDiario = $"SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasHora  WHERE Format(modificado,'yyyy-MM-dd HH:nn:ss') >= Format('{hoy} 00:00:00','yyyy-MM-dd HH:nn:ss')";
            mes = $"SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasHora  WHERE Format(modificado,'MM') >= '{mesActual}' AND Format(modificado,'YYYY') =  '2022'";



        }



        private void getConnection(Entidad En)
        {
            try
            {
                _con = new OleDbConnection(stringConnection);
                if (_con.State == ConnectionState.Closed)
                    _con.Open();
                if (_con.State == ConnectionState.Open)
                    En._ErrorCode = 0;
                else
                {
                    En._ErrorCode = 999;
                    En._ErrorMsg = "Login Fail";
                }
            }
            catch (Exception ex)
            {
                En._ErrorCode = ex.HResult;
                En._ErrorMsg = ex.Message;
            }
        }
        public void getDiario(Entidad En)
        {
            _cmd = new OleDbCommand(ConsulTotalDiario, _con);
            _ad = new OleDbDataAdapter(_cmd);
            _ad.Fill(_DiarioDataSet, "Diario");
            En._TotalDiario = _DiarioDataSet.Tables["Diario"].Rows[0].IsNull(0) ? "0,0" : _DiarioDataSet.Tables["Diario"].Rows[0]["TOTAL"].ToString();
        }
        public void getPeriodo(Entidad En)
        {
            _cmd = new OleDbCommand(periodoActual, _con);
            _ad = new OleDbDataAdapter(_cmd);
            _ad.Fill(_DiarioDataSet, "PeriodoActual");
            En._TotalPeriodo = _DiarioDataSet.Tables["PeriodoActual"].Rows[0].IsNull(0) ? "0,0" : _DiarioDataSet.Tables["PeriodoActual"].Rows[0]["TOTAL"].ToString();
        }
        public void getMes(Entidad En)
        {
            _cmd = new OleDbCommand(mes, _con);
            _ad = new OleDbDataAdapter(_cmd);
            _ad.Fill(_DiarioDataSet, "MesActula");
            En._MesActual = _DiarioDataSet.Tables["MesActula"].Rows[0]["TOTAL"].ToString();
        }
        public void getCurrent(Entidad en)
        {
            _cmd = new OleDbCommand(curre, _con);
            _ad = new OleDbDataAdapter(_cmd);
            _ad.Fill(_DiarioDataSet, "Curr");
            foreach (DataRow rw in _DiarioDataSet.Tables["Curr"].Rows)
            {
                en.coTemp.Add(new ContaTemp(rw[0].ToString(), rw[1].ToString(), rw[2].ToString(), rw[3].ToString(), rw[4].ToString()));
            }
            _ad.Fill(_DiarioDataSet, "CC");
            en.curr = _DiarioDataSet.Tables["Curr"];
            var ff = _DiarioDataSet;

            //en.curr = _DiarioDataSet;
        }

    }
}

