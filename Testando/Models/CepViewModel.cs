using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testando.Models
{
    public class CepViewModel
    {
        [Required(ErrorMessage="Campo Obrigatorio")]
        [RegularExpression(@"\d{5}-\d{3}",ErrorMessage="Utilize o formato 00000-000")]
        public String Cep { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}