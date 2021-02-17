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
        public const string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ PATH + "formulaone.mdf;Integrated Security=True";

        public List<Teams> getTeamsObj()
        {
            List<Teams> retVal = new List<Teams>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM teams";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string teamFullName = reader.GetString(2);
                            string extCountry = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            string technicalChief = reader.GetString(5);
                            string chassis = reader.GetString(6);
                            int extFirstDriver = reader.GetInt32(7);
                            int extSecondDriver = reader.GetInt32(8);
                            string logo = reader.GetString(9);
                            string img = reader.GetString(10);
                            retVal.Add(new Teams(id, name, teamFullName, extCountry, teamPowerUnit, technicalChief, chassis, extFirstDriver, extSecondDriver, logo, img));
                        }
                    }
                }
            }
            return retVal;
        }

        public Teams getTeam(string code)
        {
            Teams retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                string sqlcommand = "SELECT * FROM teams WHERE id=" + Convert.ToInt32(code)+ ";";   
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int teamCode = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string teamFullName = reader.GetString(2);
                            string extCountry = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            string technicalChief = reader.GetString(5);
                            string chassis = reader.GetString(6);
                            int extFirstDriver = reader.GetInt32(7);
                            int extSecondDriver = reader.GetInt32(8);
                            string logo = reader.GetString(9);
                            string img = reader.GetString(10);
                            retVal=(new Teams(teamCode, name, teamFullName, extCountry, teamPowerUnit, technicalChief, chassis, extFirstDriver, extSecondDriver, logo, img));
                        }
                    }
                }
            }
            return retVal;
        }

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
        public List<string> getCountries()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string IsoCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            Console.WriteLine("{0} {1}", IsoCode, descr);
                            retVal.Add(IsoCode + " - " + descr);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Country> getCountriesObj()
        {
            List<Country> retVal = new List<Country>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string IsoCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            Console.WriteLine("{0} {1}", IsoCode, descr);
                            retVal.Add(new Country(IsoCode, descr));
                        }
                    }
                }
            }
            return retVal;
        }

        public Country getCountry(string code)
        {
            Country retVal = null;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = connstring;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM country WHERE countryCode="+code+";";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string IsoCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            Console.WriteLine("{0} {1}", IsoCode, descr);
                            retVal=new Country(IsoCode, descr);
                        }
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
