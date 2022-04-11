using chess.Controllers;
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
  }
}