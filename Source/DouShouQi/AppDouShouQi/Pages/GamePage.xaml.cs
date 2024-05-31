namespace AppDouShouQi.Pages;

using DouShouQiLib;
using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;

public partial class GamePage : ContentPage
{
    public Manager GM => (Application.Current as App)!.TheMgr;

    public Case? placeStart { get; set; }

    void OnTapCase(object sender, EventArgs e)
    {
        var button = (sender as Button)!;
        //int x = int.Parse(button[0]);
        //int y = int.Parse(button[1]);
        Case thisCase = (button.BindingContext as Case)!;
        if (placeStart == null)
        {
            if (thisCase.Onthis.HasValue)
            {
                if (!GM.game.AppartientJC(thisCase.Onthis.Value) ) return;
                placeStart = thisCase;
            }
        }
        else
        {
            bool ok = GM.game.MovePiece(placeStart, thisCase, GM.game.Plateau);
            placeStart = null;
            if (ok) GM.game.ChangePlayer();
        }
        return;
    }

    public GamePage()
	{
		InitializeComponent();
        BindingContext = this;
    }
}