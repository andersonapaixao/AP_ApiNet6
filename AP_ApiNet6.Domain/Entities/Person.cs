﻿using AP_ApiNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<PersonImage> PersonImages { get; set; }

        public Person(string document, string name, string phone)
        {
            Validation(document, name, phone);
            Purchases = new List<Purchase>();
            PersonImages = new List<PersonImage>();
        }
        public Person(int id, string document, string name, string phone)
        {
            DomainValidationException.When(id < 0, "Id deve ser maior que zero!");
            Id = id;
            Validation(document, name, phone);
            Purchases = new List<Purchase>();
            PersonImages = new List<PersonImage>();
        }
        private void Validation(string document, string name, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Celular deve ser informado!");

            Name = name;
            Document = document;
            Phone = phone;
        }

    }
}
