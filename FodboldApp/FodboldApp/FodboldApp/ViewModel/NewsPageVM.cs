using Plugin.Share;
using Plugin.Share.Abstractions;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    public class NewsPageVM
    {
        public ICommand ShareCommand { get; set; }
        public string Title { get; private set; } = "U23 kommet godt fra start";
        public string DateTime { get; private set; } = "10. august 2017";
        public string SmallText { get; private set; } = "Nyt fra U23";
        public string NewsText { get; private set; } = "Siden 20 juli har Boldklubben FREMs nye setup været igang. Truppen begynder at tage form, og skarpheden til træning og i kamp viser en klar positiv tendens.\r\n\r\nNyt træner-setup med Anders Sundstrup og Martin E.Jensen er taget godt imod.\r\n\r\nMartin E udtaler:\r\n\";Det er vildt fedt at arbejde med disse drenge, de leverer til træning og kamp.Troen på egne evner er i top.\r\n\r\nHoldet, som primært består af 17-20-årige spillere krydret med et lidt rutinerede spillere, har et stort potentiale, som vi i trænerteamet skal udvikle endnu mere.\r\n\r\nVi har nu trænet en del og fået spillet 6 træningskampe (5 sejre og en uafgjort). Det vi har set, giver os en stor tro på tingene og mod på den nye sæson.&quot;\r\n\r\nTræner på 1. senior Morten Rutkjær:\r\n\";Jeg er tilfreds med udviklingen.U23-tanken har taget rigtig form og faktisk hurtigere end forventet.Det har været fedt at se gutterne spille en gang flot fodbold.\"\r\n\r\nHoldets næste opgaver er træningskamp lørdag kl. 11:00 hjemme mod Hvidovres reserver.Efter den venter første tuneringskamp mod GVI og derefter første kamp i U21A-tuneringen, hvor drengene skal en tur til Fremad Amager.";

        private void OnShareTapped()
        {
            if (!CrossShare.IsSupported)
                return;

            CrossShare.Current.Share(new ShareMessage
            {
                Url = "http://www.bkfrem.dk/default.asp?vis=nyheder&id=4459"
            });
        }

        public NewsPageVM()
        {
            ShareCommand = new Command(OnShareTapped);
        }

       
    }
}
