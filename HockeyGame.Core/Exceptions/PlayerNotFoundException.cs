namespace HockeyGame.Application.Exceptions {
  public class PlayerNotFoundException: Exception
  {
    public int Id { get; set; }
  }
}