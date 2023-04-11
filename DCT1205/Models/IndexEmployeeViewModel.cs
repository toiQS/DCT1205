using DCT1205.Entity;
using System.ComponentModel.DataAnnotations;

namespace DCT1205.Models
{
    public class IndexEmployeeViewModel
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

    }
}
