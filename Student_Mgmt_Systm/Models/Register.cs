using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace miniProject.Models
{
    public class Register
    {
        [Key]
        [Display(Name = "User Id")]
        public int UserNo { get; set; }


        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter Login name")]
        public string LoginName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter emailId")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?([6-9]{1})\)?([0-9]{9})$",
                   ErrorMessage = "Entered valid phone number.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirm password should be the same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select Degree")]
        public int DegreeNo { get; set; }

        public static List<Register> GetAllRegUser()
        {
            List<Register> lstuser = new List<Register>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "GetAllRegUser";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    lstuser.Add(new Register { UserNo = dr.GetInt32("UserNo"), LoginName = dr.GetString("LoginName"), FullName = dr.GetString("FullName"), Gender = dr.GetString("Gender"), EmailId = dr.GetString("EmailId"), Mobile = dr.GetString("Mobile"), Password = dr.GetString("Password"), DegreeNo = dr.GetInt32("DegreeNo") });
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
            return lstuser;
        }
        public static Register GetSingleUser(int UserNo)
        {
            Register obj = new Register();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "GetSingleUser";
                cmdInsert.Parameters.AddWithValue("@UserNo", UserNo);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    obj.UserNo = dr.GetInt32("UserNo");
                    obj.LoginName = dr.GetString("LoginName");
                    obj.FullName = dr.GetString("FullName");
                    obj.Gender = dr.GetString("Gender");
                    obj.EmailId = dr.GetString("EmailId");
                    obj.Mobile = dr.GetString("Mobile");
                    obj.Password = dr.GetString("Password");

                    obj.DegreeNo = dr.GetInt32("DegreeNo");
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
            return obj;
        }
        public static void InsertUser(Register obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertUser";

                cmdInsert.Parameters.AddWithValue("@LoginName", obj.LoginName);
                cmdInsert.Parameters.AddWithValue("@FullName", obj.FullName);
                cmdInsert.Parameters.AddWithValue("@Gender", obj.Gender);
                cmdInsert.Parameters.AddWithValue("@EmailId", obj.EmailId);
                cmdInsert.Parameters.AddWithValue("@Mobile", obj.Mobile);
                cmdInsert.Parameters.AddWithValue("@Password", obj.Password);
                cmdInsert.Parameters.AddWithValue("@DegreeNo", obj.DegreeNo);
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
        public static void UpdateUser(Register obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "UpdateUser";


                cmdInsert.Parameters.AddWithValue("@LoginName", obj.LoginName);
                cmdInsert.Parameters.AddWithValue("@FullName", obj.FullName);
                cmdInsert.Parameters.AddWithValue("@Gender", obj.Gender);
                cmdInsert.Parameters.AddWithValue("@EmailId", obj.EmailId);
                cmdInsert.Parameters.AddWithValue("@Mobile", obj.Mobile);
                cmdInsert.Parameters.AddWithValue("@Password", obj.Password);
                cmdInsert.Parameters.AddWithValue("@DegreeNo", obj.DegreeNo);
                cmdInsert.Parameters.AddWithValue("@UserNo", obj.UserNo);
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
        public static void DeleteUser(int UserNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "DeleteUser";

                cmdInsert.Parameters.AddWithValue("@UserNo", UserNo);
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

        public static bool GetLoginUser(string LoginName , string Password)
        {
            bool flag = false;
            Register obj = new Register();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "GetLoginUser";
                cmdInsert.Parameters.AddWithValue("@LoginName", LoginName);
                cmdInsert.Parameters.AddWithValue("@Password", Password);
                
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {
                    flag = true;
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
            return flag;
        }

        public static List<Register> GetAllRegUserSorted()
        {
            List<Register> lstuser = new List<Register>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJan23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.CommandText = "GetAllRegUserSorted ";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    lstuser.Add(new Register { UserNo = dr.GetInt32("UserNo"), LoginName = dr.GetString("LoginName"), FullName = dr.GetString("FullName"), Gender = dr.GetString("Gender"), EmailId = dr.GetString("EmailId"), Mobile = dr.GetString("Mobile"), Password = dr.GetString("Password"), DegreeNo = dr.GetInt32("DegreeNo") });
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
            return lstuser;
        }
    }
}
