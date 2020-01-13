using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Insurance.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
        public string Name { get; set; }
        [Required]
        public string TaxIdentification { get; set; }
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBith { get; set; }
        public IList<Address> Address { get; set; }
               
    }
}
