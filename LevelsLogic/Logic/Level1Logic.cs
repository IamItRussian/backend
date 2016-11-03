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

        public static string GetHashStringFromBool(bool[] ans)
        {
            string result = "";
            int degree, symbol;
            for(int i = 0; i < ans.Length; i++)
            {
                degree = 32768;
                symbol = 0;
                for(int j = 0; j < 16 && i < ans.Length; j++, i++)
                {
                    if (ans[i])
                        symbol += degree;
                    degree /= 2;
                }
                i--;
                char c = (char)symbol;
                result = result + c;
            }
            return result;
        }

        public void AddTask(string text, String ans, String description, int part)
        {
            DataLevel1 data = new DataLevel1();
            data.Text = text;
            data.Descriptions = description;
            data.Ans = GetHashStringFromBool(GetBoolFromStringBool(ans));
            data.Part = part;
            _dataRepository.AddData(data);
        }
        
        public string CheckTask(string ans, int part)
        {
            String check = "";
            string correctAns = _dataRepository.GetDataByPart(part).Ans;
            for(int i = 0; i < ans.Length; i++)
            {
                check += ((char)(ans[i] ^ correctAns[i]));
            }
            return check;
        }

        public void DeleteAllLevel()
        {
            _dataRepository.DeleteAll();
        }

        public void DeleteLevelPart(int part)
        {
            _dataRepository.DeleteByPart(part);
        }

        public DataLevel1 GetTast(int part)
        {
            return _dataRepository.GetDataByPart(part);
        }
    }
}
