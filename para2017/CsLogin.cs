using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Gewetes.Class.Connection
{
    class CsLogin
    {
        private int ErrorCode;
        private string ErrMsg;
        private SqlConnectionStringBuilder stringConnection;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter ad;


        public int _ErrorCode { get { return ErrorCode; } }
        public string _ErrorMsg { get { return ErrMsg; } }
        public SqlConnection _con { get { return con; } set { con = value; } }
        public SqlCommand _cmd { get { return cmd; } set { cmd = value; } }
        public SqlDataAdapter _ad { get { return ad; } set { ad = value; } }

        public CsLogin( SqlConnectionStringBuilder stringConn)
        {
            stringConnection = stringConn;
            getConnection();
        }

        private void getConnection()
        {
            try
            {
                //string constr = "";                
                _con = new SqlConnection(stringConnection.ConnectionString);
                if (_con.State == System.Data.ConnectionState.Closed)
                    _con.Open();
                if (_con.State == System.Data.ConnectionState.Open)
                    ErrorCode = 0;
                else
                {
                    ErrorCode = 9999;
                    ErrMsg = "Login Fail";
                }

            }
            catch(Exception ex)
            {
                ErrorCode = ex.HResult;
                ErrMsg = ex.Message;
            }
        }

    }
}
