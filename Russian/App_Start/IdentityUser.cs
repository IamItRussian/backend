using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;

namespace Russian.App_Start
{
    public class IdentityUser : IUser<string>
    {
        public IdentityUser()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Roles = new List<string>();
            Logins = new List<UserLoginInfo>();
            Claims = new List<IdentityUserClaim>();
        }

        public string Id{ get; }

        public string UserName{ get; set; }
        public virtual string Email { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual IList<string> Roles { get; set; }

        public virtual IList<UserLoginInfo> Logins { get; set; }

        public virtual IList<IdentityUserClaim> Claims { get; set; }

        public virtual bool IsInRole(string name)
        {
            return Roles.Contains(name);
        }

        public virtual bool AddRole(string name)
        {
            if (IsInRole(name))
            {
                return false;
            }
               
            Roles.Add(name);

            return true;
        }

        public virtual bool RemoveRole(string name)
        {
            if (!IsInRole(name))
            {
                return false;
            }      

            Roles.Remove(name);

            return true;
        }

        public virtual bool HasLogin(UserLoginInfo info)
        {
            return Logins.Any(i => i.LoginProvider == info.LoginProvider && i.ProviderKey == info.ProviderKey);
        }

        public virtual bool AddLogin(UserLoginInfo info)
        {
            if (HasLogin(info))
            {
                return false;

            }

            Logins.Add(info);

            return true;
        }

        public virtual bool RemoveLogin(UserLoginInfo info)
        {
            if (!HasLogin(info))
            {
                return false;

            }

            var existingLogin = Logins.FirstOrDefault(e => e.ProviderKey == info.ProviderKey && e.LoginProvider == info.LoginProvider);

            Logins.Remove(existingLogin);

            return true;
        }

        public virtual bool HasClaim(Claim claim)
        {
            return Claims.Any(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);
        }


        public virtual bool AddClaim(Claim claim)
        {
            if (HasClaim(claim))
                return false;

            Claims.Add(new IdentityUserClaim(claim));//add IdentityUserClaim
            return true;
        }

        public virtual bool RemoveClaim(Claim claim)
        {
            if (!HasClaim(claim))
                return false;

            var existing = Claims.FirstOrDefault(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value);

            Claims.Remove(existing);

            return true;
        }
    }
}