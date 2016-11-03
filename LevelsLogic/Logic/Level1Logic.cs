using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using LevelsLogic.Interfaces;
using DB.Interfaces;
using DB.Repositories;
using DB.Models;

namespace LevelsLogic.Logic
{
    public class Level1Logic : ILevel1Logic
    {
        private static IDataLevel1Interface _dataRepository = new DataLevel1Repository();

        public static bool[] GetBoolFromStringBool(String ans)
        {
            bool[] result = new bool[ans.Length];
            for(int i = 0; i < ans.Length; i++)
            {
                if (ans[i].Equals('1'))
                {
                    result[i] = true;
                }
                else
                {
                    result[i] = false;
                }
            }
            return result;
        }
        public void AddTask(string text, String ans, String description, int part)
        {
            DataLevel1 data = new DataLevel1();
            data.Text = text;
            data.Descriptions = description;
            data.Ans = GetBoolFromStringBool(ans);
            data.Part = part;
            _dataRepository.AddData(data);
        }

        public string CheckTast(string ans, String id)
        {
            //Very hard function
            String correctAns = "";
            return correctAns;
        }

        public DataLevel1 GetTast(int part)
        {
            return _dataRepository.GetDataByPart(part);
        }
    }
}
