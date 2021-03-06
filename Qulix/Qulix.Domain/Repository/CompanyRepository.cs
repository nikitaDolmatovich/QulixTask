﻿using System;
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

        public void Add(Company item, int id)
        {
            string expression = "SET IDENTITY_INSERT dbo.Company ON;INSERT INTO Company(CompanyId, Name, SizeCompany, OrganizationalForm)VALUES" +
                $"('{id}', '{item.Name}', '{item.SizeCompany}', '{item.OrganizationalForm}')";
            Execute(expression);
        }

        public void Delete(int itemId)
        {
            string expression = $"DELETE FROM Company WHERE CompanyId = {itemId}";
            Execute(expression);
        }

        public void Update(int itemId, Company item)
        {
            string expression = $"UPDATE Company SET Name = '{item.Name}', SizeCompany = '{item.SizeCompany}'," +
                $"OrganizationalForm = '{item.OrganizationalForm}' where CompanyId = {itemId}";
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
                        SizeCompany = (string)reader["SizeCompany"],
                        OrganizationalForm = (string)reader["OrganizationalForm"]
                    });
                }
                sqlConnection.Close();
            }

            return companies;
        }

        public Company GetCompanyById(int companyId)
        {
            string expression = $"SELECT * FROM Company WHERE CompanyId = {companyId}";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand(expression, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                return new Company()
                {
                    CompanyId = (int)reader["CompanyId"],
                    Name = (string)reader["Name"],
                    SizeCompany = (string)reader["SizeCompany"],
                    OrganizationalForm = (string)reader["OrganizationalForm"]
                };
            }
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
