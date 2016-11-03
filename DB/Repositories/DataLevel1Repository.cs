using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;
using DB.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DB.Repositories
{
    public class DataLevel1Repository : IDataLevel1Interface
    {
        private readonly IMongoCollection<DataLevel1> _dataCollection;
        public DataLevel1Repository()
        {
            var database = MongoClientFactory.GetMongoDatabase();
            _dataCollection = database.GetCollection<DataLevel1>("datalevel1");
        }
        public DataLevel1 AddData(DataLevel1 dataLevel1)
        {
            _dataCollection.InsertOne(dataLevel1);
            return dataLevel1;
        }

        public void DeleteAll()
        {
            _dataCollection.DeleteMany(d => true);
        }

        public void DeleteByPart(int part)
        {
            _dataCollection.DeleteOne(d => d.Part.Equals(part));
        }

        public List<DataLevel1> GetAllData()
        {
            return _dataCollection.AsQueryable().ToList();
        }

        public DataLevel1 GetDataByPart(int part)
        {
            return _dataCollection.AsQueryable().FirstOrDefault(d => d.Part.Equals(part));
        }

        public void UpdateDataById(ObjectId id, string text, string description, String ans, int part)
        {
            var update = Builders<DataLevel1>.Update
               .Set("Text", text)
               .Set("Ans", ans)
               .Set("Descriptions", description)
               .Set("Part", part)
               .CurrentDate("LastModified");
            var result = _dataCollection.UpdateOne(p => p.Id.Equals(id), update);
        }
    }
}
