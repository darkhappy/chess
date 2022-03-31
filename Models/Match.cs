using System;
using System.Collections.Generic;

namespace chess.Models
{
  public class Match
  {
    private Board _board;
    private Colour _current;
    private List<string> _history;
    private int _turnCount;
    
    public Match() {}

    public string ExportBoard()
    {
      throw new NotImplementedException();
    }
    
    public List<string> ExportHistory()
    {
      throw new NotImplementedException();
    }

    public bool ValidTurn(int origin, int target)
    {
      throw new NotImplementedException();
    }
    
    public void MakeTurn(int origin, int target)
    {
      throw new NotImplementedException();
    }

    public bool ValidSelection(int cell, bool firstClick)
    {
      throw new NotImplementedException();
    }

    public bool HasPromotable(int cell)
    {
      throw new NotImplementedException();
    }

    public bool Check()
    {
      throw new NotImplementedException();
    }
    
    public bool Checkmate()
    {
      throw new NotImplementedException();
    }
    
    public bool Stalemate()
    {
      throw new NotImplementedException();
    }
    
    public bool Castle() {
      throw new NotImplementedException();
    }
    
    public List<int> GetAssailants(int cell)
    {
      throw new NotImplementedException();
    }
    
  }
}