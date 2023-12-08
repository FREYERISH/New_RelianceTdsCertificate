using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RelianceTdsCertificate.Models;
using System.Diagnostics;

using RelianceTdsCertificate.DataAccess.Repository;
using RelianceTdsCertificate.DataAccess.IRepository;
using RelianceTdsCertificate.Service.IService;

namespace RelianceTdsCertificate.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMailService mailService;

        private readonly IVerification<Employee> _verification;
       

        public LoginController(IVerification<Employee> verification, IMailService mailService)
        {
            _verification = verification;
            this.mailService = mailService;

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public void GetOtp(string empPanNumber)
        {

            string empEmailId =  _verification.GetEmailId(empPanNumber);
            //string otp = mailService.GenerateOtp();
            //string empRole = _verification.GetRole(empPanNumber);
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = empEmailId;
            mailRequest.Subject = "OTP Verification";
            //mailRequest.Body = "Your OTP is "+ otp;
            mailService.SendEmailAsync(mailRequest);

        }

        

        [HttpPost]

        public IActionResult SubmitOtp(int otp)
        {


            return RedirectToAction("Login");
           
        }

        








        //Error View 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

       

    }
}