using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class BaseEntity
    {
        public ObjectId Id { get; set; }
        public String Descriptions { get; set; }
        public int Part;
    }
}
