namespace HockeyGame.Application.Exceptions {
  public class TeamNotFoundException: Exception
  {
    public int Id { get; set; }
    public int Year { get; set; }

    private TeamNotFoundException(){}

    public static TeamNotFoundException FromId(int id)
    {
      return new TeamNotFoundException() { Id = id };
    }
    
    public static TeamNotFoundException FromYear(int year)
    {
      return new TeamNotFoundException() { Year = year };
    }
  }
}