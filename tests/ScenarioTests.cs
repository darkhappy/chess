using System;
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
      try
      {
        _game.Selection(new Position(7, 4));
      }
      catch (NullReferenceException e)
      {
        // ignored
      }

      Assert.That(_game.GetBoard(), Is.EqualTo("rnb.kbnrpppp.ppp.....................pPq........PPPPP..PRNBQKBNR"));
    }

    [Test]
    public void NineMoves()
    {
      _game.Selection(new Position("e2"));
      _game.Selection(new Position("e4"));
      _game.Selection(new Position("e7"));
      _game.Selection(new Position("e5"));

      _game.Selection(new Position("f1"));
      _game.Selection(new Position("c4"));
      _game.Selection(new Position("f8"));
      _game.Selection(new Position("c5"));

      _game.Selection(new Position("g1"));
      _game.Selection(new Position("f3"));
      _game.Selection(new Position("b8"));
      _game.Selection(new Position("c6"));

      _game.Selection(new Position("c2"));
      _game.Selection(new Position("c3"));
      _game.Selection(new Position("d8"));
      _game.Selection(new Position("e7"));

      _game.Selection(new Position("d2"));
      _game.Selection(new Position("d4"));
      _game.Selection(new Position("e5"));
      _game.Selection(new Position("d4"));

      _game.Selection(new Position("c3"));
      _game.Selection(new Position("d4"));
      _game.Selection(new Position("e7"));
      _game.Selection(new Position("e4"));

      _game.Selection(new Position("e1"));
      _game.Selection(new Position("d2"));
      _game.Selection(new Position("c5"));
      _game.Selection(new Position("b4"));

      _game.Selection(new Position("b1"));
      _game.Selection(new Position("c3"));
      _game.Selection(new Position("e4"));
      _game.Selection(new Position("g6"));

      _game.Selection(new Position("h1"));
      _game.Selection(new Position("e1"));
      _game.Selection(new Position("e8"));
      _game.Selection(new Position("d8"));

      Assert.That(_game.GetBoard(), Is.EqualTo("r.bqr...pp.k.ppp..n..n...Bbp..............N...Q.PPPP.PPPR.BK..NR"));
    }

    [Test]
    public void CheckmateInTen()
    {
      _game.Selection(new Position("e2"));
      _game.Selection(new Position("e4"));
      _game.Selection(new Position("c7"));
      _game.Selection(new Position("c5"));

      _game.Selection(new Position("g1"));
      _game.Selection(new Position("f3"));
      _game.Selection(new Position("d7"));
      _game.Selection(new Position("d6"));

      _game.Selection(new Position("b1"));
      _game.Selection(new Position("b3"));
      _game.Selection(new Position("e7"));
      _game.Selection(new Position("e5"));

      _game.Selection(new Position("f1"));
      _game.Selection(new Position("c4"));
      _game.Selection(new Position("b8"));
      _game.Selection(new Position("c6"));

      _game.Selection(new Position("d2"));
      _game.Selection(new Position("d3"));
      _game.Selection(new Position("g8"));
      _game.Selection(new Position("e7"));

      _game.Selection(new Position("c1"));
      _game.Selection(new Position("g5"));
      _game.Selection(new Position("c8"));
      _game.Selection(new Position("g4"));

      _game.Selection(new Position("c3"));
      _game.Selection(new Position("d5"));
      _game.Selection(new Position("c6"));
      _game.Selection(new Position("d4"));

      _game.Selection(new Position("f3"));
      _game.Selection(new Position("e5"));
      _game.Selection(new Position("g4"));
      _game.Selection(new Position("d1"));

      _game.Selection(new Position("d5"));
      _game.Selection(new Position("f6"));
      _game.Selection(new Position("g7"));
      _game.Selection(new Position("f6"));

      _game.Selection(new Position("c4"));
      try
      {
        _game.Selection(new Position("f7"));
      }
      catch (NullReferenceException e)
      {
        //ignored
      }

      Assert.That(_game.GetBoard(), Is.EqualTo("rnbBk..rppp..ppp...p........p.....P.n.....NP....PP..PbPPR..QKBNR"));
    }
  }
}