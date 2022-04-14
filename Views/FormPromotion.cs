using chess.Controllers;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormPromotion : Form
  {
    GameController _main;

    public delegate void callback_data(string piece);
    public event callback_data GetPiece_CallBack;

    public FormPromotion(GameController main)
    {
      _main = main;
      InitializeComponent();
      cmbPromotion.SelectedIndex = 0;
    }

    private void BtnPromote_Click(object sender, System.EventArgs e)
    {
      _main.Promote(cmbPromotion.Text);
      Close();
    }
  }
}