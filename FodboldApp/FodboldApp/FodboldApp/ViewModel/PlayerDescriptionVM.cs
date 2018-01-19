using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerDescriptionVM
    {
        public string Number { get; private set; }
        public string ImageURL { get; private set; }
        public string Name { get; private set; }
        public string Sponsor { get; private set; }
        public string Position { get; private set; }
        public string Height { get; private set; }
        public string Weight { get; private set; }
        public string Birthday { get; private set; }
        public string Matches { get; private set; }
        public string Wins { get; private set; }
        public string Draws { get; private set; }
        public string Losses { get; private set; }
        public string Goals { get; private set; }
        public string Debut { get; private set; }
        public string FormerClubs { get; private set; }
        public string Description { get; private set; }
        public int rowIndex = 3;

        public PlayerDescriptionVM()
        {
            setupDescription();
        }

        private void setupDescription()
        {
            Number = "01";
            ImageURL = "http://www.bkfrem.dk/images/spillere/01_marco_brylov.jpg";
            Name = Number + " " + "Marco Brylov";
            Sponsor = "Carlsberg";
            Position = "Målmand";
            Height = "191cm";
            Weight = "92kg";
            Birthday = "21-11-1995";
            Matches = "51 (7)";
            Wins = "19";
            Draws = "14";
            Losses = "18";
            Goals = "0 (0)";
            Debut = "11. august 2015 ude i pokalkampen mod Ledøje-Smørum (4-6 e.str.)";
            FormerClubs = "Ungdom: Hvidovre (fra sit 5. år til 2011) og FREM (2011-14) Senior: SC Egedal (foråret 2015 - 13 kampe) Tilbage til FREM fra efteråret 2015.";
            Description = "Fulde navn: Marco Brylov. Født på Hvidovre Hospital. Opvokset i Hvidovre og har boet der lige siden.\nSom oprykket senior var målmandssituationen yderst hård i FREM med 3 gode målmænd, der på det tidspunkt stod foran Marco.\nDet var meningen, at Marco skulle udlånes til Fremad Valby, men han havnede i SC Egedal isf sammen med Jimmy Mayasi, for at udvikle sig og få noget kamp træning på et fornuftigt niveau.\nTrods god kritik i lokalpressen kunne Marco og hans holdkammerater ikke holde skansen i Danmarksserien og SC Egedal blev opløst som overbygning af Stenløse BK og FC Ølstykke og Marco valgte derfor at vende tilbage til FREM, hvor vejen til 1.holdet i mellemtiden var blevet kortere, da der nu kun var Simon Bloch Jørgensen tilbage, da de 2 andre konkurrenter var henholdsvis holdt op og skiftet klub.\nMarco vendte tilbage til Frem, da han har savnet klubben efter havde spillet der de sidste ungdomsår og som ung senior.";
        }

        public Color GetColor
        {
            get

            {
                return Colorization.ColoringLogic.GetColor(rowIndex++ /3);
            }
        }
    }
}
