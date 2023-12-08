using RelianceTdsCertificate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelianceTdsCertificate.Service.IService;

namespace RelianceTdsCertificate.Service.IService;

public interface IMailService
{

    Task SendEmailAsync(MailRequest mailRequest);

}





