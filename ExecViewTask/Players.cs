using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace ExecViewTask
{
    public class Players
    {
        List<Player> PlayersData;

        public Players()
        {
            PlayersData = new List<Player>();
        }

        public void Add(Player player)
        {
            PlayersData.Add(player);
        }

        public void ReadPlayersDataFromCSV(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                int lineNumber = 2;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    try
                    {
                        PlayersData.Add(new Player(int.Parse(data[0]),
                                                   data[1],
                                                   int.Parse(data[2]),
                                                   data[3],
                                                   data[4].Trim('\"'),
                                                   new Height(data[5]),
                                                   data[6],
                                                   data[7],
                                                   float.Parse(data[8])));
                    }
                    catch {
                        throw new Exception("Wrong format: " + filePath + ", line: " + lineNumber);
                    }
                    lineNumber++;
                }
            }
        }

        public void SortByPPG()
        {
            PlayersData.Sort((x, y) => y.PPG.CompareTo(x.PPG));
        }

        public double getAveragePPG()
        {
            return PlayersData.Select(x => x.PPG).Average();
        }

        public double getAverageHeightInCentimeters()
        {
            return PlayersData.Select(x => x.Height.GetHeightInCentimeters()).Average();    
        }


    }
}
