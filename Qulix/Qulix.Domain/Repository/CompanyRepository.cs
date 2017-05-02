using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Qulix.Domain.Models;

namespace Qulix.Domain.Repository
{
    public class CompanyRepository : IRepository<Company>
    {
        private string connectionString;

        public CompanyRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Company item)
        {
            string expression = "INSERT INTO Company(CompanyId, Name, SizeCompany, OrganizationalForm)VALUES" +
                $"('{item.CompanyId}', '{item.Name}', '{item.SizeCompany}', '{item.OrganizationalForm}')";
            Execute(expression);
        }

        public void Delete(int itemId)
        {
            string expression = $"DELETE FROM Company WHERE ComapnyId = {itemId}";
            Execute(expression);
        }

        public void Update(int itemId, Company item)
        {
            string expression = $"UPDATE Company SET Name = '{item.Name}' SizeCompany = '{item.SizeCompany}'" +
                $"OrganizationalForm = '{item.OrganizationalForm}'";
            Execute(expression);
        }

        public IEnumerable<Company> GetAll()
        {
            List<Company> companies = new List<Company>();
            string expression = "SELECT * FROM Company";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand(expression, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    companies.Add(new Company()
                    {
                        CompanyId = (int)reader["CompanyId"],
                        Name = (string)reader["Name"],
                        SizeCompany = (int)reader["SizeCompany"],
                        OrganizationalForm = (string)reader["OrganizationalForm"]
                    });
                }
            }

            return companies;
        }

        public void Execute(string expression)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand(expression, sqlConnection);
                command.ExecuteNonQuery();
            }
        }
    }
}
