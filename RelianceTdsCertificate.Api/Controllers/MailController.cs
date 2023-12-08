
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using RelianceTdsCertificate.DataAccess.IRepository;
using RelianceTdsCertificate.Models;
using RelianceTdsCertificate.Service.IService;

namespace RelianceTdsCertificate.Api.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        private readonly IVerification<Employee> _verification;

        private readonly IOtpService _otpService;
        public MailController(IMailService mailService,IOtpService otpService,IVerification<Employee> verification)
        {
            _verification = verification;
            _mailService = mailService;
            _otpService = otpService;
        }
        [HttpPost("GenerateOtp")]
        public IActionResult GenerateOTPAndEmail([FromBody] OtpRequest empPanNumber)
        {
           string panNumber = empPanNumber.EmpPanNumber;
            try
            {
                // Fetch email corresponding to the PAN number from repository
                string userEmail = _verification.GetEmailId(panNumber);
                

                if (!string.IsNullOrEmpty(userEmail))
                {
                    // Generate OTP
                    string otp = _otpService.GenerateOtp(6); // 6-digit OTP

                    // Hash OTP
                    string hashedOTP = _otpService.HashOtp(otp);

                    // Store hashed OTP in the database
                    _verification.StoreOtpInDb(panNumber, hashedOTP);

                    // Send OTP to the email
                    MailRequest mailRequest = new MailRequest();
                    mailRequest.ToEmail = userEmail;
                    mailRequest.Subject = "OTP Verification";
                    mailRequest.Body = $"Hi User! Your OTP is {otp}. It will expire in 5 minutes. Please do not share your OTP with anyone.";
                    _mailService.SendEmailAsync(mailRequest);

                    // Return success response
                    return Ok("OTP generated and sent successfully.");
                }
                else
                {
                    return BadRequest("User with provided PAN number not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return error response
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost("VerifyOtp")]

        public IActionResult VerifyOtp([FromBody] VerifyOtpRequest otpRequest)
        {
            try
            {


            string hashOtp = _otpService.HashOtp(otpRequest.Otp);

            Otp dbOtp = _verification.RetrieveOtpFromDb(otpRequest.PanNumber, hashOtp);

            if (dbOtp == null)
            {
                return Ok("Invalid OTP!");
            }
            else if(dbOtp.ExpirationTime>DateTime.UtcNow)
                {
                    Employee emp = _verification.GetEmployee(otpRequest.PanNumber);
                    return Ok(emp);
                }
                else
                {
                    return Ok("Otp Expired! Generate New OTP");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request.");

            }
            
        }

        

    }
}
