using RelianceTdsCertificate.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RelianceTdsCertificate.Service
{
    public class OtpService : IOtpService
    {
        public string GenerateOtp(int length)
        {
            const string chars = "0123456789"; // Characters to use in OTP
            var random = new Random();
            var otp = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return otp;
        }

        public string HashOtp(string otp)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(otp));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

       

        public bool VerifyOtp(string otp, string hashOtp)
        {
            string hashedEnteredOTP = HashOtp(otp); // Hash entered OTP for comparison
            return string.Equals(hashedEnteredOTP, hashOtp);
        }
    }
}
