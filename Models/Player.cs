using System;
using System.Collections;

namespace chess.Models
{
  [Serializable]
  public class Player
  {
    string _name;
    int _victory;
    int _defeat;
    int _points;

    /// <summary>
    /// Create a new player with its name
    /// </summary>
    /// <param name="name"></param>
    public Player(string name)
    {
      _name = name;
      _victory = 0;
      _defeat = 0;
      _points = 1200;
    }

    /// <summary>
    /// Create a new player with all its data
    /// </summary>
    /// <param name="name"></param>
    public Player(string name, int victory, int defeat, int points)
    {
      _name = name;
      _victory = victory;
      _defeat = defeat;
      _points = points;
    }

    /// <summary>
    /// Return or set the player name
    /// </summary>
    public string Name
    {
      get => _name;
      set => _name = value;
    }

    /// <summary>
    /// return or set the player victory count
    /// </summary>
    public int Victory
    {
      get => _victory;
      set => _victory = value;
    }

    /// <summary>
    /// return or set the player defeat count
    /// </summary>
    public int Defeat
    {
      get => _defeat;
      set => _defeat = value;
    }

    /// <summary>
    /// return or set the player points
    /// </summary>
    public int Points
    {
      get => _points;
      set => _points = value;
    }
  }
}