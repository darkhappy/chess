using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
  static class Chess
  {
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }


    public void Selection() {
        if (!ValidSelection()) return;
        Turn();
    }

    public void Turn() {
        if (!ValidMove()) return;
        if (EssentialExposed()) return;
        
        MakeTurn();
        DrawBoard(ExportBoard());

        CheckRules()

    }

    public CheckRules() 
    {
        // Checks
        if (Promotion())
        {
            AskPromotion();
        }

        if (FiftyTurns()) partienull();
        if (SameBoard()) partienull();

        // get assailants
        if (EssentialExposed())
        {
            if (EssentialScrewed())
            {
                show u won
            }
        }
        else if (Stalemate()){
            show u lost lol
        }
  }
}


public class Match {
    essentialExposed() {
        GetAssailants : list 
        If (list > 0) return true;
    }

    esentialScrewed() {
        GetAssailants : list

            HasAttackersAroundEssential(colour colour) //1 
        If (list == 1)
            HasAttackers(Assailant[0], colour colour) //2
            CanCockBlock(Assailant[0], colour colour) //3
    }

}

public class Board {
    list GetAssailants() {
        piece = getEssential();
        List mylsit;
        returnshit.add(tout les piece qui peut attacker);
        return mylist;
    } 

    

}
