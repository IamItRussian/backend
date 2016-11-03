﻿using LevelsLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelsLogic.Models;

namespace LevelsLogic.Logic
{
    public class LevelLogic : ILevelLogic
    {
        ILevel1Logic _level1 = new Level1Logic();

        public void AddTakRussian(int level, int part, string text, string ans, string description)
        {            
            if(level == 1)
            {
                _level1.AddTask(text, ans, description, part);
            }
        }

        public string CheckTaskRussian(string ans, int level, int part)
        {
            if(level == 1)
            {
                return _level1.CheckTask(ans, part);
            }
            return null;
        }
        
        public void DeleteAllLevel(int level)
        {
            if(level == 1)
            {
                _level1.DeleteAllLevel();
            }
        }

        public void DeleteLevelPart(int level, int part)
        {
            if (level == 1)
            {
                _level1.DeleteLevelPart(part);
            }
        }

        public TaskRussian GetTaskRussian(int level, int part)
        {
            if(level == 1)
            {
                return new TaskRussian(_level1.GetTast(part));
            }
            return null;
        }
    }
}
