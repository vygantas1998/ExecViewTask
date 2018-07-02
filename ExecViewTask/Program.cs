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
            string filePath = Directory.GetCurrentDirectory() + "/../../chicago-bulls.csv";
            Players players = new Players();

            players.ReadPlayersDataFromCSV(filePath);

            double a = players.getAverageHeightInCentimeters();

            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //var output = javaScriptSerializer.Serialize(players);
            //Console.Write(output);
        }
    }
}