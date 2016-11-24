using Microsoft.AspNet.Identity;
using MongoDB.Driver;
using Russian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Russian.App_Start
{

    public class UserStore<ApllicationUser> : IUserStore<ApplicationUser>,
    IUserPasswordStore<ApplicationUser>
    //IUserRoleStore<TUser>,
    //IUserLoginStore<TUser>,
    //IUserSecurityStampStore<TUser>,
    //IUserEmailStore<TUser>,
    //IUserClaimStore<TUser>,
    //IUserPhoneNumberStore<TUser>,
    //IUserTwoFactorStore<TUser, string>,
    //IUserLockoutStore<TUser, string>
    //where TUser : IdentityUser
    {
        private readonly ApplicationIdentityContext _context;

        public UserStore(ApplicationIdentityContext context)
        {
            _context = context;
        }

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

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return _context.Users.Find(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

    }
}
