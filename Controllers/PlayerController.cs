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
    //FormPlayer _frmPlayer;

    StreamWriter _sw;
    StreamReader _sr;

    public PlayerController(Chess main)
    {
      _main = main;
      _list = new List<Player>();
      _frmPlayer = new FormPlayer(this);
      _frmPlayer.Show();

      _list.Add(new Player("Raph", 5, 0, 1000));
      _list.Add(new Player("Louis", 0, 1000, -9999));
      _list.Add(new Player("Jean-Philipette", 100, 100, 1));
      
      _sw = new StreamWriter("players.txt", true);
      using (_sw)
      {
        foreach (Player player in _list)
        {
          _sw.WriteLine(ObjectToString(player));
        }
      }
      _sw.Close();

      _sr = new StreamReader("players.txt", true);
      using (_sr)
      {
        string line;
        while ((line = _sr.ReadLine()) != null)
        {
          _frmPlayer.AddPlayer((Player)StringToObject(line));
        }
      }
      _sr.Close();
    }

    public void Add()
    {
      
      throw new NotImplementedException();
    }

    public void Remove()
    {
      throw new NotImplementedException();
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