using System;

namespace Profile.Api.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string IsoCountry2 { get; set; }
        public Gender Gender { get; set; }
    }
}
