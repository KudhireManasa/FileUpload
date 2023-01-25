using System.Data.SqlClient;
using System.Data;
using UploadFileProject.Models;

namespace UploadFileProject.BusinessLogic_bl
{
    public class Delete_bi
    {
        public static bool Delete(int Id)
        {
            bool result = false;
            var dbconfig = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            SqlConnection con = new SqlConnection(dbconnectionstr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteFiles", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",Id);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return true;
        }
    }
}
