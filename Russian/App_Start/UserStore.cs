using Microsoft.AspNet.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Russian.Models;

namespace Russian.App_Start
{
    public class UserStore<ApplicationUser, TRole> : IUserStore<ApplicationUser>
         //IUserPasswordStore<TUser>,
         //IUserRoleStore<TUser>,
         //IUserLoginStore<TUser>,
         //IUserSecurityStampStore<TUser>,
         //IUserEmailStore<TUser>,
         //IUserClaimStore<TUser>,
         //IUserPhoneNumberStore<TUser>,
         //IUserTwoFactorStore<TUser, string>,
         //IUserLockoutStore<TUser, string>
         where TUser : IdentityUser
         where TRole : IdentityRole
    {
        private readonly ApplicationIdentityContext _context;

        private static FilterDefinition<ApplicationUser> GetUserFilter(ApplicationUser user)// use for methods with users
        {
            return Builders<ApplicationUser>.Filter.Where(u => u.Id == user.Id);
        }

        public Task CreateAsync(ApplicationUser user)
        {
            return _context.Users.InsertOneAsync(user);
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            var filter = GetUserFilter(user);
            return _context.Users.DeleteOneAsync(filter);
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            var filter = GetUserFilter(user);
            return _context.Users.ReplaceOneAsync(filter, user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return _context.Users.Find(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return _context.Users.Find(u => u.UserName == userName).FirstOrDefaultAsync();
        }

       
    }
}