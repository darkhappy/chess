using System;
using System.Collections.Generic;
using System.Windows.Forms;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  /// <summary>
  /// Represent the main controller of the chess game
  /// </summary>
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
      Application.Run(_frmMenu);
      UpdatePlayerList();
    }

    /// <summary>
    /// Update menu player list
    /// </summary>
    public void UpdatePlayerList()
    {
      _frmMenu.UpdatePlayerList(PlayersToString(_playerController.GetPlayerList()));
    }

    /// <summary>
    /// Show the form selection to start a game
    /// </summary>
    public void NewGame(string name1, string name2)
    {
      Player player1 = _playerController.GetPlayer(name1);
      Player player2 = _playerController.GetPlayer(name2);

      GameController gameController = new GameController(this, player1, player2);
      _listGames.Add(gameController);
    }

    /// <summary>
    /// Convert a player list into a string list
    /// </summary>
    /// <param name="playerList">List of players</param>
    /// <returns>Player list converted to string list</returns>
    public List<string> PlayersToString(List<Player> playerList)
    {
      List<string> list = new List<string>();

      foreach (Player player in playerList)
        list.Add(player.Name);

      return list;
    }

    /// <summary>
    /// Update players ELO rating
    /// </summary>
    /// <param name="player1"></param>
    /// <param name="player2"></param>
    /// <param name="player1Win"></param>
    public void setWinner(Player player1, Player player2, bool player1Win)
    {
      _playerController.UpdateEloRating(player1, player2, player1Win);
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