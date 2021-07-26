using System;
using System.Collections.Generic;
using System.Text;
using Realms;
using MongoDB.Bson;

namespace ISPTicketMobileApp.Models
{
    class Ticket : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [MapTo("comment")]
        public string Comment { get; set; }
        [MapTo("ticketNumber")]
        public Int32 TicketNumber { get; set; }

        [MapTo("assignedTech")]
        public ObjectId Technician { get; set; }

        [MapTo("customer")]
        public ObjectId Customer { get; set; }
        [MapTo("status")]
        public string Status { get; set; }

    }
}
