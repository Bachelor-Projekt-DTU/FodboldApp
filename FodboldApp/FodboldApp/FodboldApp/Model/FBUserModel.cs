using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.Model
{
    public class FBUserModel
    {
        public string Name { get; set; }
        public Picture Picture { get; set; }
        public string PictureURL { get; set; }
        public string Id { get; set; }
        public string AccessToken { get; set; }
    }

    //classes to unwrap picture json from facebook to access URL 
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
