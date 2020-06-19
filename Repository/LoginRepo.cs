using API.Common;
using IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class LoginRepo : ILoginRepo
    {
        private string _connectionString;
        public LoginRepo(IConfiguration config) => _connectionString = config.GetSection("ConnectionStrings").GetSection("Database").Value;
        public UserModel AuthenticateUser(UserModel login)
        {
            if (login.EmailAddress == "jibin8086@gmail.com" && login.Passwd== "nrS6GJLLay9t6qWwQSDZXA==") {
                return login;
            }
            return null;
           /* try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_Login]", conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = login.EmailAddress;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = login.Passwd;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                login.ID = Convert.ToInt32(reader["ID"]);
                                login.EmailAddress = reader["UserName"].ToString();
                            }

                        }
                        return login;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }*/
        }
    }
}
