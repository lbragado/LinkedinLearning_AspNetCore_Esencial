using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaCursos.Interfaces;
using ListaCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaCursos.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        public Course   Course { get; set; }

        /// <summary>
        /// Instanciaremos un proveedor
        /// </summary>
        /// <param name="coursesProvider">Recordemos que en la clase Startup hacemos una inyección de dependiencias
        /// para que cuando se haga un llamado a la interface ICoursesProvider genere un proveedor de tipo
        /// FakeCoursesProvider</param>
        public DetailsModel(ICoursesProvider coursesProvider)
        {            
            this.coursesProvider = coursesProvider;
        }

        public async Task<ActionResult> OnGet(int id)
        {
            var course = await coursesProvider.GetAsync(id);
            if (course != null)
            {
                Course = course;
                return Page();
            }
            else
            {
                //En caso de que el id sea incorrecto y no se encuentre un curso lo redireccionamos a la lista 
                return RedirectToPage("Courses");
            }                
            
        }
    }
}