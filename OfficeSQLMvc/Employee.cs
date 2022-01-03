using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeSQLMvc
{
    public class Employee
    {
       public string firstName;
       public DateTime birth;
       public string email;
       public int salary;

        public Employee(string firstName, DateTime birth, string email, int salary)
        {
            this.firstName = firstName;
            this.birth = birth;
            this.email = email;
            this.salary = salary;
        }
    }
}
