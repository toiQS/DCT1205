
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DCT1205.Entity
{
    public class PaymentRecord
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [ForeignKey("TexYear")]
        public int TaxYearId { get; set; }
        public TaxYear? TaxYear { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        public string NiNo { get; set; }
        public DateTime PayDated { get; set; }
        public DateTime PayMonth { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HourlyRated { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal HourlyWorked { get; set; }
        [Column(TypeName = "money")]
        public decimal OvertimeHours { get; set;}
        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set;}
        [Column(TypeName = "money")]
        public decimal NIC { get; set; }
        [Column(TypeName = "money")]
        public decimal UnionFees { get; set; }
        [Column(TypeName = "money")]
        public Nullable<decimal> SLC { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalsEarnings { get; set;}
        [Column(TypeName = "money")]
        public decimal TotalsDeductions { get; set; }
        [Column(TypeName = "money")]
        public decimal NetPayment { get; set; }

    }
}
