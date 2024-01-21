using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VbElTerminali.Classes
{

    public class DataLayer
    {
        private string ConnectionString { get; set; }

        public SqlDataReader Select_Command_Data_Reader(string query, string yil)
        {

            //Create a SqlConnection to the database.
            ConnectionString = GetConnectionString(yil);
            try
            {

                SqlConnection connection = new SqlConnection(ConnectionString);
                
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    
                        SqlDataReader sdr = command.ExecuteReader(); // Ensure that the connection is closed when the reader is closed
                        return sdr;
                    
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }

        }

        public string Get_Stored_Proc_Sevk_Irsaliye_No(string yil, string param1, string param1Val)
        {
            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("vbpGetElTerminaliSevkIrsaliyeNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 35)).Value = param1Val;

                        object result = command.ExecuteScalar();

                        connection.Close();

                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                }
            }
            catch { return string.Empty; }
          
        }

        public string Get_Stored_Proc_Sevk_Irsaliye_No_Existing(string yil,string param1, string param1Val)
        {
            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("vbpGetExistingElTerminaliSevkIrsaliyeNo", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 35)).Value = param1Val;

                        object result = command.ExecuteScalar();

                        connection.Close();

                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                }
            }
            catch { return string.Empty; }
          
        }


        public bool Insert_Stored_Proc_Mas(string proc, string param1, int param1Val, 
                                           string param2, string param2Val, 
                                           string yil)                                            
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.SmallInt)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.NVarChar, 15)).Value = param2Val;
                        
                        command.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
            
        }

        public bool Delete_Stored_Proc_Satir_Geri_Al(string proc, string param1, string param1Val, 
                                                   string param2, string param2Val,
                                                   string param3, int param3Val,
                                                   string param4, string param4Val,
                                                   string param5, int param5Val,                                                 
                                                   string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 15)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.NVarChar, 15)).Value = param2Val;
                        command.Parameters.Add(new SqlParameter(param3, SqlDbType.Int)).Value = param3Val;
                        command.Parameters.Add(new SqlParameter(param4, SqlDbType.NVarChar, 35)).Value = param4Val;
                        command.Parameters.Add(new SqlParameter(param5, SqlDbType.Int)).Value = param5Val;

                        command.ExecuteNonQuery();

                        connection.Close();
                    
                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool Delete_Stored_Proc_Mas_Geri_Al(string proc, string param1, string param1Val,
                                                   string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 15)).Value = param1Val;

                        command.ExecuteNonQuery();

                        connection.Close();

                    }
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool Insert_Stored_Proc_Satir(string proc, string param1, string param1Val, string param2, string param2Val,
                                             string param3, int param3Val, string param4,
                                             string param4Val, string param5, int param5Val,
                                             string param6, int param6Val,
                                             string param7, string param7Val,
                                             string param8, int param8Val,
                                             string param9, string param9Val,
                                             string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 15)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.NVarChar, 15)).Value = param2Val;
                        command.Parameters.Add(new SqlParameter(param3, SqlDbType.TinyInt)).Value = param3Val;
                        command.Parameters.Add(new SqlParameter(param4, SqlDbType.NVarChar, 15)).Value = param4Val;
                        command.Parameters.Add(new SqlParameter(param5, SqlDbType.TinyInt)).Value = param5Val;
                        command.Parameters.Add(new SqlParameter(param6, SqlDbType.Int)).Value = param6Val;
                        command.Parameters.Add(new SqlParameter(param7, SqlDbType.NVarChar, 35)).Value = param7Val;
                        command.Parameters.Add(new SqlParameter(param8, SqlDbType.TinyInt)).Value = param8Val;
                        command.Parameters.Add(new SqlParameter(param9, SqlDbType.NVarChar, 15)).Value = param9Val;

                        command.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
            }
            catch{return false;}

        }

        public bool Insert_Stored_Proc_Gecici_Barkod(string proc, string param1, string param1Val, 
                                                    string param2, string param2Val,
                                                    string param3, string param3Val,
                                                    string param4, string param4Val,
                                                    string param5, string param5Val,
                                                    string param6, int param6Val,
                                                    string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 500)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.NVarChar, 100)).Value = param2Val;
                        command.Parameters.Add(new SqlParameter(param3, SqlDbType.NVarChar, 500)).Value = param3Val;
                        command.Parameters.Add(new SqlParameter(param4, SqlDbType.NVarChar, 35)).Value = param4Val;
                        command.Parameters.Add(new SqlParameter(param5, SqlDbType.NVarChar, 15)).Value = param5Val;
                        command.Parameters.Add(new SqlParameter(param6, SqlDbType.Int)).Value = param6Val;

                        command.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
            }
            catch { return false; }
        }

        public bool Insert_Stored_Proc_Gecici_Paket(string proc, string param1, int param1Val, string param2, int param2Val,
                                             string param3, string param3Val, 
                                             string param4, string param4Val, 
                                             string param5, string param5Val,
                                             string param6, string param6Val,
                                             string param7, int param7Val,
                                             string param8, string param8Val,
                                             string param9, string param9Val,
                                             string param10, string param10Val,
                                             string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.Int)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.Int)).Value = param2Val;
                        command.Parameters.Add(new SqlParameter(param3, SqlDbType.NVarChar, 100)).Value = param3Val;
                        command.Parameters.Add(new SqlParameter(param4, SqlDbType.NVarChar, 500)).Value = param4Val;
                        command.Parameters.Add(new SqlParameter(param5, SqlDbType.NVarChar, 35)).Value = param5Val;
                        command.Parameters.Add(new SqlParameter(param6, SqlDbType.NVarChar, 15)).Value = param6Val;
                        command.Parameters.Add(new SqlParameter(param7, SqlDbType.Int)).Value = param7Val;
                        command.Parameters.Add(new SqlParameter(param8, SqlDbType.NVarChar, 15)).Value = param8Val;
                        command.Parameters.Add(new SqlParameter(param9, SqlDbType.NVarChar, 500)).Value = param9Val;
                        command.Parameters.Add(new SqlParameter(param10, SqlDbType.NVarChar, 35)).Value = param10Val;

                        command.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); return false; }

        }

        public bool Delete_Stored_Proc_Gecici_Paket(string proc, string param1, string param1Val, string param2, string param2Val,
                                             string param3, string param3Val,
                                             string param4, int param4Val,
                                             string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 100)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.NVarChar, 35)).Value = param2Val;
                        command.Parameters.Add(new SqlParameter(param3, SqlDbType.NVarChar, 15)).Value = param3Val;
                        command.Parameters.Add(new SqlParameter(param4, SqlDbType.Int)).Value = param4Val;

                        command.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); return false; }

        }



        public bool Insert_Stored_Proc_Sevk_Irsaliye(string proc, string param1, string param1Val, string param2, int param2Val,
                                             string param3, string param3Val,
                                             string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 35)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.Int)).Value = param2Val;
                        command.Parameters.Add(new SqlParameter(param3, SqlDbType.NVarChar, 15)).Value = param3Val;
                        
                        command.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
            }
            catch { return false; }

        }

        public bool Update_IrsFlag(string proc, string param1, string param1Val,
                                           string param2, string param2Val,
                                           string yil)
        {

            try
            {

                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(proc, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter(param1, SqlDbType.NVarChar, 35)).Value = param1Val;
                        command.Parameters.Add(new SqlParameter(param2, SqlDbType.NVarChar, 5)).Value = param2Val;

                        command.ExecuteNonQuery();

                        connection.Close();
                        return true;
                    }
                }
            }
            catch { return false; }

        }

        public bool Truncate(string table1, string table2,string yil)
        {
            try
            {
                ConnectionString = GetConnectionString(yil);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        // Construct and execute the SQL statements to truncate tables.
                        string sql = "TRUNCATE TABLE " + table1 + "; TRUNCATE TABLE " + table2;
                        command.CommandText = sql;

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch {return false; }
        }

        private static string GetConnectionString(string yil)
        {
            string connectionString = string.Format("Data Source=192.168.1.11;initial Catalog=VITA{0};User id=sa;pwd=sapass;",yil);
            return connectionString;
        }

      
    }
}
