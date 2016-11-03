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
        DataLevel1 GetTast(int part);
        String CheckTast(String ans, String id);
        void AddTask(String text,String  ans, String description, int part);
    }
}
