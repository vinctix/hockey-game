namespace HockeyGame.Application.Responses
{
  public class PlayerResponse
  {
    public int Id { get; set; }
    public int Number { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public bool IsCaptain { get; set; }
  }
}