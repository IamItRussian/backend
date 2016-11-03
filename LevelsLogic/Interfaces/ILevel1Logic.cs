using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;

namespace LevelsLogic.Interfaces
{
    public interface ILevel1Logic
    {
        void AddTask(String text,String  ans, String description, int part);
        string CheckTask(string ans, int part);
        void DeleteLevelPart(int part);
        void DeleteAllLevel();
        DataLevel1 GetTast(int part);
    }
}
