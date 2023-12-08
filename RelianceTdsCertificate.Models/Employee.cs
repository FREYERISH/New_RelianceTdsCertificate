using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceTdsCertificate.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "PAN number must be exactly 10 characters.")]
        public string? EmployeePanNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string? EmployeeName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Role must be between 2 and 50 characters.")]
        public string? EmployeeRole { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? EmployeeEmailId { get; set; }

    }
}
