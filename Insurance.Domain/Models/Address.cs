using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Insurance.Domain.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O Logradouro não pode exceder {1} caracteres.")]
        public string Street { get; set; }        
        public AdressType AdressType { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "O Bairro não pode exceder {1} caracteres.")]
        public string Neighborhood { get; set; }
        [Required]
        public City City { get; set; }

    }
}
