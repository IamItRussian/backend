using DB.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IDataLevel1Interface
    {
        DataLevel1 AddData(DataLevel1 dataLevel1);
        void DeleteByPart(int part);
        void DeleteAll();
        List<DataLevel1> GetAllData();
        DataLevel1 GetDataByPart(int part);
        void UpdateDataById(ObjectId id, String text, String description, String ans, int part );

    }
}
