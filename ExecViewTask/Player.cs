using System;
namespace ExecViewTask
{
    public class Player
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Univercity { get; set; }
        public float PPG { get; set; }

        public Player(int id, string position, int number, string country, 
                      string name, string height, string weight, string univercity,
                      float ppg)
        {
            Id = id;
            Position = position;
            Number = number;
            Country = country;
            Name = name;
            Height = height;
            Weight = weight;
            Univercity = univercity;
            PPG = ppg;
        }
    }
}
