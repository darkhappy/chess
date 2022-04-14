using chess.Models;
using NUnit.Framework;

namespace tests
{
  [TestFixture]
  public class MatchTests
  {
    [SetUp]
    public void Setup()
    {
      _match = new Match();
    }

    private Match _match;

    [Test]
    public void ChangedToBlack()
    {
      _match.MakeTurn(new Position(0, 0), new Position(0, 1));
      Assert.That(_match.CurrentPlayer == Colour.Black);
    }

    [Test]
    public void ChangedToWhite()
    {
      _match.MakeTurn(new Position(0, 0), new Position(0, 1));
      _match.MakeTurn(new Position(1, 1), new Position(0, 1));
      Assert.That(_match.CurrentPlayer == Colour.White);
    }

    [Test]
    [TestCase(0, 1, true)]
    [TestCase(1, 1, true)]
    [TestCase(4, 1, true)]
    [TestCase(0, 2, false)]
    [TestCase(1, 7, false)]
    [TestCase(7, 7, false)]
    public void WhiteValidSelection(int x, int y, bool first)
    {
      Assert.That(_match.ValidSelection(new Position(x, y), first), Is.True);
    }


    [Test]
    [TestCase(0, 2, true)]
    [TestCase(7, 7, true)]
    [TestCase(1, 7, true)]
    [TestCase(0, 1, false)]
    [TestCase(1, 1, false)]
    [TestCase(4, 1, false)]
    public void WhiteInvalidSelection(int x, int y, bool first)
    {
      Assert.That(_match.ValidSelection(new Position(x, y), first), Is.False);
    }

    [Test]
    [TestCase(0, 7, true)]
    [TestCase(1, 6, true)]
    [TestCase(4, 6, true)]
    [TestCase(0, 3, false)]
    [TestCase(0, 1, false)]
    [TestCase(7, 1, false)]
    [TestCase(1, 3, false)]
    public void BlackValidSelection(int x, int y, bool first)
    {
      _match.MakeTurn(new Position(0, 0), new Position(1, 1));
      Assert.That(_match.ValidSelection(new Position(x, y), first), Is.True);
    }

    [Test]
    [TestCase(0, 7, false)]
    [TestCase(1, 6, false)]
    [TestCase(4, 6, false)]
    [TestCase(0, 3, true)]
    [TestCase(0, 1, true)]
    [TestCase(7, 1, true)]
    [TestCase(1, 3, true)]
    public void BlackInvalidSelection(int x, int y, bool first)
    {
      _match.MakeTurn(new Position(0, 0), new Position(1, 1));
      Assert.That(_match.ValidSelection(new Position(x, y), first), Is.False);
    }


    [Test]
    [TestCase(1, 0, 0, 2)]
    [TestCase(1, 1, 3, 2)]
    [TestCase(0, 1, 2, 2)]
    public void CantMoveDueToSelfcheck(int x1, int y1, int x2, int y2)
    {
      /* Assuming that the board is the following:
       * kn.Q
       * nn..
       * ....
       * Q..Q
       * Neither knights should be able to move, as it will put the king in check.
       */
      _match.ChangeBoard("kn.Q....nn..............Q..Q....................................");
      Assert.That(_match.ValidTurn(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(1, 1, 0, 0)]
    [TestCase(1, 1, 1, 2)]
    [TestCase(1, 1, 2, 1)]
    public void KingMovesOutOfCheck(int x1, int y1, int x2, int y2)
    {
      _match.ChangeBoard("R........k.......R..............................................");
      Assert.That(_match.ValidTurn(new Position(x1, y1), new Position(x2, y2)), Is.True);
    }

    [Test]
    [TestCase(1, 1, 0, 1)]
    [TestCase(1, 1, 0, 2)]
    [TestCase(1, 1, 1, 0)]
    [TestCase(1, 1, 1, 2)]
    [TestCase(1, 1, 2, 0)]
    [TestCase(1, 1, 2, 1)]
    public void KingMovesIntoCheck(int x1, int y1, int x2, int y2)
    {
      _match.ChangeBoard("R........k........R.............................................");
      Assert.That(_match.ValidTurn(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    [TestCase(2, 0, 0, 2)]
    [TestCase(2, 0, 4, 2)]
    [TestCase(1, 1, 3, 3)]
    [TestCase(3, 2, 3, 3)]
    [TestCase(4, 0, 4, 4)]
    [TestCase(5, 1, 4, 3)]
    public void OpponentInCheck(int x1, int y1, int x2, int y2)
    {
      _match.ChangeBoard("..b.r....q...n.....p..............K.............................");
      _match.MakeTurn(new Position(x1, y1), new Position(x2, y2));
      Assert.That(_match.Check(), Is.True);
    }

    [Test]
    [TestCase(4, 3, 4, 5)]
    public void PawnMovingForwardTwice(int x1, int y1, int x2, int y2)
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      _match.MakeTurn(new Position(0, 6), new Position(0, 5));
      Assert.That(_match.ValidTurn(new Position(x1, y1), new Position(x2, y2)), Is.False);
    }

    [Test]
    public void CheckmateInThree()
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      _match.MakeTurn(new Position(5, 6), new Position(5, 4));
      _match.MakeTurn(new Position(4, 3), new Position(5, 4));
      _match.MakeTurn(new Position(6, 6), new Position(6, 4));
      _match.MakeTurn(new Position(3, 0), new Position(7, 4));
      Assert.That(_match.Checkmate(), Is.True);
    }

    [Test]
    public void CanAttackThePiecePuttingTheKingInCheck()
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      _match.MakeTurn(new Position(5, 6), new Position(5, 4));
      _match.MakeTurn(new Position(4, 3), new Position(5, 4));
      _match.MakeTurn(new Position(6, 6), new Position(6, 4));
      _match.MakeTurn(new Position(3, 1), new Position(3, 3));
      _match.MakeTurn(new Position(6, 7), new Position(5, 5));
      _match.MakeTurn(new Position(3, 0), new Position(7, 4));
      Assert.That(_match.Check(), Is.True);
      Assert.That(_match.Checkmate(), Is.False);
    }

    [Test]
    public void CanBlockThePiecePuttingTheKingInCheck()
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      _match.MakeTurn(new Position(5, 6), new Position(5, 4));
      _match.MakeTurn(new Position(4, 3), new Position(5, 4));
      _match.MakeTurn(new Position(3, 6), new Position(3, 4));
      _match.MakeTurn(new Position(3, 0), new Position(7, 4));
      Assert.That(_match.Check(), Is.True);
      Assert.That(_match.Checkmate(), Is.False);
    }

    [Test]
    public void NotACheck()
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      Assert.That(_match.Check(), Is.False);
    }

    [Test]
    public void NotACheckmate()
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      Assert.That(_match.Checkmate(), Is.False);
    }

    [Test]
    public void AttackingPiecePuttingTheKingInCheck()
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      _match.MakeTurn(new Position(5, 6), new Position(5, 4));
      _match.MakeTurn(new Position(4, 3), new Position(5, 4));
      _match.MakeTurn(new Position(6, 6), new Position(6, 4));
      _match.MakeTurn(new Position(3, 1), new Position(3, 3));
      _match.MakeTurn(new Position(6, 7), new Position(5, 5));
      _match.MakeTurn(new Position(3, 0), new Position(7, 4));
      Assert.That(_match.ValidTurn(new Position(5, 5), new Position(7, 4)), Is.True);
    }

    [Test]
    public void BlockingPiecePuttingTheKingInCheck()
    {
      _match.MakeTurn(new Position(4, 1), new Position(4, 3));
      _match.MakeTurn(new Position(5, 6), new Position(5, 4));
      _match.MakeTurn(new Position(4, 3), new Position(5, 4));
      _match.MakeTurn(new Position(3, 6), new Position(3, 4));
      _match.MakeTurn(new Position(3, 0), new Position(7, 4));
      Assert.That(_match.ValidTurn(new Position(6, 6), new Position(6, 5)), Is.True);
    }

    [Test]
    public void CantCaptureAttackerDueToSelfCheck()
    {
      _match.ChangeBoard("rnb.k.nrpppp.ppp....P.....b.....................PPPPPqPPRNBQKBNR");
      Assert.That(_match.ValidTurn(new Position("e8"), new Position("f7")), Is.False);
    }

    [Test]
    public void BlockingPiecePuttingTheKingInCheck2()
    {
      _match.ChangeBoard("rnbqkbnrppppp.pp.............p.Q............P...PPPP.PPPRNB.KBNR");
      Assert.That(_match.ValidTurn(new Position("g2"), new Position("g3")), Is.True);
    }

    [Test]
    public void CastlingMove()
    {
      _match.MakeTurn(new Position("e2"), new Position("e4"));
      _match.MakeTurn(new Position("e7"), new Position("e5"));
      _match.MakeTurn(new Position("f1"), new Position("c4"));
      _match.MakeTurn(new Position("b8"), new Position("c6"));
      _match.MakeTurn(new Position("g1"), new Position("f3"));
      _match.MakeTurn(new Position("f8"), new Position("c5"));
      Assert.That(_match.ValidTurn(new Position("e1"), new Position("g1")), Is.True);
    }

    [Test]
    public void PerformEnPassant()
    {
      _match.MakeTurn(new Position("e2"), new Position("e4"));
      _match.MakeTurn(new Position("a6"), new Position("a5"));
      _match.MakeTurn(new Position("e4"), new Position("e5"));
      _match.MakeTurn(new Position("a5"), new Position("a4"));
      _match.MakeTurn(new Position("d7"), new Position("d5"));
      _match.MakeTurn(new Position("e5"), new Position("d6"));
      Assert.That(_match.ExportBoard(), Is.EqualTo("rnbqkbnrpppp.ppp...........................p....PPP.PPPPRNBQKBNR"));
    }

    [Test]
    public void InAStalemate()
    {
      _match.ChangeBoard(".......k.....Q..K...............................................");
      Assert.That(_match.Stalemate(), Is.True);
    }

    [Test]
    public void NotInStalemate()
    {
      _match.MakeTurn(new Position("e2"), new Position("e4"));
      Assert.That(_match.Stalemate(), Is.False);
    }

    [Test]
    public void CheckmateInCorner()
    {
      _match.ChangeBoard(".......K.....q..................................q..............k");
      _match.MakeTurn(new Position("a7"), new Position("a8"));
      Assert.That(_match.Checkmate(), Is.True);
    }

    [Test]
    public void StupidThingJeFoundOne()
    {
      _match.MakeTurn(new Position("d2"), new Position("d4"));
      _match.MakeTurn(new Position("d7"), new Position("d5"));
      _match.MakeTurn(new Position("g2"), new Position("g4"));
      _match.MakeTurn(new Position("h7"), new Position("h5"));
      Assert.That(_match.ValidTurn(new Position("g4"), new Position("h5")), Is.True);
    }

    [Test]
    public void StupidThingJeFoundTwo()
    {
      _match.ChangeBoard("r.b.k.n..pp.p..........P........p..qp...P.P......P..K...RNB..Br.");
      _match.MakeTurn(new Position("d5"), new Position("d6"));
      Assert.That(_match.Checkmate(), Is.False);
    }

    [Test]
    public void StupidThingJeFoundThree()
    {
      _match.ChangeBoard("..ppp..p..pkp.....p.p.....................................Q.....");
      _match.MakeTurn(new Position("h1"), new Position("h2"));
      _match.MakeTurn(new Position("c8"), new Position("d8"));
      Assert.That(_match.Checkmate(), Is.True);
    }

    [Test]
    public void StupidThingJeFoundFour()
    {
      _match.ChangeBoard("r.b..B.r..q...bp........p..k....P....P........P...p.p..P..KR.BNR");
      _match.MakeTurn(new Position("c7"), new Position("d8"));
      _match.Promote(new Position("d8"), "q");
      Assert.That(_match.Checkmate(), Is.True);
    }

    [Test]
    public void PawnCollisions()
    {
      _match.ChangeBoard("..ppp..p..pkp.....p.p.....................................Q.....");
      Assert.That(_match.ValidTurn(new Position("d1"), new Position("d3")), Is.False);
    }

    [Test]
    public void CantEnPassantFromNowhere()
    {
      _match.MakeTurn(new Position("a2"), new Position("a5"));
      _match.MakeTurn(new Position("h7"), new Position("h5"));
      Assert.That(_match.ValidTurn(new Position("a5"), new Position("b6")), Is.False);
    }
  }
}