﻿using FodboldApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.BoxDesigns
{
    class PlayerDescriptionDesign
    {
        string ImageURL { get; set; }
        string Name { get; set; }
        string Sponsor { get; set; }
        string Position { get; set; }
        string Height { get; set; }
        string Weight { get; set; }
        string Birthday { get; set; }
        string Matches { get; set; }
        string Wins { get; set; }
        string Draws { get; set; }
        string Losses { get; set; }
        string Goals { get; set; }
        string Debut { get; set; }
        string FormerClubs { get; set; }
        string Description { get; set; }

        public static List<string> GetDesign(PlayersData player)
        {

            List<string> playerDescription = new List<string>()
            {
                player.ImageURL,
                player.Name,
                "Trøjeponsor: " + player.Sponsor,
                "Postion: " + player.Posistion,
                "Højde: " + player.Height,
                "Vægt: " + player.Weight,
                "Fødselsdato: " + player.Birthday,
                "Kampe: " + player.Matches,
                "Vundne: " + player.Wins,
                "Uafgjort: " + player.Draws,
                "Tabte: " + player.Losses,
                "Mål: " + player.Goals,
                "Debut: " + player.Debut,
                "Tidligere klubber: " + player.Former_Clubs,
                player.Description,
            };
            return playerDescription;
        }
    }
}
