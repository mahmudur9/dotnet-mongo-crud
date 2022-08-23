using DotnetMongoCrud.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMongoCrud.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> collection;

        public EmployeeRepository(IOptions<EmployeeDatabaseSettings> employeeDatabaseSettings)
        {
            var mongoClient = new MongoClient(employeeDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(employeeDatabaseSettings.Value.DatabaseName);
            collection = mongoDatabase.GetCollection<Employee>(
                employeeDatabaseSettings.Value.EmployeesCollectionName);
        }

        public async Task AddEmployee(Employee employee)
        {
            await collection.InsertOneAsync(employee);
        }

        public async Task<IList<Employee>> EmployeeList()
        {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await collection.ReplaceOneAsync(e => e.Id == employee.Id, employee);
        }

        public async Task DeleteEmployee(string id)
        {
            await collection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
