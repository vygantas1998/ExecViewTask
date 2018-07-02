using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
using System.Web.Script.Serialization;
namespace ExecViewTask
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string filePath = Directory.GetCurrentDirectory() + "/../../chicago-bulls.csv";
            List<Player> players = ReadPlayerData(filePath);

            players.Sort((x, y) => y.PPG.CompareTo(x.PPG));

            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //var output = javaScriptSerializer.Serialize(players);
            //Console.Write(output);
        }

        public static List<Player> ReadPlayerData(string filePath)
        {
            List<Player> players = new List<Player>();

            using(StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                int lineNumber = 2;
                while((line = reader.ReadLine())!= null)
                {
                    string[] data = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    try
                    {
                        players.Add(new Player(int.Parse(data[0]), data[1], int.Parse(data[2]), data[3], data[4], data[5], data[6], data[7], float.Parse(data[8])));
                    } 
                    catch 
                    {
                        throw new Exception("Format Error: " + filePath + ", line: " + lineNumber);
                    }
                    lineNumber++;
                }
            }
            return players;
        }
    }
}