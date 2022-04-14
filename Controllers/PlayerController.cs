using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  /// <summary>
  /// Represent the player controller of the chess game
  /// </summary>
  public class PlayerController
  {
    List<Player> _list;
    Chess _main;
    FormPlayer _frmPlayer;

    /// <summary>
    /// Initialize the PlayerController with its controller
    /// </summary>
    /// <param name="main">Chess controller</param>
    public PlayerController(Chess main)
    {
      _main = main;
      _list = new List<Player>();

      if (!File.Exists("players.txt"))
         File.Create("players.txt").Close();


      using (StreamReader sr = new StreamReader("players.txt"))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          _list.Add((Player)StringToObject(line));
        }
      }

      SortPlayerByRanking();
    }


    /// <summary>
    /// Add a player with its name
    /// </summary>
    /// <param name="name">Name of the wanted player</param>
    public void Add(string name)
    {
      Player newPlayer = new Player(name);

      _list.Add(newPlayer);
      _frmPlayer.AddPlayer(newPlayer);

      using (StreamWriter sw = new StreamWriter("players.txt", true))
        sw.WriteLine(ObjectToString(newPlayer));

      SortPlayerByRanking();
      _frmPlayer.UpdatePlayerList(_list);
      _main.UpdatePlayerList();

    }

    /// <summary>
    /// Remove a player
    /// </summary>
    /// <param name="index">Index of the player we want to remove in the player list</param>
    public void Remove(int index)
    {
      string line = null;

      using (StreamReader reader = new StreamReader("players.txt"))
      {
        using (StreamWriter writer = new StreamWriter("newPlayers.txt"))
        {
          while ((line = reader.ReadLine()) != null)
          {
            if (String.Compare(line, ObjectToString(_list[index])) == 0)
              continue;

            writer.WriteLine(line);
          }
        }
      }

      File.Delete("players.txt");
      File.Move("newPlayers.txt", "players.txt");

      _list.RemoveAt(index);
    }

    /// <summary>
    /// Check if a player exists by its name
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Return true if the player exist, false otherwise</returns>
    public bool Exists(string name)
    {
      foreach (Player player in _list)
        if (player.Name == name) return true;

      return false;
    }

    /// <summary>
    /// Create the player form and show it
    /// </summary>
    public void Show()
    {
      _frmPlayer = new FormPlayer(this);
      _frmPlayer.UpdatePlayerList(_list);
      _frmPlayer.Show();
    }

    /// <summary>
    /// Close the player form
    /// </summary>
    public void Back()
    {
      _frmPlayer.Close();
    }

    /// <summary>
    /// Get all players
    /// </summary>
    /// <returns>A list of all existing players</returns>
    public List<Player> GetPlayerList()
    {
      return _list;
    }

    /// <summary>
    /// Get a player by its name
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Returns the searched play by name</returns>
    public Player GetPlayer(string name)
    {
      return _list.Find(x => x.Name == name);
    }

    /// <summary>
    /// Update the player string in the datafile
    /// </summary>
    /// <param name="player">Player needing an update, that has been modified</param>
    public void UpdatePlayer(Player player)
    {
      string line = null;

      using (StreamReader reader = new StreamReader("players.txt"))
      {
        using (StreamWriter writer = new StreamWriter("updatePlayer.txt"))
        {
          while ((line = reader.ReadLine()) != null)
          {
            if (((Player)StringToObject(line)).Name == player.Name)
              writer.WriteLine(ObjectToString(player));
            else
              writer.WriteLine(line);

            continue;
          }
        }
      }

      File.Delete("players.txt");
      File.Move("updatePlayer.txt", "players.txt");
    }

    /// <summary>
    /// Update ELO rating of 2 players after their math
    /// </summary>
    /// <param name="playerA">Fisrt player in the match</param>
    /// <param name="playerB">Second player in the match</param>
    /// <param name="playerAWin">If the first player has win or not</param>
    public void UpdateEloRating(Player playerA, Player playerB, bool playerAWin)
    {
      int K = 30;

      float rankingA = playerA.Points;
      float rankingB = playerA.Points;

      float winningProbA = Probability(rankingB, rankingA);
      float winningProbB = Probability(rankingA, rankingB);

      //Updating the Elo Ratings with the winner
      if (playerAWin)
      {
        playerA.Points = (int)(rankingA + K * (1 - winningProbA));
        playerB.Points = (int)(rankingB + K * (0 - winningProbB));
      }
      else
      {
        playerA.Points = (int)(rankingA + K * (0 - winningProbA));
        playerB.Points = (int)(rankingB + K * (1 - winningProbB));
      }

      UpdatePlayer(playerA);
      UpdatePlayer(playerB);
    }

    /// <summary>
    /// Return the probability of winning of a rating againts another
    /// </summary>
    /// <param name="rating1">Points of the first player</param>
    /// <param name="rating2">Points of the second player</param>
    /// <returns></returns>
    private float Probability(float rating1, float rating2)
    {
      return 1.0f * 1.0f / (1 + 1.0f *
             (float)(Math.Pow(10, 1.0f *
               (rating1 - rating2) / 400)));
    }

    /// <summary>
    /// Bubble sort of all player, sorting by highest ranking to lowest
    /// </summary>
    private void SortPlayerByRanking()
    {
      for (int i = 0; i < _list.Count - 1; i++)
      {
        for (int j = 0; j < _list.Count - i - 1; j++)
        {
          if (_list[j].Points < _list[j + 1].Points)
          {
            Player temp = _list[j];
            _list[j] = _list[j + 1];
            _list[j + 1] = temp;
          }
        }
      }
    }

    /// <summary>
    /// Serialize an object returning the
    /// bytes as a Base64 encoded string
    /// </summary>
    /// <param name="obj">Object that need to be serialized</param>
    /// <returns>Serialized form of the object in Base64 encoded string</returns>
    private string ObjectToString(object obj)
    {
      using (MemoryStream ms = new MemoryStream())
      {
        new BinaryFormatter().Serialize(ms, obj);
        return Convert.ToBase64String(ms.ToArray());
      }
    }

    /// <summary>
    /// Deserialize an object returning 
    /// the decoded Base64 string of an object
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>Object from Base64 encoded string</returns>
    private object StringToObject(string base64String)
    {
      byte[] bytes = Convert.FromBase64String(base64String);
      using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
      {
        ms.Write(bytes, 0, bytes.Length);
        ms.Position = 0;
        return new BinaryFormatter().Deserialize(ms);
      }
    }
  }
}