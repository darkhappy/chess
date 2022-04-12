using chess.Controllers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormMenu : Form
  {
    Chess _main;

    /// <summary>
    /// Initialize the form menu
    /// </summary>
    public FormMenu()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initialize the form menu with its controller
    /// </summary>
    public FormMenu(Chess controller)
    {
      InitializeComponent();
      _main = controller;
    }

    /// <summary>
    /// Enable the creation of a new game
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Start(object sender, System.EventArgs e)
    {
      _main.NewGame();
    }

    /// <summary>
    /// Enable the management of players
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ManagePlayer(object sender, System.EventArgs e)
    {
      _main.ManagePlayers();
    }

    /// <summary>
    /// Exit the application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Exit(object sender, System.EventArgs e)
    {
      _main.Exit();
    }

    public void GeneratePlayerList(List<string> playerList)
    {
      listPlayer.View = View.Details;
      listPlayer.Columns.Add("Player", listPlayer.Width);

      foreach (string player in playerList)
        listPlayer.Items.Add(player);
    }

    private void btnCancel_Click(object sender, System.EventArgs e)
    {
      if (((Button)sender).Name == "btnCancel1") txbPlayer1.Text = "";
      else txbPlayer2.Text = "";
    }

    private void listPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      var senderList = (ListView)sender;
      var clickedItem = senderList.HitTest(e.Location).Item;
      if (clickedItem != null)
      {
        if(txbPlayer1.Text == "") txbPlayer1.Text = clickedItem.Text;
        else if(txbPlayer2.Text == "") txbPlayer2.Text = clickedItem.Text;
      }
    }
  }
}