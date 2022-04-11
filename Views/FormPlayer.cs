using chess.Controllers;
using chess.Models;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormPlayer : Form
  {
    PlayerController _controller;

    public FormPlayer(PlayerController controller)
    {
      InitializeComponent();
      _controller = controller;
    }

    public void AddPlayer(Player player)
    {
      string[] toAdd = new string[]{player.Name, player.Victory.ToString(), player.Defeat.ToString(), player.Points.ToString() };
      listPlayer.Items.Add(new ListViewItem(toAdd));
    }

    private void FormPlayer_Load(object sender, System.EventArgs e)
    {
      listPlayer.View = View.Details;
      listPlayer.Columns.Add("Player", listPlayer.Width / 4);
      listPlayer.Columns.Add("Victory", listPlayer.Width / 4);
      listPlayer.Columns.Add("Defeat", listPlayer.Width / 4);
      listPlayer.Columns.Add("Points", listPlayer.Width / 4);
    }

    private void btnNew_Click(object sender, System.EventArgs e)
    {
      _controller.Add();
    }

    private void btnBack_Click(object sender, System.EventArgs e)
    {
      //_controller.Back();
    }
  }
}