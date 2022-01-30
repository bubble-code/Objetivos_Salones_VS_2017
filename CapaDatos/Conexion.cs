using System;
using System.Data.OleDb;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class Conexion
    {
        readonly private string stringConnection = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|Bolsa2-09.mdb; Jet OLEDB:Database Password = N68H98A30";
        string fechaa, ConsulTotalDiario, trimestre, ayer, mes;
        string ConsulTotalPeriodo = "SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasHora ";
     

        public OleDbConnection _con { get; set; }
        public OleDbCommand _cmd { get; set; }
        public OleDbDataAdapter _ad { get; set; }
        public DataSet _DiarioDataSet  = new DataSet();

        public Conexion(Entidad En)
        {
            getConnection(En);
            fechaa = DateTime.Today.Date.Month.ToString();
            ayer = DateTime.Today.Date.AddDays(-1).ToString("yyyy-MM-dd");

            ConsulTotalDiario = $"SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasDia  WHERE Format(Fecha,'yyyy-MM-dd') >= Format('{ayer}','yyyy-MM-dd')";
            mes = $"SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasDia  WHERE Format(Fecha,'yyyy-MM-dd') >= Format('{fechaa}','yyyy-MM-dd')";
            trimestre = $"SELECT SUM(Entradas)-SUM(Salidas) AS TOTAL FROM JugadasDia  WHERE Format(Fecha,'yyyy-MM-dd') <= Format('2022-01-01','yyyy-MM-dd')";
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
            En._TotalDiario = _DiarioDataSet.Tables["Diario"].Rows[0]["TOTAL"].ToString();
        }
        public void getPeriodo(Entidad En)
        {
            _cmd = new OleDbCommand(ConsulTotalPeriodo, _con);
            _ad = new OleDbDataAdapter(_cmd);
            _ad.Fill(_DiarioDataSet, "TotalPeriodo");
            En._TotalPeriodo = _DiarioDataSet.Tables["TotalPeriodo"].Rows[0]["TOTAL"].ToString();
        }

    }
}

