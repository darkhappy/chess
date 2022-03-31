using System;

namespace chess.Models
{
  public class Cell
  {
    #nullable enable
    private Piece? _piece;

    public Cell()
    {
      throw new NotImplementedException();
    }

    public Cell(Piece piece)
    {
      throw new NotImplementedException();
    }
    
    public bool IsEmpty()
    {
      throw new NotImplementedException();
    }
    
    public bool HasCollision()
    {
      throw new NotImplementedException();
    }
    
    public bool HasPromotable() 
    {
      throw new NotImplementedException();
    }
    
    public bool HasEssential()
    {
      throw new NotImplementedException();
    }

    public bool ValidMove(int x1, int y1, int x2, int y2)
    {
      throw new NotImplementedException();
    }
    
    public Colour Colour => throw new NotImplementedException();

    public Piece Piece
    {
      get => throw new NotImplementedException();
      set => throw new NotImplementedException();
    }
  }
}