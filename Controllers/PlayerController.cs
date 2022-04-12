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
      _frmPlayer = new FormPlayer(this);

      /*
      _list.Add(new Player("Raph", 5, 0, 1000));
      _list.Add(new Player("Louis", 0, 1000, -9999));
      _list.Add(new Player("Jean-Philipette", 100, 100, 1));
      */

      //Adding all player to the list and to the listView
      StreamReader sr = new StreamReader("players.txt");
      using (sr)
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          _list.Add((Player)StringToObject(line));
          _frmPlayer.AddPlayer((Player)StringToObject(line));
        }
      }
      sr.Close();
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
    /// Show the player form
    /// </summary>
    public void Show()
    {
      _frmPlayer.Show();
    }

    /// <summary>
    /// Close the player form
    /// </summary>
    public void Back()
    {
      _frmPlayer.Close();
    }

    public List<Player> GetPlayerList()
    {
      return _list;
    }

    public Player GetPlayer(string name)
    {
      return _list.Find(x => x.Name == name);
    }

    /// <summary>
    /// Serialize an object returning the
    /// bytes as a Base64 encoded string
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public string ObjectToString(object obj)
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
    public object StringToObject(string base64String)
    {
      byte[] bytes = Convert.FromBase64String(base64String);
      using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
      {
        ms.Write(bytes, 0, bytes.Length);
        ms.Position = 0;
        return new BinaryFormatter().Deserialize(ms);
      }
    }

    /*
    public static void Main()
    {
      // Ra and Rb are current ELO ratings
      float ranking1 = 1200, ranking2 = 1000;


      bool player1Win = true;
      UpdateEloRating(ranking1, ranking2, player1Win);
    }*/


    // Function to calculate Elo rating
    // K is a constant.
    // d determines whether Player A wins or
    // Player B. 
    static void UpdateEloRating(Player player1, Player player2, bool player1Win)
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
        ranking1 = ranking1 + K * (1 - winningProb1);
        ranking2 = ranking2 + K * (0 - winningProb2);
      }
      else
      {
        ranking1 = ranking1 + K * (0 - winningProb1);
        ranking2 = ranking2 + K * (1 - winningProb2);
      }

      /*
      Console.Write("Updated Ratings:-\n");

      Console.Write("ranking1 = " + (Math.Round(ranking2
                   * 1000000.0) / 1000000.0)
                  + " ranking2 = " + Math.Round(ranking2
                   * 1000000.0) / 1000000.0);*/
    }

    /// <summary>
    /// Return the probabilité of winning of a rating againts another
    /// </summary>
    /// <param name="rating1"></param>
    /// <param name="rating2"></param>
    /// <returns></returns>
    static float Probability(float rating1, float rating2)
    {
      return 1.0f * 1.0f / (1 + 1.0f *
             (float)(Math.Pow(10, 1.0f *
               (rating1 - rating2) / 400)));
    }
  }
}