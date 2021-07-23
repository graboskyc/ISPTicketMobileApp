using System;
using System.Collections.Generic;
using System.Text;
using Realms;
using MongoDB.Bson;

namespace ISPTicketMobileApp.Models
{
    class Customer : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("accountNumber")]
        public Int32 AccountNumber { get; set; }

        [MapTo("billingAddress")]
        [Required]
        public string Address { get; set; }

        [MapTo("birthday")]
        public DateTimeOffset Birthday { get; set; }

        [MapTo("email")]
        [Required]
        public string Email { get; set; }

        [MapTo("fullname")]
        [Required]
        public string Name { get; set; }

        [MapTo("notes")]
        [Required]
        public string Notes { get; set; }

        [MapTo("occupation")]
        [Required]
        public string Occupation { get; set; }

        [MapTo("primaryPhone")]
        [Required]
        public string Phone { get; set; }

        [MapTo("serviceType")]
        [Required]
        public string ServiceType { get; set; }

        [MapTo("ssn")]
        [Required]
        public string SSN { get; set; }

        [MapTo("state")]
        [Required]
        public string State { get; set; }

        [MapTo("zipcode")]
        [Required]
        public string Zipcode { get; set; }

    }
}
