using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Insurance.Domain.Models
{
    public class State
    {
        public int StateId { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "O Estado não pode conter mais de  {1} caracteres.")]
        public string Name { get; set; }
        public Country Country { get; set; }

        
     

    }
}
