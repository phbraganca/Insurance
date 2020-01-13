using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Insurance.Domain.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "O País não pode conter mais de {1} caracteres.")]
        public string Name { get; set; }


    }
}
