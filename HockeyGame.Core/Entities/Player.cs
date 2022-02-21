using System.ComponentModel.DataAnnotations;

namespace HockeyGame.Core.Entities {
  public class Player
  {
    [Key]
    public int Id { get; set; }
    public int Number { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Position { get; set; }
    public bool IsCaptain { get; set; }
    public int TeamId { get; set; }
  }
}