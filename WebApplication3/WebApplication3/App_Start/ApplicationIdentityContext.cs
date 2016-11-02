using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.App_Start
{
    public class ApplicationIdentityContext : IDisposable
    {

        
        //it's where we make the database and users
        public static ApplicationIdentityContext Create()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("");
            var users = database.GetCollection<ApplicationUser>("users");

            return new ApplicationIdentityContext(users);
            
    
    }

        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users)
        {
            Users = users;
        }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public void Dispose()
        {
        }
    }
}