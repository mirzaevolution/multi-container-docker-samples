using System;

namespace Profile.Api.Models
{
    public class UserProfileModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string IsoCountry2 { get; set; }
        public string Gender { get; set; }
    }
}
