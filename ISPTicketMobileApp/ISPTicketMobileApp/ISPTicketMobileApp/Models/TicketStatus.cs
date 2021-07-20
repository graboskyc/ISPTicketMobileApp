using System;
using System.Collections.Generic;
using System.Text;
using Realms;
using MongoDB.Bson;


namespace ISPTicketMobileApp.Models
{
    class TicketStatus : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("option")]
        [Required]
        public string Option { get; set; }
    }
}
