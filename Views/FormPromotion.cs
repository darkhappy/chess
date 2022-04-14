using chess.Controllers;
using chess.Models;
using chess.Properties;
using System.Windows.Forms;

namespace chess.Views
{
  public partial class FormPromotion : Form
  {
    GameController _main;

    public FormPromotion(GameController main, Colour current)
    {
      _main = main;
      InitializeComponent();


      if(current == Colour.Black)
      {
        pbQueen.Image = Resources.b_queen;
        pbKnight.Image = Resources.b_knight;
        pbRook.Image = Resources.b_rook;
        pbBishop.Image = Resources.b_bishop;
      }
    }
    
    private void Promotion_Click(object sender, System.EventArgs e)
    {
      switch (((PictureBox)sender).Name)
      {
        case "pbQueen":
          _main.Promote("Queen");
          break;
        case "pbKnight":
          _main.Promote("Knight");
          break;
        case "pbRook":
          _main.Promote("Rook");
          break;
        case "pbBishop":
          _main.Promote("Bishop");
          break;
      }

      Close();
    }
  }
}