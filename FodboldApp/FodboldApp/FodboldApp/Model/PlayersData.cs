using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    class PlayersData
    {
        public static readonly int ATTRIBUTE_COUNT = 6;
        public string ImageURL { get; set; }
        public string Sponsor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Birthday { get; set; }
        public int Matches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses    { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MVP { get; set; }
        public int Clean_Sheet { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Debut { get; set; }
        public string Former_Clubs { get; set; }
        public string Description { get; set; }

        public static List<PlayersData> Players { get; set; } = new List<PlayersData>();
       
            //    List<PlayersData> players = new List<PlayersData>()
            //{
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/01_marco_brylov.jpg", Name ="A. Bentzon", Position ="Innerwing", Matches = 3, Goals = 2, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/02_mikkel_andersson.jpg", Name ="Aage Albrecht", Position ="Angriber", Matches = 3, Goals = 1, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/03_casper_andersen.jpg", Name ="Aage Rasmussen", Position ="Højre back", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/04_frederik_kragh.jpg", Name ="Adda Djeziri", Position ="Forsvar", Matches = 2, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/05_christian_stokholm.jpg", Name ="Alexander Back", Position ="Forsvar", Matches = 1, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/06_kristian_geertsen.jpg", Name ="Ali Sbeihi", Position ="Angriber", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Name ="Allan Jensen", Position ="Målmand", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/08_hamid_khalidan.jpg", Name ="Anders Bøje", Position ="Midtbane", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/09_daniel_pedersen.jpg", Name ="Anders Sundstrup", Position ="Angriber", Matches = 3, Goals = 0, Assists=0, MVP = 0, Clean_Sheet =0},
            //    new PlayersData() {ImageURL = "http://www.bkfrem.dk/images/spillere/07_andreas_lundberg.jpg", Name="Andreas Theil Lundberg", Sponsor = "Carlsberg", Position = "Forsvar/Midtbane", Height = 187, Weight = 87, Birthday = "22-02-1992", Matches = 107, Wins = 48, Draws = 25, Losses = 34, Goals = 5, Assists=0, MVP = 0, Clean_Sheet = 0, Debut = "3. august 2013 ude mod B 1908 (4-1)", Former_Clubs = "Ungdom: Lyngby og AB (2007-10) Senior: Herlev (2011-F2013 69 kp./7 mål) Kom til Frem i sommeren 2013.", Description = "Fulde navn: Andreas Theil Lundberg Født på Gentofte Hospital. Opvokset i Søborg\n\nAndreas har en HHX uddannelse og er uddannet som finanselev i forsikring og arbejder nu som Erhvervsrådgiver i Tryg.\n\nAndreas mødte Frem som Herlev-spiller (18.8. 2012 1-0 og 22.5.2013 0-1) og synes det virkede som en ambitiøs klub og de spillede den omgang fodbold, han selv gerne vil være med til at spille.\n\nOg så tiltrak den kultur, der er omkring Frem og den altid trofaste opbakning af fans som kommer og støtter, gør bare det er endnu federe og at man yder det mere, når man har Frem trøjen på!\n\nAndreas er en spiller, der altid giver sig 120% på banen i maskinrummet, hvor han erobrer utallige bolde ved sin forudseendehed og nærkampstyrke. Kan måske virke lidt tung set udefra, men har faktisk en rimelig hurtighed. Ligger faktisk med i den gode halvdel af truppen på hurtighed ved diverse test.\n\nNår han har bolden, skiller han sig altid fornuftig af med den og har et godt blik for sine medspillere og når muligheden byder sig, kan han også affyre nogle gode langskud, som har givet et par mål.Bl.a.glemmes hans mål til 1 - 0 ude mod HIK den 24.3.2016 ikke foreløbig.\n\nHar med tiden lært at økonomisere med sine kræfter, så de holder hele kampen.I begyndelsen gik han nogen gange lidt træt i slutningen af kampene, hvilket gav nogle dumme gule kort og et par enkelte udvisninger, som gav nogle dumme karantænedage, men det er meget bedre nu.\n\nRetfærdigvis skal det dog siges, at Andreas trækker nogle gule kort for sine medspillere, som ikke altid er så gode til at komme med tilbage og hvor der er fare for nogle farlige omstillinger til modstanderne.\n\nKan ligeledes benyttes i midterforsvaret, når / hvis behovet opstår.\n\nAndreas har dyrket atletik og svømning som yngre, som flere af Andreas' familiemedlemmer også har dyrket på elite niveau. \n\nBlev kåret som årets spiller 2015 - 6.\n\nSpillede sin kamp nr. 100 for FREM, lørdag den 10.juni 2017 ude mod Jammerbugt FC.\n\nDesværre kom Andreas forkert ind i en tackling i kampen i Valby mod Hvidovre den 2.september 2017 og blev udskiftet i det 53.minut.Det viste sig han havde fået revet både forreste korsbånd og inderste ledbånd over i højre knæ, hvilket sandsynligvis kræver mindst 1 års genoptræning.\n\nVi ønsker Andreas held og lykke og håber snart at se ham på banen igen." }
            //};
               
        public static int Attributes => Attributes2;

        public static int Attributes1 => Attributes2;

        public static int Attributes2 => ATTRIBUTE_COUNT;
    }
}
