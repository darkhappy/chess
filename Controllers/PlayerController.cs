using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using chess.Models;
using chess.Views;

namespace chess.Controllers
{
  public class PlayerController
  {
    List<Player> _list;
    Chess _main;
    FormPlayer _frmPlayer;

    /// <summary>
    /// Initialize the PlayerController with its controller
    /// </summary>
    /// <param name="main"></param>
    public PlayerController(Chess main)
    {
      _main = main;
      _list = new List<Player>();

      StreamReader sr = new StreamReader("players.txt");
      using (sr)
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          _list.Add((Player)StringToObject(line));
        }
      }
      sr.Close();

      SortPlayerByRanking();
    }


    /// <summary>
    /// Add a player with its name
    /// </summary>
    /// <param name="name"></param>
    public void Add(string name)
    {
      Player newPlayer = new Player(name);

      _list.Add(newPlayer);
      _frmPlayer.AddPlayer(newPlayer);
      StreamWriter sw = new StreamWriter("players.txt", true);

      using (sw)
        sw.WriteLine(ObjectToString(newPlayer));

      sw.Close();

      SortPlayerByRanking();
      _frmPlayer.UpdatePlayerList(_list);
    }

    /// <summary>
    /// Remove a player
    /// </summary>
    /// <param name="index"></param>
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
    /// <returns></returns>
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
    /// <returns></returns>
    public List<Player> GetPlayerList()
    {
      return _list;
    }

    /// <summary>
    /// Get a player by its name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Player GetPlayer(string name)
    {
      return _list.Find(x => x.Name == name);
    }

    /// <summary>
    /// Update the player string in the datafile
    /// </summary>
    /// <param name="player"></param>
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

    // Function to calculate Elo rating
    // K is a constant.
    // d determines whether Player A wins or
    // Player B. 
    public void UpdateEloRating(Player player1, Player player2, bool player1Win)
    {
      int K = 30;

      float ranking1 = player1.Points;
      float ranking2 = player2.Points;

      // To calculate the Winning Probability of Player 1
      float winningProb1 = Probability(ranking2, ranking1);

      // To calculate the Winning Probability of Player 2
      float winningProb2 = Probability(ranking1, ranking2);

      //Updating the Elo Ratings with the winner
      if (player1Win)
      {
        player1.Points = (int)(ranking1 + K * (1 - winningProb1));
        player2.Points = (int)(ranking2 + K * (0 - winningProb2));
      }
      else
      {
        player1.Points = (int)(ranking1 + K * (0 - winningProb1));
        player2.Points = (int)(ranking2 + K * (1 - winningProb2));
      }

      UpdatePlayer(player1);
      UpdatePlayer(player2);

      _frmPlayer.UpdatePlayerList(_list);

    }

    /// <summary>
    /// Return the probabilité of winning of a rating againts another
    /// </summary>
    /// <param name="rating1"></param>
    /// <param name="rating2"></param>
    /// <returns></returns>
    private float Probability(float rating1, float rating2)
    {
      return 1.0f * 1.0f / (1 + 1.0f *
             (float)(Math.Pow(10, 1.0f *
               (rating1 - rating2) / 400)));
    }

    /// <summary>
    /// Bubble sort of all player 
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
    /// <param name="obj"></param>
    /// <returns></returns>
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
    /// <returns></returns>
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