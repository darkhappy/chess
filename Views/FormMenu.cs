using chess.Controllers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormMenu : Form
  {
    Chess _main;

    /// <summary>
    /// Initialize the form menu with its controller
    /// </summary>
    public FormMenu(Chess controller)
    {
      InitializeComponent();
      _main = controller;
    }

    private void FormMenu_Load(object sender, System.EventArgs e)
    {
      _main.UpdatePlayerList();
    }

    /// <summary>
    /// Enable the creation of a new game
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Start(object sender, System.EventArgs e)
    {
      if(txbPlayer1.Text == "" || txbPlayer2.Text == "")
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

    public void UpdatePlayerList(List<string> playerList)
    {
      listPlayer.Clear();

      listPlayer.View = View.Details;
      listPlayer.Columns.Add("Player", listPlayer.Width - 10);

      foreach (string player in playerList)
        listPlayer.Items.Add(player);
    }

    private void btnCancel_Click(object sender, System.EventArgs e)
    {
      if (((Button)sender).Name == "btnCancel1" && txbPlayer1.Text != "")
      {
        listPlayer.Items.Add(new ListViewItem(txbPlayer1.Text));
        txbPlayer1.Text = "";
      }
      else if(((Button)sender).Name == "btnCancel2" && txbPlayer2.Text != "")
      {
        listPlayer.Items.Add(new ListViewItem(txbPlayer2.Text));
        txbPlayer2.Text = "";
      }
    }

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

    private void listPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      var senderList = (ListView)sender;
      var clickedItem = senderList.HitTest(e.Location).Item;
      if (clickedItem != null)
      {
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
}