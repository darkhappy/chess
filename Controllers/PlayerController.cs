using System;
using System.Collections.Generic;
using chess.Models;

namespace chess.Controllers
{
  public class PlayerController
  {
    private List<Player> _list;
    private Chess _main;

    public PlayerController(Chess main)
    {
      _main = main;
    }

    public void Add()
    {
      throw new NotImplementedException();
    }

    public void Remove()
    {
      throw new NotImplementedException();
    }
  }
}