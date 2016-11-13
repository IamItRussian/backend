using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Russian.App_Start
{
    public class IdentityRole
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IdentityRole()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
        
    }
}