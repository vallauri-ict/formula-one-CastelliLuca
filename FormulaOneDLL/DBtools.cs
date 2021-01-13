using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;


namespace FormulaOneDLL
{
    public class DBtools
    {
        public DBtools() { }

        //public const string QUERYPATH = @"E:\Scuola\INFO_2K21\Code\formula-one\data\";
        public const string QUERYPATH = @"D:\Scuola\INFO_2K21\Code\formula-one\data\";
        public const string PATH = @"C:\data\formulaone\";
        public const string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ PATH + "FormulaOne.mdf;Integrated Security=True";
        public DataTable nameTable()
        {
            DataTable retVal;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                dbConn.Open();
                retVal = dbConn.GetSchema("Tables");
                dbConn.Close();
            }
            return retVal;
        }

        public DataTable getPilot()
        {
            DataTable retVal = new DataTable();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                String sql = $"SELECT * FROM Drivers";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(retVal);
                    }
                }
            }
            return retVal;
        }
        public DataTable getCountries()
        {
            DataTable retVal = new DataTable();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                String sql = $"SELECT * FROM Country";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(retVal);
                    }
                }
            }
            return retVal;
        }
        public DataTable getTeams()
        {
            DataTable retVal = new DataTable();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                String sql = $"SELECT * FROM Teams";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(retVal);
                    }
                }
            }
            return retVal;
        }
        public bool createTable(string fileName)
        {
            bool err = false;
            string fileContent = File.ReadAllText(QUERYPATH + fileName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            string [] queries;
            queries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(connstring);
            var cmd = new SqlCommand("query", con);
            con.Open();
            foreach (var query in queries)
            {
                cmd.CommandText = query;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    err = true;
                    return err;
                }
            }
            con.Close();
            return err;
        }
        public bool restore()
        {
            bool err = false;
            try
            {
                SqlConnection con = new SqlConnection(connstring);
                con.Open();
                string sqlStmt2 = string.Format("ALTER DATABASE ["+ PATH + "formulaone.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                bu2.ExecuteNonQuery();

                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + PATH + "formulaone.mdf] FROM DISK='" + PATH + @"formulaone.bak''WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                bu3.ExecuteNonQuery();

                string sqlStmt4 = string.Format("ALTER DATABASE [" + PATH + "formulaone.mdf] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                bu4.ExecuteNonQuery();
                con.Close();
                
            }
            catch (Exception)
            {
                err= true;
            }
            return err;
        }
        public bool backup()
        {
            bool err = false;
            try
            {
                SqlConnection con = new SqlConnection(connstring);
                con.Open();
                String sql = "BACKUP DATABASE neyadatabase TO DISK = '" + PATH +"formulaone.mdf\\neyadatabase - " + PATH + "formulaone.Bak'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }
            catch (Exception)
            {
                err = true;
            }
            return err;
        }
    }
    }
