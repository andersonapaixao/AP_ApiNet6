using AP_ApiNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AP_ApiNet6.Domain.Entities
{
    public class PersonImage
    {
        public PersonImage(int personId, string? imageUri, string? imageBase)
        {
            Validation(personId);
            ImageUri = imageUri;
            ImageBase = imageBase;
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string? ImageUri { get; set; }
        public string? ImageBase { get; set; }
        public Person Person { get; set; }

        private void Validation(int personId)
        {
            DomainValidationException.When(personId == 0, "Id deve ser informado!");

            PersonId = personId;
        }
    }
}
