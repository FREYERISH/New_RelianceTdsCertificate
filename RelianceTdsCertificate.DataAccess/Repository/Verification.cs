using RelianceTdsCertificate.DataAccess.IRepository;
using RelianceTdsCertificate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceTdsCertificate.DataAccess.Repository
{
    public class Verification:IVerification<Employee>
    {
        private readonly ApplicationDbContext _dbContext;

        public Verification(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetEmailId(string empPanNumber)
        {
            
            Employee emp = _dbContext.LoginInfo.FirstOrDefault(u=>u.EmployeePanNumber==empPanNumber);
            string empEmailId = emp.EmployeeEmailId;
            return empEmailId;
        }

        public string GetRole(string empPanNumber)
        {
            Employee emp = _dbContext.LoginInfo.FirstOrDefault(u => u.EmployeePanNumber == empPanNumber);
            string empRole = emp.EmployeeRole;
            return empRole;
        }

        public Otp RetrieveOtpFromDb(string employeePan, string hashOtp)
        {
            return _dbContext.OtpInfo
                .FirstOrDefault(o => o.EmployeePanNumber == employeePan && o.HashedOTP == hashOtp);
        }


        public void StoreOtpInDb(string employeePan, string hashOtp)
        {
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(5);

            var existingOtpEntry = _dbContext.OtpInfo.FirstOrDefault(o => o.EmployeePanNumber == employeePan);

            if (existingOtpEntry != null)
            {
                _dbContext.OtpInfo.Remove(existingOtpEntry); // Remove the existing OTP entry
            }

            var otpEntry = new Otp
            {
                EmployeePanNumber = employeePan,
                HashedOTP = hashOtp,
                ExpirationTime = expirationTime
            };

            _dbContext.OtpInfo.Add(otpEntry); // Add the new OTP entry
            _dbContext.SaveChanges();
        }

        public string GetHashedOtpByPan(string employeePan)
        {
            var otpEntry = _dbContext.OtpInfo.FirstOrDefault(o => o.EmployeePanNumber == employeePan);

            if (otpEntry != null)
            {
                return otpEntry.HashedOTP;
            }

            // If no matching OTP is found for the provided PAN, return null or handle accordingly
            return null;
        }

        public Employee GetEmployee(string panNumber)
        {
            Employee employee = _dbContext.LoginInfo.FirstOrDefault(u=>u.EmployeePanNumber==panNumber);
            return employee;
        }
    }
}
