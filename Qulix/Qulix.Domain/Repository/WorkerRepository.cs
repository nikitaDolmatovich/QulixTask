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

        public void Add(Worker item)
        {
            string expression = "INSERT INTO Worker(WorkerId, Name, Surname, Patronymic,DateRecruitment," +
                "Position, CompanyId)VALUES" + $"('{item.WorkerId}', '{item.Name}','{item.Surname}','{item.Patronymic}'," +
                $"'{item.DateRecruitment}', '{item.Position}', '{item.CompanyId}'";
            Execute(expression);
        }

        public void Delete(int itemId)
        {
            string expression = $"DELETE FROM WORKER WHERE WorkerId = {itemId} ";
            Execute(expression);
        }

        public void Update(int itemId, Worker item)
        {
            string expression = $"UPDATE Worker SET Name = '{item.Name}', Surname = '{item.Surname}', '{item.Patronymic}'," +
                $"'{item.DateRecruitment}', '{item.Position}','{item.CompanyId}' WHERE WorkerId = {item.WorkerId}";
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
