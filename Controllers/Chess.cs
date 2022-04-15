using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  /// <summary>
  ///   Represent the main controller of the chess game
  /// </summary>
  public class Chess
  {
    private readonly List<GameController> _listGames;
    private readonly FormMenu _menu;
    private readonly PlayerController _playerController;

    /// <summary>
    ///   Create a new Chess controller and start the application
    /// </summary>
    public Chess()
    {
      _listGames = new List<GameController>();
      _playerController = new PlayerController(this);
      _menu = new FormMenu(this);
      Application.Run(_menu);
      UpdatePlayerList();
    }

    /// <summary>
    ///   Application entry point
    /// </summary>
    [STAThread]
    public static void Main()
    {
      new Chess();
    }

    /// <summary>
    ///   Update menu player list
    /// </summary>
    public void UpdatePlayerList()
    {
      _menu.UpdatePlayerList_Click(PlayersToString(_playerController.GetPlayerList()));
    }

    /// <summary>
    ///   Show the form selection to start a game
    /// </summary>
    public void NewGame(string name1, string name2)
    {
      var player1 = _playerController.GetPlayer(name1);
      var player2 = _playerController.GetPlayer(name2);

      var gameController = new GameController(this, player1, player2);
      _listGames.Add(gameController);
    }

    /// <summary>
    ///   Convert a player list into a string list
    /// </summary>
    /// <param name="players">List of players</param>
    /// <returns>Player list converted to string list</returns>
    private static List<string> PlayersToString(List<Player> players)
    {
      return players.Select(player => player.Name).ToList();
    }

    /// <summary>
    ///   Update players ELO rating
    /// </summary>
    /// <param name="player1"></param>
    /// <param name="player2"></param>
    /// <param name="player1Won"></param>
    public void SetWinner(Player player1, Player player2, bool player1Won)
    {
      PlayerController.UpdateEloRating(player1, player2, player1Won);
    }

    /// <summary>
    ///   Show player form
    /// </summary>
    public void ManagePlayers()
    {
      _menu.CancelSelection();
      _playerController.Show();
    }

    /// <summary>
    ///   Close all windows and exit the application
    /// </summary>
    public void Exit()
    {
      Application.Exit();
    }
  }
}