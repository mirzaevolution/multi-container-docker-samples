using Microsoft.EntityFrameworkCore;
using Profile.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profile.Api.Services
{

    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileModel>> GetAll();
    }

    public class UserProfileService : IUserProfileService
    {
        private readonly ProfileDbContext _context;
        public UserProfileService(ProfileDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserProfileModel>> GetAll()
        {
            var list = await _context.UserProfiles.ToListAsync();
            List<UserProfileModel> result = new List<UserProfileModel>();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    result.Add(new UserProfileModel
                    {
                        Id = item.Id,
                        Email = item.Email,
                        FullName = item.FullName,
                        IsoCountry2 = item.IsoCountry2,
                        Gender = item.Gender.ToString()
                    });
                }
            }
            return result;
        }
    }
}
