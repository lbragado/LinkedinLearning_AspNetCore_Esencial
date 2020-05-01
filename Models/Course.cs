using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaCursos.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage ="El número máximo de caracteres permitidos son 500")]        
        [Display(Name="Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage ="El autor es requerido")]
        [Display(Name = "Autor")]
        public string  Author { get; set; }

        [Url(ErrorMessage ="La dirección no es válida")]  //Este dataAnnotation nos ayuda a validar una URL
        [Display(Name = "Url")]
        public string Uri { get; set; }

    }
}
