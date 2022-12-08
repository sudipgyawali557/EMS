using System.ComponentModel;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        public int employeeId { get; set; }
        [DisplayName("Name")]
        public string? name { get; set; }
        [DisplayName("Email")]
        public string? email { get; set; }
        [DisplayName("Phone Number")]
        public int phone { get; set; }
        [DisplayName("Address")]
        public string? address { get; set; }
        [DisplayName("Department")]
        public string? department { get; set; }
        [DisplayName("Designation")]
        public string? designation { get; set; }
        [DisplayName("Date of birth")]
        public string? dob { get; set; }
        [DisplayName("Gender")]
        public string? gender { get; set; }
        [DisplayName("Date of join")]
        public string? doj { get; set; }
        [DisplayName("Salary")]
        public int salary { get; set; }
        [DisplayName("Maritual Status")]
        public string? status { get; set; }
        [DisplayName("Country")]
        public string? country { get; set; }

    }
}
