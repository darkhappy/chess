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
  }
}