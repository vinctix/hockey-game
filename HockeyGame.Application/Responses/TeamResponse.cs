namespace HockeyGame.Application.Responses
{
  public class TeamResponse
  {
    public int Id { get; set; }
    public string Coach { get; set; }
    public int Year { get; set; }
    public IEnumerable<PlayerResponse> Players { get; set; }
  }
}