using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SearchVoucherDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable KICHBAN1_RATEGIAMGIA(string tyLeGiamGia)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("KICHBAN1_RATEGIAMGIA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!string.IsNullOrWhiteSpace(tyLeGiamGia))
                    cmd.Parameters.Add("@TILEGIAMGIA", SqlDbType.Int).Value = tyLeGiamGia;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tbl);

                ReturnCode = 0;
                ReturnMess = "success";
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
