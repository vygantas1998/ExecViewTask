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
                                                   double.Parse(data[8])));
                    }
                    catch
                    {
                        throw new Exception("Wrong format: " + filePath + ", line: " + lineNumber);
                    }
                    lineNumber++;
                }
            }
        }

        public List<Player> GetSortedByPPG()
        {
            return PlayersData.OrderByDescending(x => x.PPG).ToList<Player>();
        }

        public double getAveragePPG()
        {
            if (PlayersData.Count != 0)
            {
                return PlayersData.Select(x => x.PPG).Average();
            }
            return 0;
        }

        public double getAverageHeightInCentimeters()
        {
            if (PlayersData.Count != 0)
            {
                return PlayersData.Select(x => x.Height.GetHeightInCentimeters()).Average();
            }
            return 0;
        }

        public Dictionary<string, int> getPlayerCountInPositions()
        {
            Dictionary<string, int> positions = new Dictionary<string, int>();
            string[] positionsArray = PlayersData.Select(x => x.Position).Distinct().ToArray();

            foreach (string pos in positionsArray)
            {
                positions.Add(pos, PlayersData.Where(x => x.Position == pos).Count());
            }
            return positions;
        }

        public List<Dictionary<string, string>> getLeaders()
        {
            List<Dictionary<string, string>> leaders = new List<Dictionary<string, string>>();
            List<Player> sorted = GetSortedByPPG();
            Dictionary<string, string> dickt;

            if (sorted.Count >= 1)
            {
                dickt = new Dictionary<string, string>();

                dickt.Add("Gold", sorted.First().Name);
                dickt.Add("PPG", sorted.First().PPG.ToString());

                leaders.Add(dickt);
            }
            if (sorted.Count >= 2)
            {
                dickt = new Dictionary<string, string>();

                dickt.Add("Silver", sorted.Take(2).Last().Name);
                dickt.Add("PPG", sorted.Take(2).Last().PPG.ToString());

                leaders.Add(dickt);
            }
            if (sorted.Count >= 3)
            {
                dickt = new Dictionary<string, string>();

                dickt.Add("Bronze", sorted.Take(3).Last().Name);
                dickt.Add("PPG", sorted.Take(3).Last().PPG.ToString());

                leaders.Add(dickt);
            }

            return leaders;
        }
    }
}
