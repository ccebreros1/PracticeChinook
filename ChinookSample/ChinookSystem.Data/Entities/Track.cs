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

    [Table("Tracks")]
    public class Track
    {
        //Key notation is optional if the SQL PKey ends in ID or Id
        //Required if default of entity is NOT Identity
        //Required if PKey is compound
        [Key]
        //Properties can be fully implemented or
        //Auto implemented
        //Properties should be listed in the same order as SQL table attributes for ease of maintainance 
        public int TrackId { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string Composer { get; set; }
        public int Miliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        //Navigation properties for use by Linq
        //These properties will be of type virtual
        //Properties that point to "children" use ICollection<T>
        //Properties that point to "parent" use ParentName as the Datatype
        public virtual Album Albums { get; set; }
        public virtual MediaType MediaTypes { get; set; }
    }
}
