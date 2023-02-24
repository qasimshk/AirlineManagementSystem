using System;
using System.Collections.Generic;

namespace airline.management.application.Models
{
    public class UserClaimsDto
    {
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; }
        public bool Success { get; set; }
        public string Role { get; set; }
        public List<string> Errors { get; set; }
    }
}
