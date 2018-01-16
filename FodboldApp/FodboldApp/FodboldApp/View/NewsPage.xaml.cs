using FodboldApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
        public string NewsText { get; } = "Siden 20 juli har Boldklubben FREMs nye setup været igang. Truppen begynder at tage form, og skarpheden til træning og i kamp viser en klar positiv tendens.\r\n\r\nNyt træner-setup med Anders Sundstrup og Martin E.Jensen er taget godt imod.\r\n\r\nMartin E udtaler:\r\n\";Det er vildt fedt at arbejde med disse drenge, de leverer til træning og kamp.Troen på egne evner er i top.\r\n\r\nHoldet, som primært består af 17-20-årige spillere krydret med et lidt rutinerede spillere, har et stort potentiale, som vi i trænerteamet skal udvikle endnu mere.\r\n\r\nVi har nu trænet en del og fået spillet 6 træningskampe (5 sejre og en uafgjort). Det vi har set, giver os en stor tro på tingene og mod på den nye sæson.&quot;\r\n\r\nTræner på 1. senior Morten Rutkjær:\r\n\";Jeg er tilfreds med udviklingen.U23-tanken har taget rigtig form og faktisk hurtigere end forventet.Det har været fedt at se gutterne spille en gang flot fodbold.\"\r\n\r\nHoldets næste opgaver er træningskamp lørdag kl. 11:00 hjemme mod Hvidovres reserver.Efter den venter første tuneringskamp mod GVI og derefter første kamp i U21A-tuneringen, hvor drengene skal en tur til Fremad Amager.";

        protected override bool OnBackButtonPressed()
        {
            HeaderVM.BackButtonPressed();
            return true;
        }

        public NewsPage ()
		{
			InitializeComponent ();

            BindingContext = this;

            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}