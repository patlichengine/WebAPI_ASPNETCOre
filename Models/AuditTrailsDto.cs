using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTracking.API.Models
{
    public class AuditTrailsDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Operation { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
    }

    

}

