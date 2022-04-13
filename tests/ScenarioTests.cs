using chess.Controllers;
using chess.Models;
using NUnit.Framework;

namespace tests
{
  [TestFixture]
  [Platform(Include = "Win")]
  public class ScenarioTests
  {
    [SetUp]
    public void Setup()
    {
      _game = new GameController(new Player("a"), new Player("b"));
    }

    private GameController _game;

    [Test]
    public void CheckmateInThree()
    {
      _game.Selection(new Position("e2"));
      _game.Selection(new Position("e4"));
      _game.Selection(new Position(5, 6));
      _game.Selection(new Position(5, 4));
      _game.Selection(new Position(4, 3));
      _game.Selection(new Position(5, 4));
      _game.Selection(new Position(6, 6));
      _game.Selection(new Position(6, 4));
      _game.Selection(new Position(3, 0));
      _game.Selection(new Position(7, 4));
      Assert.That(_game.GetBoard(), Is.EqualTo("rnb.kbnrpppp.ppp.....................pPq........PPPPP..PRNBQKBNR"));
    }
  }
}