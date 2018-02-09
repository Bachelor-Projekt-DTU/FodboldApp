using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class UserModel
    {

        public string Name { get; set; }
        public Picture Picture { get; set; }
        public string Link { get; set; }       
        public string Id { get; set; }
    }

    public class Picture
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public bool IsSilhouette { get; set; }
        public string Url { get; set; }
    }
}   