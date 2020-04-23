using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTracking.API.Models
{
    public class UsersDto
    {
        public Guid Id { get; set; }
        public string Lpno { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public Guid? DepartmentId { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public Guid? DesignationId { get; set; }
        public Guid? RankId { get; set; }
        public Guid? UserGroupId { get; set; }
        public bool? IsAccessGranted { get; set; }
        public bool? IsFirstLogin { get; set; }
        public bool? IsLocked { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Gender { get; set; }
    }
}
