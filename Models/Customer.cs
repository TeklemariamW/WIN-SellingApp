using System.ComponentModel.DataAnnotations;

namespace WIN_sellingApp.Models
{
    public class Customer
    {
        public int Customerid { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int TelephoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}