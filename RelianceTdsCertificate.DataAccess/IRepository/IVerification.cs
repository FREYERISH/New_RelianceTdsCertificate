using RelianceTdsCertificate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceTdsCertificate.DataAccess.IRepository
{
    public interface IVerification<T>
    {
        public string GetEmailId(string panNumber);

        public string GetRole(string panNumber);

        public void StoreOtpInDb(string employeePan, string hashOtp);

        public Otp RetrieveOtpFromDb(string employeePan, string hashOtp);

        public Employee GetEmployee(string panNumber);

       

    }
}
