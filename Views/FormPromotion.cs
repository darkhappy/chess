using System;
using System.Windows.Forms;
using chess.Controllers;
using chess.Models;
using chess.Properties;

namespace chess.Views
{
  /// <summary>
  ///   Represents the form to promote a pawn.
  /// </summary>
  public partial class FormPromotion : Form
  {
    /// <summary>
    ///   Represents the game controller.
    /// </summary>
    private readonly GameController _main;

    /// <summary>
    ///   Initializes a new instance of the <see cref="FormPromotion" /> class.
    /// </summary>
    /// <param name="main">The controller of the game</param>
    /// <param name="current">The colour of the current player</param>
    public FormPromotion(GameController main, Colour current)
    {
      _main = main;
      InitializeComponent();


      if (current != Colour.Black) return;

      pbQueen.Image = Resources.b_queen;
      pbKnight.Image = Resources.b_knight;
      pbRook.Image = Resources.b_rook;
      pbBishop.Image = Resources.b_bishop;
    }

    /// <summary>
    ///   Handles the click event on a promotion.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Promotion_Click(object sender, EventArgs e)
    {
      switch (((PictureBox) sender).Name)
      {
        case "pbQueen":
          _main.Promote('q');
          break;
        case "pbKnight":
          _main.Promote('k');
          break;
        case "pbRook":
          _main.Promote('r');
          break;
        case "pbBishop":
          _main.Promote('b');
          break;
      }

      Close();
    }
  }
}