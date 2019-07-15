using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AireSpringTest.Core
{
    //This class contains data anotations in order to EntityFramework creates the table.
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Field {0} must be between {1} and {2} characters.", MinimumLength = 1)]
        public string EmployeeLastName { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Field {0} must be between {1} and {2} characters.", MinimumLength = 1)]
        public string EmployeeFirstName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(14)]
        public string EmployeePhone { get; set; }

        [StringLength(15)]
        public string EmployeeZip { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
