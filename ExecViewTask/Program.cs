using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Linq;
namespace ExecViewTask
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string inputFilePath = Directory.GetCurrentDirectory() + "/../../chicago-bulls.csv";
            string outputFilePath = Directory.GetCurrentDirectory() + "/../../chicago-bulls.json";
            Players players = new Players();

            players.ReadPlayersDataFromCSV(inputFilePath);

            OutputToJson(outputFilePath, players);
        }
        public static void OutputToJson(string filePath, Players players)
        {
            List<Player> sorted = players.GetSortedByPPG();

            double averagePPG = players.getAveragePPG();

            double averageHeight = players.getAverageHeightInCentimeters();

            Dictionary<string, int> playerCountInPositons = players.getPlayerCountInPositions();

            List<Dictionary<string, string>> leaders = players.getLeaders();

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            string SortedJson = javaScriptSerializer.Serialize(sorted);

            string leadersJson = javaScriptSerializer.Serialize(leaders);

            string playerCountInPositionsJson = javaScriptSerializer.Serialize(playerCountInPositons);

            using (StreamWriter writter = new StreamWriter(filePath))
            {
                writter.Write("{ \"Players\": ");
                writter.Write(SortedJson);
                writter.Write(", ");
                writter.Write("\"AveragePPG\": {0:0.##},",averagePPG);
                writter.Write("\"Leaders\": {0},", leadersJson);
                writter.Write("\"\": {0},", playerCountInPositionsJson);
                writter.Write("\"AverageHeight\": \"{0:0.#} cm\"", averageHeight);
                writter.Write(" }");
            }
        }
    }
}