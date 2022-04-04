using chess.Controllers;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormMenu : Form
  {
    Chess _main;

    /// <summary>
    /// Initialize the form
    /// </summary>
    public FormMenu()
    {
      InitializeComponent();
    }

    public FormMenu(Chess controller)
    {
      InitializeComponent();
      _main = controller;
    }

    private void Exit (object sender, System.EventArgs e)
    {

    }
  }
}