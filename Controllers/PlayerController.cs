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
  }
}