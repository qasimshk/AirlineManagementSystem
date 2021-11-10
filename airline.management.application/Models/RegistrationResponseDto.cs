using System.Collections.Generic;

namespace airline.management.application.Models
{
    public class RegistrationResponseDto 
    {  
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
