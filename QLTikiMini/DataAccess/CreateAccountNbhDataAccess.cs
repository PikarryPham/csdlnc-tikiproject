using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CreateAccountNbhDataAccess
    {
        public int ReturnCode { get; set; }
        public string ReturnMess { get; set; }

        public DataTable CREATE_ACCOUNT_NBH(string tenNbh, string username, string pass, string vat, string sdt, string email, string maDangKy, string tenCuaHang, string diaChi, string maDanhMucNganh, string maMoHinhVanHanh)
        {
            SqlConnection con = DataConnection.GetSqlConnection();
            DataTable tbl = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CREATE_ACCOUNT_NBH", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TENNBH", SqlDbType.NVarChar).Value = string.IsNullOrWhiteSpace(tenNbh) ? (object)DBNull.Value : tenNbh;
                cmd.Parameters.Add("@USERNAMENBH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(username) ? (object)DBNull.Value : username;
                cmd.Parameters.Add("@PASSNBH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(pass) ? (object)DBNull.Value : pass;
                cmd.Parameters.Add("@SDTNBH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(sdt) ? (object)DBNull.Value : sdt;
                cmd.Parameters.Add("@VAT", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(vat) ? (object)DBNull.Value : vat;
                cmd.Parameters.Add("@EMAILNBH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(vat) ? (object)DBNull.Value : email;
                cmd.Parameters.Add("@MDK_KINHDOANH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(vat) ? (object)DBNull.Value : maDangKy;
                cmd.Parameters.Add("@TENCUAHANG", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(vat) ? (object)DBNull.Value : tenCuaHang;
                cmd.Parameters.Add("@DCHICUAHANG", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(vat) ? (object)DBNull.Value : diaChi;
                cmd.Parameters.Add("@MA_DANHMUCNGANH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(vat) ? (object)DBNull.Value : maDanhMucNganh;
                cmd.Parameters.Add("@MA_MHVH", SqlDbType.Char).Value = string.IsNullOrWhiteSpace(vat) ? (object)DBNull.Value : maMoHinhVanHanh;



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
