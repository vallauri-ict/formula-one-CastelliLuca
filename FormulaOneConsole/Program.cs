using System;
using System.Security.Permissions;
using System.Threading;
using FormulaOneDLL;

namespace FormulaOneConsole
{
    class Program {
        static void Main(string[] args)
        {
            Console.Title = "Formula 1";
            char scelta = ' ';
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("R - Restore Database");
                Console.WriteLine("B - Backup Database");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        callCreateTable("Countries");
                        break;
                    case '2':
                        callCreateTable("Teams");
                        break;
                    case '3':
                        callCreateTable("Drivers");
                        break;
                    case 'R':
                        restoreDatabase();
                        break;
                    case 'B':
                        backupDatabase();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x')
                            Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
            Environment.Exit(0);
        }

        private static void backupDatabase()
        {
            DBtools d = new DBtools();
            bool err = d.backup();
            if (!err)
                Console.WriteLine("\nBackup Database - SUCCESS\n");
            else
                Console.WriteLine("\nBackup Database - FAILURE\n");
        }

        private static void restoreDatabase()
        {
            DBtools d = new DBtools();
            bool err = d.restore();
            if (!err)   
               Console.WriteLine("\nRestore Database - SUCCESS\n");
            else
                Console.WriteLine("\nRestore Database - FAILURE\n");

        }

        public static void callCreateTable(string table)
        {
                DBtools d = new DBtools();
                bool err=d.createTable(table + ".sql");
                if(!err)
                    Console.WriteLine("\nCreate " + table + " - SUCCESS\n");
                else
                    Console.WriteLine("\n" + table + " Not Created \n");
        }
    }
}
