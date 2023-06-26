﻿using AP_ApiNet6.Application.DTOs;
using AP_ApiNet6.Domain.FiltersDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        Task<ResultService<ICollection<PersonDTO>>> GetAsync();
        Task<ResultService<PersonDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(PersonDTO personDTO);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);
    }
}
