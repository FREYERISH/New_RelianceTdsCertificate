using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceTdsCertificate.Service.IService
{
    public interface IOtpService
    {
        public string GenerateOtp(int length);

        public bool VerifyOtp(string otp, string hashOtp);

        public string HashOtp(string otp);
    }
}
