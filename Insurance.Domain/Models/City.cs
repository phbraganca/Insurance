using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Insurance.Domain.Models
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "A Cidade não pode conter mais de {1} caracteres.")]
        public string Name { get; set; }
        public State State { get; set; }
        
        
        

    }
}
