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
    [TestCase(0, 0, Colour.White)]
    [TestCase(0, 7, Colour.Black)]
    public void CellHasThisColour(int x1, int y1, Colour colour)
    {
      Assert.That(_board.SameColour(new Position(x1, y1), colour), Is.True);
    }

    [Test]
    [TestCase(0, 0, Colour.Black)]
    [TestCase(0, 7, Colour.White)]
    public void CellDoesNotHaveThisColour(int x1, int y1, Colour colour)
    {
      Assert.That(_board.SameColour(new Position(x1, y1), colour), Is.False);
    }

    [Test]
    [TestCase(0, 0, 7, 0)]
    [TestCase(0, 7, 7, 7)]
    [TestCase(3, 0, 7, 4)]
    [TestCase(3, 0, 3, 5)]
    [TestCase(7, 0, 0, 0)]
    [TestCase(3, 0, 0, 3)]
    [TestCase(3, 0, 6, 3)]
    public void CantMoveAboveDueToCollision(int x1, int y1, int x2, int y2)
    {
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(3, 0, 0, 0)]
    [TestCase(0, 3, 0, 0)]
    [TestCase(3, 3, 0, 0)]
    public void CantMoveBelowDueToCollision(int x1, int y1, int x2, int y2)
    {
      _board = new Board("kN.Q....NN..............Q..Q....................................");
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(3, 3, 0, 0)]
    [TestCase(3, 3, 3, 0)]
    [TestCase(3, 3, 6, 0)]
    public void WhitePieceMovingDownwards(int x1, int y1, int x2, int y2)
    {
      _board = new Board("P..P..P....................q....................................");
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.True);
    }


    [Test]
    [TestCase(3, 3, 0, 0)]
    [TestCase(3, 3, 3, 0)]
    [TestCase(3, 3, 6, 0)]
    public void BlackPieceMovingDownwards(int x1, int y1, int x2, int y2)
    {
      _board = new Board("p..p..p....................Q....................................");
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.True);
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
    [TestCase(0, 1, 0, 2)]
    [TestCase(1, 1, 1, 2)]
    [TestCase(2, 1, 2, 2)]
    [TestCase(3, 1, 3, 2)]
    [TestCase(4, 1, 4, 2)]
    [TestCase(5, 1, 5, 2)]
    [TestCase(6, 1, 6, 2)]
    [TestCase(7, 1, 7, 2)]
    [TestCase(0, 1, 0, 3)]
    [TestCase(1, 1, 1, 3)]
    [TestCase(2, 1, 2, 3)]
    [TestCase(3, 1, 3, 3)]
    [TestCase(4, 1, 4, 3)]
    [TestCase(5, 1, 5, 3)]
    [TestCase(6, 1, 6, 3)]
    [TestCase(7, 1, 7, 3)]
    [TestCase(1, 0, 0, 2)]
    [TestCase(1, 0, 2, 2)]
    [TestCase(6, 0, 7, 2)]
    [TestCase(6, 0, 5, 2)]
    [TestCase(0, 6, 0, 4)]
    public void StartingBoardMovement(int x1, int y1, int x2, int y2)
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

    [Test]
    [TestCase(0, 2, 7, 3)]
    [TestCase(2, 3, 4, 5)]
    public void CantMoveEmptyCell(int x1, int y1, int x2, int y2)
    {
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(0, 0, 0, 1)]
    [TestCase(3, 0, 2, 1)]
    public void CantMoveToSameColour(int x1, int y1, int x2, int y2)
    {
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(0, 0, 1, 1)]
    [TestCase(2, 1, 1, 1)]
    [TestCase(1, 2, 1, 1)]
    [TestCase(2, 2, 1, 1)]
    [TestCase(3, 2, 1, 1)]
    public void CapturePiece(int x1, int y1, int x2, int y2)
    {
      _board = new Board("K......k.pR......QBN............................................");
      Assert.That(_board.ValidMove(new Position(x1, y1), new Position(x2, y2)), Is.True);
    }

    [Test]
    public void WeirdCase1()
    {
      _board.MoveCellTo(new Position(3, 0), new Position(0, 2));
      _board.MoveCellTo(new Position(3, 1), new Position(3, 2));
      _board.MoveCellTo(new Position(4, 1), new Position(4, 2));
      _board.MoveCellTo(new Position(5, 1), new Position(5, 2));
      _board.MoveCellTo(new Position(6, 1), new Position(6, 2));
      Assert.That(_board.ValidMove(new Position(0, 2), new Position(7, 2)), Is.False);
    }
  }
}