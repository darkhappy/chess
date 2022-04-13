using System;
using System.Collections.Generic;
using System.Windows.Forms;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class Chess
  {
    private List<GameController> _listGames;
    private PlayerController _playerController;
    private FormMenu _frmMenu;

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
      _listGames = new List<GameController>();
      _playerController = new PlayerController(this);
      _frmMenu = new FormMenu(this);
      _frmMenu.GeneratePlayerList(PlayersToString(_playerController.GetPlayerList()));
      Application.Run(_frmMenu);
    }

    /// <summary>
    /// Show the form selection to start a game
    /// </summary>
    public void NewGame(string name1, string name2)
    {
      Player player1 = _playerController.GetPlayer(name1);
      Player player2 = _playerController.GetPlayer(name2);

      GameController gameController = new GameController(player1, player2);
      _listGames.Add(gameController);
    }

    /// <summary>
    /// Convert a player list into a string list
    /// </summary>
    /// <param name="playerList"></param>
    /// <returns></returns>
    public List<string> PlayersToString(List<Player> playerList)
    {
      List<string> list = new List<string>();

      foreach (Player player in playerList)
        list.Add(player.Name);

      return list;
    }

    /// <summary>
    /// Show player form
    /// </summary>
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