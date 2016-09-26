using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace ChinookSystem.Data.Entities
{
    //Set class as public
    //Point to the SQL Table that this file maps

    [Table("Albums")]
    public class Album
    {
        //Key notation is optional if the SQL PKey ends in ID or Id
        //Required if default of entity is NOT Identity
        //Required if PKey is compound
        [Key]
        //Properties can be fully implemented or
        //Auto implemented
        //Properties should be listed in the same order as SQL table attributes for ease of maintainance 
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistsId { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }

        //Navigation properties for use by Linq
        //These properties will be of type virtual
        //Properties that point to "children" use ICollection<T>
        //Properties that point to "parent" use ParentName as the Datatype
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual Artist Artists { get; set; }
    }
}
