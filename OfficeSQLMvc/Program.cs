using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSQLMvc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeesList = new List<Employee>();
            List<Managers> managersList= new List<Managers>();
            string stringconnection = "Data Source=DESKTOP-IGIOI52;Initial Catalog=theOfficeDB;Integrated Security=True;Pooling=False";
            ShowAllTabels( stringconnection, employeesList);
            //GetUserInfo(stringconnection);
            //UpdateInfoFromUser(stringconnection);
            //DeleteEmployee(stringconnection,0);

            ////////////////////////////////////
            GetNewmanager(stringconnection);
        }
        private static void ShowAllTabels(string stringconnection, List<Employee> list)
        {
            using (SqlConnection connection = new SqlConnection(stringconnection))
            {
                connection.Open();
                string sql = @"SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader infoFromDB = cmd.ExecuteReader();
                if (infoFromDB.HasRows)
                {
                    while (infoFromDB.Read())
                    {
                        //list.Add(new Employee(infoFromDB.GetString(1), infoFromDB.GetDateTime(2), infoFromDB.GetString(3), infoFromDB.GetInt16(4)));
                        Console.WriteLine($"{infoFromDB.GetString(1)} {infoFromDB.GetDateTime(2)} {infoFromDB.GetString(3)} {infoFromDB.GetInt32(4)}");
                    }
                }
                else
                {
                    Console.WriteLine("No Rows In Table");
                }
                connection.Close();
            }
            Console.ReadLine();
        }
        private static void GetUserInfo(string stringconnection)
        {
            Console.WriteLine("enter firstname");
            string firstname = Console.ReadLine();
            Console.WriteLine("insert Birth");
            DateTime Birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("insert email");
            string email = Console.ReadLine();
            Console.WriteLine("insert Salary");
            int salary = int.Parse(Console.ReadLine());
            try
            {
                using (SqlConnection connection = new SqlConnection(stringconnection))
                {
                    connection.Open();
                    string insertQuery = $@"INSERT INTO Employees (Fname,Birth,Email,Salary) values ('{firstname}','{Birth}','{email}',{salary})";
                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    int dataFromDB = cmd.ExecuteNonQuery();
                    Console.WriteLine(dataFromDB);
                    connection.Close();
                }
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static void UpdateInfoFromUser(string stringconnection)
        {
            Console.WriteLine("insert Id");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("enter firstname");
            string firstname = Console.ReadLine();
            Console.WriteLine("insert Birth");
            DateTime Birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("insert email");
            string email = Console.ReadLine();
            Console.WriteLine("insert Salary");
            int salary = int.Parse(Console.ReadLine());
            try
            {
                using (SqlConnection connection = new SqlConnection(stringconnection))
                {
                    connection.Open();
                    string updateQuery = $@"UPDATE Employees SET  fName ='{firstname}',Birth = '{Birth}', Email='{email}',Salary={salary} WHERE Id = {ID} ";
                    SqlCommand cmd = new SqlCommand(updateQuery, connection);
                    int dataFromDB = cmd.ExecuteNonQuery();
                    Console.WriteLine(dataFromDB);
                    connection.Close();
                }
            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("General error");
            }
            Console.ReadLine();
        }
        private static void DeleteEmployee(string stringconnection, int id)
        {
            using (SqlConnection connection = new SqlConnection(stringconnection))
            {
                try
                {
                    connection.Open();
                    string str = $@"DELETE FROM Employees WHERE Id = {id}";
                    SqlCommand sqlCommand = new SqlCommand(str, connection);
                    int dataFromDB = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine(dataFromDB);
                    connection.Close ();
                }
                catch(SqlException err)
                {
                    Console.WriteLine(err.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("General Error");
                }
            }
        }

        private static void GetAllManagers(string stringconnection, List<Managers> list)
        {
            using (SqlConnection connection = new SqlConnection(stringconnection)) 
            {
                connection.Open();
                string managerQuery = $@"SELECT *  FROM  Managers";
                SqlCommand cmd = new SqlCommand(managerQuery, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString(1)}, {reader.GetString(2)}, {reader.GetDateTime(3)}, {reader.GetString(4)}, {reader.GetString(5)}");
                    }
                }
                else
                {
                    Console.WriteLine("No Rows In Table");
                }
                connection.Close();
            }


        }
        static void GetNewmanager(string stringconnection)
        {
            Console.WriteLine("insert firstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("insert lastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("insert Birth Year");
            DateTime Birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("insert email");
            string Email = Console.ReadLine();
            Console.WriteLine("insert Dapartment");
            string dapartment= Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(stringconnection)) 
            {
                try
                {

                connection.Open ();
                string managerQuery = $@"INSERT INTO Managers (Fname,Lname,Birth,Email,Department) values('{firstName}','{lastName}','{Birth}',{Email},'{dapartment}')";
                SqlCommand cmd = new SqlCommand (managerQuery,connection);
                int dataDb=cmd.ExecuteNonQuery();
                Console.WriteLine(dataDb);
                connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine( ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("General Error");
                }
            }
        }
        static void GetManagerId(string stringconnection)
        {
            Console.WriteLine("insert Id");
            int ID= int.Parse(Console.ReadLine());
            string firstName = Console.ReadLine();
            Console.WriteLine("insert lastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("insert Birth Year");
            DateTime Birth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("insert email");
            string Email = Console.ReadLine();
            Console.WriteLine("insert Dapartment");
            using (SqlConnection connection = new SqlConnection(stringconnection))
            {
                try
                {
                    connection.Open();
                    string managerQuery = $@"UPDATE Manager SET (Fname,Lname,Birth,Email,Deparment) Fname='{firstName}','{lastName}','{Birth}','{Email}' WHERE Id = {ID}";
                    SqlCommand cmd = new SqlCommand (managerQuery, connection);
                    int infoDB=cmd.ExecuteNonQuery();
                    Console.WriteLine(infoDB);

                }
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("This is an General Error");
                }
            }
        }
    }
}
