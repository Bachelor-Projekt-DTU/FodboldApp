using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FodboldApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            // Sætter data i listviewet

            ObservableCollection<Clubs> clubsCollection = new ObservableCollection<Clubs>();

                clubList.ItemsSource = clubsCollection;

                clubsCollection.Add(new Clubs { ClubName = "BK Frem" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 2" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 3" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 4" });
                clubsCollection.Add(new Clubs { ClubName = "Klub 5" });
            


            // Sætter farven til linjen mellem items i listviewt
            clubList.SeparatorColor = Color.Black;

            /* Listviewet skal reduceres, da der ellers vil være et tomt rum i listviewet. 
            Listviewet indeholder et gridview som skabelon, og det har to 2 rækker. Det indeholder et billede.
            Dvs. højden, er typisk, af et item i listviewet er det samme som højden af billedet. 
            For at få listviewt til at tilpasse sig siger vi: HeightRequest = (#items * højden af et item) +(Standard højden + #items)*/

            clubList.HeightRequest = (5 * clubList.RowHeight) + (10 * 22.5);
        }
	}
}
