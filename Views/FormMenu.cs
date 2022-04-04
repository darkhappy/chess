using chess.Controllers;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormMenu : Form
  {
    Chess _main;

    /// <summary>
    /// Initialize the formm menu
    /// </summary>
    public FormMenu()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initialize the formm menu with its controller
    /// </summary>
    public FormMenu(Chess controller)
    {
      InitializeComponent();
      _main = controller;
    }

    /// <summary>
    /// Exit the application
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Exit (object sender, System.EventArgs e)
    {
      _main.Exit();
    }
  }
}