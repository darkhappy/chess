using System;
using System.Collections.Generic;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class PlayerController
  {
    List<Player> _list;
    Chess _main;
    //FormPlayer _frmPlayer;

    public PlayerController(Chess main)
    {
      _main = main;
     // _frmPlayer = new FormPlayer();
     // _frmPlayer.Show();
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