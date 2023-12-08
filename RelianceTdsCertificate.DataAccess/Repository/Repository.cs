using Microsoft.EntityFrameworkCore;
using RelianceTdsCertificate.DataAccess.IRepository;
using RelianceTdsCertificate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceTdsCertificate.DataAccess.Repository
{
    public class Repository : IRepository<Employee>
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.LoginInfo.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.LoginInfo.ToListAsync();
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _dbContext.LoginInfo.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            _dbContext.LoginInfo.Update(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                _dbContext.LoginInfo.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
