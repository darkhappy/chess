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

    PlayerController _playerController;
    GameController _gameController;

    FormMenu _frmMenu;

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
      _playerController = new PlayerController(this);
      _frmMenu = new FormMenu(this);
      Application.Run(_frmMenu);

      _frmMenu.GeneratePlayerList(PlayersToString(_playerController.GetPlayerList()));
    }

    /// <summary>
    /// Show the form selection to start a game
    /// </summary>
    public void NewGame()
    {
      _gameController = new GameController(new Player("Benjamin"), new Player("Benjamino"));
    }

    /// <summary>
    /// Show the form selection to start a game
    /// </summary>
    public void StartGame(Player[] players)
    {
      //GameController gameController = new GameController(this);
    }

    public List<string> PlayersToString(List<Player> playerList)
    {
      List<string> list = new List<string>();

      foreach (Player player in playerList)
        list.Add(player.Name);

      return list;
    }

    public void ManagePlayers()
    {
      _playerController.Show();
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