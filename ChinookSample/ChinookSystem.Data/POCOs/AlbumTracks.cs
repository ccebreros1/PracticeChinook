using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//No annotations since this is not an entity

namespace ChinookSystem.Data.POCOs
{
    public class AlbumTracks
    {
        public string Title { get; set; }
        public int TotalTracksforAlbum { get; set; }
        public double TotalPriceForAlbumTrack { get; set; }
        public double AverageTrackLenghtA { get; set; }
        public double AverageTrackLenghtB { get; set; }

    }
}
