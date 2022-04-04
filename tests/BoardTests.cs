using chess.Models;
using NUnit.Framework;

namespace tests
{
  [TestFixture]
  public class BoardTests
  {
    [SetUp]
    public void Setup()
    {
      _board = new Board("rnbqkbnrpppppppp................................PPPPPPPPRNBKQBNR");
    }

    private Board _board;

    [Test]
    public void EmptyBoard()
    {
      _board = new Board();
      Assert.That("................................................................", Is.EqualTo(_board.ToString()));
    }

    [Test]
    public void StartingBoard()
    {
      Assert.That("rnbqkbnrpppppppp................................PPPPPPPPRNBKQBNR", Is.EqualTo(_board.ToString()));
    }

    [Test]
    public void MoveWhitePawn()
    {
      _board.MoveCellTo(new Position(0, 1), new Position(0, 2));
      Assert.That("rnbqkbnr.pppppppp...............................PPPPPPPPRNBKQBNR", Is.EqualTo(_board.ToString()));
    }

    [Test]
    public void MoveBlackPawn()
    {
      _board.MoveCellTo(new Position(0, 6), new Position(0, 5));
      Assert.That("rnbqkbnrpppppppp........................P........PPPPPPPRNBKQBNR", Is.EqualTo(_board.ToString()));
    }

    [Test]
    [TestCase(0, 0, 7, 0)]
    [TestCase(0, 7, 7, 7)]
    public void CellsHaveSameColour(int x1, int y1, int x2, int y2)
    {
      Assert.That(_board.SameColour(new Position(x1, y1), new Position(x2, y2)), Is.True);
    }

    [Test]
    [TestCase(0, 0, 0, 7)]
    [TestCase(7, 0, 7, 7)]
    public void CellsHaveDifferentColour(int x1, int y1, int x2, int y2)
    {
      Assert.That(_board.SameColour(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(0, 0, 7, 0)]
    [TestCase(0, 7, 7, 7)]
    [TestCase(3, 0, 7, 4)]
    public void CantMoveDueToCollision(int x1, int y1, int x2, int y2)
    {
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(1, 0, 0, 2)]
    [TestCase(1, 0, 2, 2)]
    [TestCase(6, 0, 7, 2)]
    [TestCase(6, 0, 5, 2)]
    [TestCase(1, 7, 0, 5)]
    [TestCase(1, 7, 2, 5)]
    [TestCase(6, 7, 7, 5)]
    [TestCase(6, 7, 5, 5)]
    public void CanMoveDespiteCollision(int x1, int y1, int x2, int y2)
    {
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.True);
    }

    [Test]
    public void PromotableAtEndRow()
    {
      _board = new Board("rnbqkbnrpppppppp................................PPPPPPPPPPPPPPPP");
      Assert.That(_board.HasPromotable(new Position(7, 7)), Is.True);
    }

    [Test]
    public void NoPromotable()
    {
      Assert.That(_board.HasPromotable(new Position(7, 7)), Is.False);
    }
  }
}