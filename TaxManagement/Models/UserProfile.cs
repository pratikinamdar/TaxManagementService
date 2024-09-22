using System.ComponentModel.DataAnnotations;

namespace TaxManagement.Models
{
    public class UserProfile
    {
        [Key]
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Contact {  get; set; }

        public bool Single { get; set; }

        public int Income { get; set; }
    }

    public class UserParams
    {
        public string Name { get; set; }
        public string Contact { get; set; }

        public bool Single { get; set; }

        public int Income { get; set; }
    }


    public class UserTax
    {
        public string Name { get; set; }
        public string Contact { get; set; }

        public bool Single { get; set; }
        public int Income { get; set; }

        public double Tax { get; set; }
    }

    public class TaxCalInput
    {
        public int ProfileId { get; set; }
        public DateTime Year { get; set; }
    }
}
