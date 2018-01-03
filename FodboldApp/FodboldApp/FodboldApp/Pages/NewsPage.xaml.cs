using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FodboldApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
        public string str = "Siden 20 juli har Boldklubben FREMs nye setup været igang. Truppen begynder at tage form, og skarpheden til træning og i kamp viser en klar positiv tendens.&#x0a;&#x0a;Nyt træner-setup med Anders Sundstrup og Martin E.Jensen er taget godt imod.&#x0a;&#x0a;Martin E udtaler:&#x0a;& quot;Det er vildt fedt at arbejde med disse drenge, de leverer til træning og kamp.Troen på egne evner er i top.&#x0a;&#x0a;Holdet, som primært består af 17-20-årige spillere krydret med et lidt rutinerede spillere, har et stort potentiale, som vi i trænerteamet skal udvikle endnu mere.&#x0a;&#x0a;Vi har nu trænet en del og fået spillet 6 træningskampe (5 sejre og en uafgjort). Det vi har set, giver os en stor tro på tingene og mod på den nye sæson.&quot;&#x0a;&#x0a;Træner på 1. senior Morten Rutkjær:&#x0a;& quot;Jeg er tilfreds med udviklingen.U23-tanken har taget rigtig form og faktisk hurtigere end forventet.Det har været fedt at se gutterne spille en gang flot fodbold.&quot;&#x0a;&#x0a;Holdets næste opgaver er træningskamp lørdag kl. 11:00 hjemme mod Hvidovres reserver.Efter den venter første tuneringskamp mod GVI og derefter første kamp i U21A-tuneringen, hvor drengene skal en tur til Fremad Amager.";

        public NewsPage ()
		{
			InitializeComponent ();
		}
	}
}