using AP_ApiNet6.Application.DTOs;
using AP_ApiNet6.Application.DTOs.Validations;
using AP_ApiNet6.Application.Services.Interfaces;
using AP_ApiNet6.Domain.Entities;
using AP_ApiNet6.Domain.Integrations;
using AP_ApiNet6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.Services
{
    public class PersonImageService : IPersonImageService
    {
        private readonly IPersonImageRepository _personImageRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ISavePersonImage _savePersonImage;

        public PersonImageService(IPersonImageRepository personImageRepository, IPersonRepository personRepository, ISavePersonImage savePersonImage)
        {
            _personImageRepository = personImageRepository;
            _personRepository = personRepository;
            _savePersonImage = savePersonImage;
        }

        public async Task<ResultService> CreateImageAsync(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var result = new PersonImageDTOValidator().Validate(personImageDTO);
            if (!result.IsValid)
                return ResultService.RequestError("Problemas de validade!", result);

            var person = await _personRepository.GetByIdAsync(personImageDTO.PersonId);

            if (person == null)
                return ResultService.Fail<PersonDTO>("Id Pessoa não encontrada!");

            var pathImage = _savePersonImage.Save(personImageDTO.Image);
            var personImage = new PersonImage(person.Id, pathImage, null);

            await _personImageRepository.CreateAsync(personImage);
            return ResultService.Ok("Imagem salva.");
        }

        public async Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO)
        {
            if (personImageDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var result = new PersonImageDTOValidator().Validate(personImageDTO);
            if (!result.IsValid)
                return ResultService.RequestError("Problemas de validade!", result);

            var person = await _personRepository.GetByIdAsync(personImageDTO.PersonId);

            if (person == null)
                return ResultService.Fail<PersonDTO>("Id Pessoa não encontrada!");

            var personImage = new PersonImage(person.Id, null, personImageDTO.Image);

            await _personImageRepository.CreateAsync(personImage);
            return ResultService.Ok("Imagem em base64 salva.");
        }
    }
}
