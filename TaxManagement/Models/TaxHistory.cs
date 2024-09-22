using System.ComponentModel.DataAnnotations;

namespace TaxManagement.Models
{
    public class TaxHistory
    {
        [Key]
        public int TaxId { get; set; }
        public int ProfileId { get; set; }

        public DateTime Year { get; set; }
        public int Income { get; set; }
        public double TaxPaid { get; set; }
    }
}
