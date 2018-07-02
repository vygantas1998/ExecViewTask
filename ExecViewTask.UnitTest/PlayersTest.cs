using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExecViewTask.UnitTest
{
    [TestFixture()]
    public class PlayerTest
    {
        [Test()]
        public void ReadPlayersDataFromCSVTest()
        {
            string filePath = Directory.GetCurrentDirectory() + "/../../../ExecViewTask/chicago-bulls.csv";
            Players players = new Players();

            try{
                players.ReadPlayersDataFromCSV(filePath);
            } 
            catch(Exception ex){
                Assert.Fail(ex.Message);    
            }
        }
        [Test()]
        public void getAveragePPGTest()
        {
            Players players = new Players();
            Player player1 = new Player(1, "PG", 20, "Lithuania", "Antony", new Height("5 ft 6 in"), "200lb", "KTU", 3);
            Player player2 = new Player(1, "PG", 20, "Lithuania", "Antony", new Height("5 ft 7 in"), "200lb", "KTU", 5);
            players.Add(player1);
            players.Add(player2);

            double expected = 4;

            double actual = players.getAveragePPG();

            Assert.AreEqual(expected, actual);
        }
        [Test()]
        public void getAverageHeightInCentimetersTest()
        {
            Players players = new Players();
            Player player1 = new Player(1, "PG", 20, "Lithuania", "Antony", new Height("5 ft 6 in"), "200lb", "KTU", 3);
            Player player2 = new Player(1, "PG", 20, "Lithuania", "Antony", new Height("5 ft 7 in"), "200lb", "KTU", 5);
            players.Add(player1);
            players.Add(player2);

            double expected = 168.91;

            double actual = players.getAverageHeightInCentimeters();

            Assert.AreEqual(expected, actual, 0.001);
        }
        [Test()]
        public void getPlayerCountInPositionsTest()
        {
            Players players = new Players();
            Player player1 = new Player(1, "PG", 20, "Lithuania", "Antony", new Height("5 ft 6 in"), "200lb", "KTU", 3);
            Player player2 = new Player(1, "PG", 20, "Lithuania", "Antony", new Height("5 ft 7 in"), "200lb", "KTU", 5);
            //players.Add(player1);
            //players.Add(player2);

            Dictionary<string, int> expected = new Dictionary<string, int>();
            //expected.Add("PG", 2);

            Dictionary<string, int> actual = players.getPlayerCountInPositions();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
