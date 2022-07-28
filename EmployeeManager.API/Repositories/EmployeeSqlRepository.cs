using EmployeeManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.API.Repositories
{
    public class EmployeeSqlRepository : IEmployeeRepository
    {
        private readonly AppDbContext db = null;
        public EmployeeSqlRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            db.Database.ExecuteSqlRaw($"Delete from Employees where EmployeeId = {id}");
        }

        public void Insert(Employee emp)
        {
            db.Database.ExecuteSqlRaw($"Insert into Employees(FirstName, LastName, Title, BirthDate, HireDate, Country, Notes) values({emp.FirstName}, {emp.LastName}, {emp.Title}, {emp.BirthDate}, {emp.HireDate}, {emp.Country}, {emp.Notes})");
        }

        public List<Employee> SelectAll()
        {
            List<Employee> data = db.Employees.FromSqlRaw("select EmployeeId, FirstName, LastName, Title, BirthDate, HireDate, Country, Notes from employees order by EmployeeId").ToList();
            return data;
        }

        public Employee SelectByID(int id)
        {
            Employee emp = db.Employees.FromSqlRaw($"select EmployeeId, FirstName, LastName, Title, BirthDate, HireDate, Country, Notes from employees where EmployeeId = {id}").SingleOrDefault();

            return emp;
        }

        public void Update(Employee emp)
        {
            db.Database.ExecuteSqlRaw($"update Employees set FirstName={emp.FirstName}, LastName={emp.LastName}, Title={emp.Title}, BirthDate={emp.BirthDate}, HireDate={emp.HireDate}, Country={emp.Country}, Notes={emp.Notes}");
        }
    }
}
