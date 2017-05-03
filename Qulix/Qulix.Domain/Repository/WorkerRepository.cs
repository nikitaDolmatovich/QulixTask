using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Qulix.Domain.Models;

namespace Qulix.Domain.Repository
{
    public class WorkerRepository : IRepository<Worker>
    {
        private string connectionString;

        public WorkerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Worker item, int id)
        {
            string expression = "SET IDENTITY_INSERT dbo.Worker ON;INSERT INTO Worker(WorkerId, Name, Surname, Patronymic,DateRecruitment," +
                "Position, CompanyId)VALUES" + $"('{item.WorkerId}', '{item.Name}','{item.Surname}','{item.Patronymic}'," +
                $"'{item.DateRecruitment}', '{item.Position}', '{id}')";
            Execute(expression);
        }

        public void Delete(int itemId)
        {
            string expression = $"DELETE FROM WORKER WHERE WorkerId = {itemId} ";
            Execute(expression);
        }

        public void Update(int itemId, Worker item)
        {
            string expression = $"UPDATE Worker SET Name = '{item.Name}', Surname = '{item.Surname}', Patronymic = '{item.Patronymic}'," +
                $"DateRecruitment = '{item.DateRecruitment}', Position =  '{item.Position}',CompanyId = '{item.CompanyId}' WHERE WorkerId = {item.WorkerId}";
            Execute(expression);
        }

        public IEnumerable<Worker> GetAll()
        {
            List<Worker> workers = new List<Worker>();
            string expression = "SELECT * FROM Worker";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand(expression, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    workers.Add(new Worker()
                    {
                        WorkerId = (int)reader["WorkerId"],
                        Name = (string)reader["Name"],
                        Surname = (string)reader["Surname"],
                        Patronymic = (string)reader["Patronymic"],
                        DateRecruitment = (DateTime)reader["DateRecruitment"],
                        Position = (string)reader["Position"],
                        CompanyId = (int)reader["CompanyId"]
                    });
                }
            }

            return workers;
        }

        public Worker GetWorkerById(int workerId)
        {
            string expression = $"SELECT * FROM Worker WHERE WorkerId = {workerId}";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand(expression, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                return new Worker()
                {
                    WorkerId = (int)reader["WorkerId"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Patronymic = (string)reader["Patronymic"],
                    DateRecruitment = (DateTime)reader["DateRecruitment"],
                    Position = (string)reader["Position"],
                    CompanyId = (int)reader["CompanyId"]
                };
            }
        }

        //Get CompanyId acroos Name
        public int GetIdCompanyByName(string name)
        {
            string expression = $"SELECT CompanyId FROM Company WHERE Name = {name}";
            int id = 0;

            using (var sqlCOnnection = new SqlConnection(connectionString))
            {
                sqlCOnnection.Open();
                var command = new SqlCommand(expression, sqlCOnnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = (int)reader["CompanyId"];
                }
            }

            return id;
        }

        //Get Name across id
        public string GetNameCompanyById(int id)
        {
            string expression = $"SELECT Name FROM Company WHERE CompanyId = {id}";
            string name = null;

            using (var sqlCOnnection = new SqlConnection(connectionString))
            {
                sqlCOnnection.Open();
                var command = new SqlCommand(expression, sqlCOnnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    name = (string)reader["Name"];
                }
            }

            return name;
        }

        public void Execute(string expression)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var command = new SqlCommand(expression,sqlConnection);
                command.ExecuteNonQuery();
            }
        }
    }
}
