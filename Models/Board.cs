using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Board
  {
    private Cell[] _cell;

    public Board(string board)
    {
      throw new NotImplementedException();
    }

    private void GenerateBoard(string board)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      throw new NotImplementedException();
    }

    public bool Collision(int origin, int target)
    {
      throw new NotImplementedException();
    }

    public bool SameColour(int origin, int target)
    {
      throw new NotImplementedException();
    }

    public bool IsEssentialExposed(Colour colour)
    {
      throw new NotImplementedException();
    }

    public bool HasPromotable(int target)
    {
      throw new NotImplementedException();
    }

    public List<int> GetAssailants(Colour colour)
    {
      throw new NotImplementedException();
    }

    private int GetEssentialPiece(Colour colour)
    {
      throw new NotImplementedException();
    }

    private List<int> GetAttackingPieces(Colour colour, int target)
    {
      throw new NotImplementedException();
    }

    public bool ValidMove(int origin, int target)
    {
      throw new NotImplementedException();
    }

    public void MoveCellTo(int origin, int target)
    {
      throw new NotImplementedException();
    }
  }
}