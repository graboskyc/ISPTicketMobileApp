using System;
using System.Collections.Generic;
using System.Text;
using Realms;
using MongoDB.Bson;

namespace ISPTicketMobileApp.Models
{
    class Technician : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("phone")]
        [Required]
        public string Phone { get; set; }
    }
}
