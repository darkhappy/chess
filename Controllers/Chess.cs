using System;
using System.Collections.Generic;
using System.Windows.Forms;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class Chess
  {
    List<GameController> _listGames;

    FormMenu _frmMenu;
    FormSelection _frmSelect;
    FormMatch _frmMatch;

    /// <summary>
    /// Application entry point
    /// </summary>
    [STAThread]
    public static void Main()
    {
      Chess chess = new Chess();
    }

    /// <summary>
    /// Create a new Chess controller and start the application
    /// </summary>
    public Chess()
    {
      _frmMatch = new FormMatch();
      Application.Run(_frmMatch);
      /*_frmMenu = new FormMenu(this);
      Application.Run(_frmMenu);*/
    }

    /// <summary>
    /// Show the form selection to manage player and start a game
    /// </summary>
    public void NewGame()
    {
      _frmSelect = new FormSelection();
    }

    
    public void StartGame(Player[] players)
    {
      throw new NotImplementedException();
    }

    public void ManagePlayers()
    {
      
    }

    /// <summary>
    /// Close all windows and exit the application
    /// </summary>
    public void Exit()
    {
      Application.Exit();
    }
  }
}