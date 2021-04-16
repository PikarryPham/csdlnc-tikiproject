using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateAccountKhDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable CREATE_ACCOUNT_KH(string tenKh, string diaChi, string email, string sdt, string username, string pass)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CREATE_ACCOUNT_KH", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TEN_KH", SqlDbType.NVarChar).Value = string.IsNullOrWhiteSpace(tenKh) ? (object)DBNull.Value : tenKh;
                cmd.Parameters.Add("@DIACHI_KH", SqlDbType.NVarChar).Value = string.IsNullOrWhiteSpace(diaChi) ? (object)DBNull.Value : diaChi;
                cmd.Parameters.Add("@EMAIL_KH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email;
                cmd.Parameters.Add("@SDT_KH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(sdt) ? (object)DBNull.Value : sdt;
                cmd.Parameters.Add("@USERNAME_KH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(username) ? (object)DBNull.Value : username;
                cmd.Parameters.Add("@PASS_KH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(pass) ? (object)DBNull.Value : pass;

                SqlParameter param_RETURNCODE;
                SqlParameter param_RETURNMESSAGE;
                param_RETURNCODE = cmd.Parameters.Add("@RETURNCODE", SqlDbType.Int);
                param_RETURNCODE.Direction = ParameterDirection.Output;
                param_RETURNMESSAGE = cmd.Parameters.Add("@RETURNMESS", SqlDbType.NVarChar, 500);
                param_RETURNMESSAGE.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                
                ReturnCode = Convert.ToInt32(param_RETURNCODE.Value.ToString());
                ReturnMess = param_RETURNMESSAGE.Value.ToString();
            }
            catch (Exception ex)
            {
                ReturnCode = 500;
                ReturnMess = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return tbl;
        }
    }
}
