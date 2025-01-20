using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsistenciasCrud.Shared
{
    internal class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; } = null!;
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoP { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string ApellidoM { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Correo { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El campo {0} debe tener exactamente 10 dígitos numéricos")]
        public string Telefono { get; set; } = null!;
    }
}
