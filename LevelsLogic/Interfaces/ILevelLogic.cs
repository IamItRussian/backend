using LevelsLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelsLogic.Interfaces
{
    public interface ILevelLogic
    {
        TaskRussian GetTaskRussian(int level, int part);
        String CheckTaskRussian(String ans, String id, int level, int part);
        void AddTakRussian(int level, int part, string text, String ans, String description);
    }
}
