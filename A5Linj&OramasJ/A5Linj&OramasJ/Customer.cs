/* Customer.cs
 * A class representing a customer for the database
 * 
 * Revision History:  
 *      Jiadong Lin, 2023.04.12: Created
 *      Jose Oramas, 2023.04.14: Implemented customer's main functionality
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5Linj_OramasJ
{
    internal class Customer
    {
        private string m_email = "", m_name = "";
        private int m_id = -1, m_age = -1;

        // NOTE: Default constructor
        public Customer()
        {
            m_id = -1;
            m_name = "";
            m_email = "";
            m_age = -1;
        }

        public Customer(int id, string name, int age, string email)
        {
            m_id = id;
            m_name = name;
            m_age = age;
            m_email = email;
        }

        public int GetId() { return m_id;  }
        public string GetEmail() { return m_email; }

        public void SetName(string name) { m_name = name; }
        public void SetAge(int age) { m_age = age; }
        public void SetEmail(string email) { m_email = email; }

        public void DisplayCustomerInformation()
        {
            Console.WriteLine($"Customer {m_id}: {m_name}, {m_age} years, email: {m_email}.");
        }

        public void EditCustomerInformation(string name, int age, string email)
        {
            m_name = name;
            m_age = age;
            m_email = email;
        }
    }
}
