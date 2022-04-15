using System;
using System.Collections.Generic;
using System.Windows.Forms;
using chess.Controllers;
using chess.Models;

namespace chess.Views
{
  /// <summary>
  ///   Represents the form to create and delete player.
  ///   It can also be used as a leaderbord
  /// </summary>
  public partial class FormPlayer : Form
  {
    private readonly PlayerController _controller;

    /// <summary>
    ///   Initialize the FormPlayer with its controller
    /// </summary>
    /// <param name="controller"></param>
    public FormPlayer(PlayerController controller)
    {
      InitializeComponent();
      _controller = controller;
    }

    /// <summary>
    ///   Prepare the listView to host all players
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormPlayer_Load(object sender, EventArgs e)
    {
      listPlayer.View = View.Details;
      listPlayer.Columns.Add("Player", listPlayer.Width / 2);
      listPlayer.Columns.Add("Points", listPlayer.Width / 2);
    }

    /// <summary>
    ///   Create a new player
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Add_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(tbxName.Text))
      {
        labError.Visible = true;
        labError.Text = "The field needs a name.";
      }
      else if (_controller.Exists(tbxName.Text))
      {
        labError.Visible = true;
        labError.Text = "This player already exists";
      }
      else
      {
        _controller.Add(tbxName.Text);
        tbxName.Text = "";
        labError.Visible = false;
      }
    }

    /// <summary>
    ///   Go back to the menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Back_Click(object sender, EventArgs e)
    {
      _controller.Back();
    }

    /// <summary>
    ///   Delete all selected players
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Remove_Click(object sender, EventArgs e)
    {
      var indices = new int[listPlayer.SelectedIndices.Count];
      var i = 0;

      foreach (int index in listPlayer.SelectedIndices)
      {
        indices[i] = index;
        i++;
      }

      Array.Reverse(indices);

      foreach (var index in indices)
      {
        _controller.Remove(index);
        listPlayer.Items.RemoveAt(index);
      }
    }

    /// <summary>
    ///   Adding player to the listView
    /// </summary>
    /// <param name="player"></param>
    public void AddPlayer(Player player)
    {
      string[] toAdd = {player.Name, player.Points.ToString()};
      listPlayer.Items.Add(new ListViewItem(toAdd));
    }

    /// <summary>
    ///   Update the player list view with a list of player
    /// </summary>
    /// <param name="playerList"></param>
    public void UpdatePlayerList(List<Player> playerList)
    {
      listPlayer.Items.Clear();
      foreach (var player in playerList) AddPlayer(player);
    }
  }
}