using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SearchProductsDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable KICHBAN1_GIAKHUYENMAIGIAMDAN(string danhMuc)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("KICHBAN1_GIAKHUYENMAIGIAMDAN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DANHMUC", SqlDbType.Int).Value = string.IsNullOrWhiteSpace(danhMuc) ? (object)DBNull.Value : Convert.ToInt32(danhMuc);

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
