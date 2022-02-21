using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HockeyGame.Core.Entities
{
    public class Team
    {
        [Key] public int Id { get; set; }
        public string Coach { get; set; }
        public int Year { get; set; }
        public IEnumerable<Player> Players { get; set; }

        [NotMapped]
        public Player? Captain
        {
            get { return Players.FirstOrDefault(x => x.IsCaptain); }
            set
            {
                foreach (var player in Players)
                {
                    player.IsCaptain = player.Id == value?.Id;
                }
            }
        }

        // public Player? GetCaptain()
        // {
        //     return Players.FirstOrDefault(x => x.IsCaptain);
        // }
        //
        // public Player SetCaptain(Player captain)
        // {
        //     foreach (var player in Players)
        //     {
        //         player.IsCaptain = player.Id == captain.Id;
        //     }
        //
        //     return captain;
        // }
    }
}