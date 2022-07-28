using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.API.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Required(ErrorMessage="Employee ID is required"), Column("EmployeeID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Employee ID")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Employee First Name is required"), Column("FirstName"), Display(Name="First Name")]
        [StringLength(20, ErrorMessage = "First Name must be less than 20 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Employee Last Name is required"), Column("LastName"), Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last Name must be less than 30 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Employee Title is required"), Column("Title")]
        [StringLength(30, ErrorMessage = "Title must be less than 30 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Employee Birth Date is required"), Display(Name="Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Employee hire date is required"), Display(Name="Hire Date")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "Employee Country is required"), StringLength(30, ErrorMessage = "Country must be less than 30 characters")]
        public string Country { get; set; }
        [StringLength(500, ErrorMessage = "Notes must be less than 500 characters")]
        public string Notes { get; set; }
    }
}
