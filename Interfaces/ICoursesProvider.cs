﻿using ListaCursos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListaCursos.Interfaces
{
    public interface ICoursesProvider
    {
        Task<ICollection<Course>> GetAllAsync();

        Task<Course> GetAsync(int id);

        Task<ICollection<Course>> SearchAsync(string search);

        Task<bool> UpdateAsync(int id, Course coures);

        Task<(bool IsSuccess, int? Id)> AddSync(Course course);
    }
}
