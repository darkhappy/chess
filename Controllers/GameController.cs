using System;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class GameController
  {
    private int _fiftyTurns;
    private Chess _main;
    private Match _match;
    private Player _playerA;
    private Player _playerB;
    private int _selected;

    FormMatch _formMatch;

    public GameController(Player a, Player b)
    {
      _formMatch = new FormMatch();
      _formMatch.Show();
    }

    public void Selection(int cell)
    {
      throw new NotImplementedException();
    }

    private void Turn(int origin, int target)
    {
      throw new NotImplementedException();
    }

    private void Stalemate()
    {
      throw new NotImplementedException();
    }

    private void Checkmate()
    {
      throw new NotImplementedException();
    }

    private void Check()
    {
      throw new NotImplementedException();
    }

    private void Rules()
    {
      throw new NotImplementedException();
    }

    public void Resign()
    {
      throw new NotImplementedException();
    }

    private void Castle()
    {
      throw new NotImplementedException();
    }
  }
}