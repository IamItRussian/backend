using Microsoft.AspNet.Identity.EntityFramework;
using MongoDB.Driver;
using Russian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Russian.App_Start
{
    public class ApplicationIdentityContext : IDisposable
    {


        //it's where we make the database and users
        public static ApplicationIdentityContext Create()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("russian");
            var users = database.GetCollection<ApplicationUser>("users");
            var roles = database.GetCollection<IdentityRole>("roles");

            return new ApplicationIdentityContext(users, roles);
        }
        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<ApplicationUser> Users { get; set; }
        
        public IMongoCollection<IdentityRole> Roles { get; set; }

        public void Dispose()
        {
        }
    }
}