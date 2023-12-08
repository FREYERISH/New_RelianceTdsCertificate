using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceTdsCertificate.Models
{
    public class Otp
    {
        public int Id { get; set; }
        public string EmployeePanNumber { get; set; }
        public string HashedOTP { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
