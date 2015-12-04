using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcIdiomas.Idiomas;

namespace MvcIdiomas.Models
{
    public class Persona
    {
        [Display(ResourceType = typeof(Personas),Name = "nombre")]
        [Required(ErrorMessageResourceType = typeof(Personas), 
                  ErrorMessageResourceName = "nombreObligatorio")]
        public String Nombre { get; set; }

        [Display(ResourceType = typeof(Personas), Name = "saldo")]
        [Required(ErrorMessageResourceType = typeof(Personas),
                  ErrorMessageResourceName = "saldoObligatorio")]
        [DataType(DataType.Currency,ErrorMessageResourceType = 
                  typeof(Personas),ErrorMessageResourceName = "saldoIncorrecto")]
        public double Saldo { get; set; }
    }
}