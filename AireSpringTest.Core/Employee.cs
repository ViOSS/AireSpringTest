using System;
using System.ComponentModel.DataAnnotations;

namespace AireSpringTest.Core
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Field {0} must be between {1} and {2} characters.", MinimumLength = 3)]
        public string EmployeeLastName { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Field {0} must be between {1} and {2} characters.", MinimumLength = 3)]
        public string EmployeeFirstName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(14)]
        public string EmployeePhone { get; set; }

        [StringLength(15)]
        public string EmployeeZip { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
    }
}
