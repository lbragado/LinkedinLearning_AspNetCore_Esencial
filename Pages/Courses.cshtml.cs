using System.Collections.Generic;
using System.Threading.Tasks;
using ListaCursos.Interfaces;
using ListaCursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaCursos.Pages
{
    public class CoursesModel : PageModel
    {
        private readonly ICoursesProvider coursesProvider;

        public List<Course> Courses { get; set; }

        public CoursesModel(ICoursesProvider coursesProvider)
        {
            this.coursesProvider = coursesProvider;
        }

        [BindProperty(SupportsGet =true)]
        public string Search { get; set; }

        /// <summary>
        /// Se ejecuta este método cuando se hace una petición GET
        /// </summary>
        public async Task<IActionResult> OnGet()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                var results = await coursesProvider.SearchAsync(Search);
                if (results != null)
                {
                    Courses = new List<Course>(results);
                }
            }
            else
            {
                var results = await coursesProvider.GetAllAsync();
                if (results != null)
                {
                    Courses = new List<Course>(results);
                }
            }

            return Page();
        }
    }
}
