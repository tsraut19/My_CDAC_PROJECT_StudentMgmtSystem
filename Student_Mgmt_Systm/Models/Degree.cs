using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace miniProject.Models
{
    public class Degree
    {

        public int DegreeNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Degree")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string DegreeName { get; set; }

        public static String GetDegreeName(int DegreeNo)
        {
            Degree obj = new Degree();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select DegreeName from Degree where DegreeNo=@DegreeNo";
                cmdInsert.Parameters.AddWithValue("@DegreeNo", DegreeNo);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    // obj.DegreeNo = dr.GetInt32("DegreeNo");
                    obj.DegreeName = dr.GetString("DegreeName");
                }
                else
                {
                    obj = null;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj.DegreeName;
        }

        public static List<SelectListItem> GetAllDegree()
        {
            List<SelectListItem> objDegree = new List<SelectListItem>();
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Degree ";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    objDegree.Add(new SelectListItem(dr.GetString("DegreeName"), ""+dr.GetInt32("DegreeNo")));
                    //lstDegree.Add(new Degree { DegreeNo = dr.GetInt32("DegreeNo"), DegreeName = dr.GetString("DegreeName") });
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return objDegree;
        }
        public static void InsertDegree(Degree obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into Degree values(@DegreeNo,@DegreeName)";

                cmdInsert.Parameters.AddWithValue("@UserNo", obj.DegreeNo);
                cmdInsert.Parameters.AddWithValue("@LoginName", obj.DegreeName);
           
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateDegree(Degree obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update Degree set DegreeNo=@DegreeNo,DegreeName=@DegreeName";

                cmdInsert.Parameters.AddWithValue("@DegreeNo", obj.DegreeNo);
                cmdInsert.Parameters.AddWithValue("@DegreeName", obj.DegreeName);
               
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }

        public static void DeleteDegree(int DegreeNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from Register where DegreeNo =@DegreeNo";

                cmdInsert.Parameters.AddWithValue("@DegreeNo", DegreeNo);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }
    }

}
