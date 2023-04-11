using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT1205.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string EmployeeNo { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }

        //Edit Datetime to String - 23/03/2023
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NationalInsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public UnionMember UnionMember { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]
        public string Postcode { get; set; }
    }
}
