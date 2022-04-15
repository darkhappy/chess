using System;
using System.Collections.Generic;
using System.Windows.Forms;
using chess.Controllers;

namespace chess.Views
{
  public partial class FormMenu : Form
  {
    private readonly Chess _main;

    /// <summary>
    ///   Initialize the form menu with its controller
    /// </summary>
    public FormMenu(Chess controller)
    {
      InitializeComponent();
      _main = controller;
    }

    /// <summary>
    /// Loads the player list on form load 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormMenu_Load(object sender, EventArgs e)
    {
      _main.UpdatePlayerList();
    }

    /// <summary>
    ///   Enable the creation of a new game
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Start_Click(object sender, EventArgs e)
    {
      if (txbPlayer1.Text == "" || txbPlayer2.Text == "")
      {
        labError.Visible = true;
      }
      else
      {
        labError.Visible = false;
        _main.NewGame(txbPlayer1.Text, txbPlayer2.Text);
        txbPlayer1.Text = "";
        txbPlayer2.Text = "";
        _main.UpdatePlayerList();
      }
    }

    /// <summary>
    ///   Enable the management of players
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ManagePlayer_Click(object sender, EventArgs e)
    {
      _main.ManagePlayers();
    }

    /// <summary>
    ///   Exit the application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Exit_Click(object sender, EventArgs e)
    {
      _main.Exit();
    }

    /// <summary>
    ///   Updates the list of players with the new one
    /// </summary>
    /// <param name="playerList">List of players</param>
    public void UpdatePlayerList_Click(List<string> playerList)
    {
      listPlayer.Clear();

      listPlayer.View = View.Details;
      listPlayer.Columns.Add("Player", listPlayer.Width - 10);

      foreach (var player in playerList)
        listPlayer.Items.Add(player);
    }

    /// <summary>
    ///   Removes a player from the game selection
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RemovePlayer_Click(object sender, EventArgs e)
    {
      if (((Button) sender).Name == "btnCancel1" && txbPlayer1.Text != "")
      {
        listPlayer.Items.Add(new ListViewItem(txbPlayer1.Text));
        txbPlayer1.Text = "";
      }
      else if (((Button) sender).Name == "btnCancel2" && txbPlayer2.Text != "")
      {
        listPlayer.Items.Add(new ListViewItem(txbPlayer2.Text));
        txbPlayer2.Text = "";
      }
    }

    /// <summary>
    ///   Removes both players from the game selection
    /// </summary>
    public void CancelSelection()
    {
      if (txbPlayer1.Text != "")
      {
        listPlayer.Items.Add(new ListViewItem(txbPlayer1.Text));
        txbPlayer1.Text = "";
      }

      if (txbPlayer2.Text != "")
      {
        listPlayer.Items.Add(new ListViewItem(txbPlayer2.Text));
        txbPlayer2.Text = "";
      }
    }

    /// <summary>
    ///   Adds a player to the game selection
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddPlayer_Click(object sender, MouseEventArgs e)
    {
      var senderList = (ListView) sender;
      var clickedItem = senderList.HitTest(e.Location).Item;
      if (clickedItem == null) return;

      if (txbPlayer1.Text == "")
      {
        txbPlayer1.Text = clickedItem.Text;
        listPlayer.Items.Remove(clickedItem);
      }
      else if (txbPlayer2.Text == "")
      {
        txbPlayer2.Text = clickedItem.Text;
        listPlayer.Items.Remove(clickedItem);
      }
    }
  }
}