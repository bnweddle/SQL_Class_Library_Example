using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;

namespace WPF_Library
{  
    // This is where we will store all the procedure and view calls
    public class Repository
    {
        //string connection = "Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connection = ConfigurationManager.ConnectionStrings["LibraryConnection"].ConnectionString;

        public Dictionary<int,string> AvailableBooks()
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM V_AvailableBooks", connect))
                {
                    command.CommandType = CommandType.Text;

                    connect.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    Dictionary<int, string> books = new Dictionary<int, string>();
                    while(reader.Read())
                    {
                        books.Add(
                            reader.GetInt32(reader.GetOrdinal("BookID")),
                            reader.GetString(reader.GetOrdinal("Title"))
                            );
                    }

                    return books;
                }
            }
        }

        public Dictionary<int, string> Members()
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM V_Members", connect))
                {
                    command.CommandType = CommandType.Text;

                    connect.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    Dictionary<int, string> members = new Dictionary<int, string>();
                    while (reader.Read())
                    {
                        members.Add(
                            reader.GetInt32(reader.GetOrdinal("MemberID")),
                            reader.GetString(reader.GetOrdinal("MemberName"))
                            );
                    }

                    return members;
                }
            }
        }

        public Dictionary<int, string> SearchBooks(string search)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[P_SearchBook]", connect))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("Search", SqlDbType.NVarChar, (36)).Value = search;

                    connect.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    Dictionary<int, string> books = new Dictionary<int, string>();
                    while (reader.Read())
                    {
                        books.Add(
                            reader.GetInt32(reader.GetOrdinal("BookID")),
                            reader.GetString(reader.GetOrdinal("Title"))
                            );
                    }

                    return books;
                }
            }
        }

    }
}
