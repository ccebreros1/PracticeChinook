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
    //point to the sql table that this file maps
    [Table("Tracks")]
    public class Track
    {
        //Key notations is optional if the sql pkey
        //ends in ID or Id
        //required if default of entity is NOT Identity
        //required if pkey is compound

        //properties can be fully implemented or
        //auto implemented
        //property names should use sql attribute name
        //properties should be listed in the same order
        //     as sql table attributes for easy of maintenance

        //Entity validation
        //This is validation that kicks im when the
        //.SaveChange() command is executed
        //[Required(ErrorMessage="Bad error message")]
        //[StringLength(int maximum[, int minimum], ErrorMessage="BAD GUY")] ([] means optional in [, int minimum])
        //[Range(double minimum, double maximum, ErrorMessage="Bad one")]
        //[RegularExplression("expression", ErrorMessage="Hey you!")]
        [Key]
        public int TrackId { get; set; }
        [Required(ErrorMessage = "Name is required field")]
        [StringLength(maximumLength:200, ErrorMessage = "Long name man!")]
        public string Name { get; set; }
        [Range(minimum: 1.0, maximum: double.MaxValue, ErrorMessage = "Invalid Album, try selection again")]
        public int? AlbumId { get; set; }
        [Required(ErrorMessage = "Media type selection is required field")]
        [Range(minimum: 1.0, maximum: double.MaxValue, ErrorMessage = "Invalid Album, try selection again")]
        public int MediaTypeId { get; set; }
        [Range(minimum: 1.0, maximum: double.MaxValue, ErrorMessage = "Invalid Genre, try selection again")]
        public int? GenreId { get; set; }
        [StringLength(maximumLength: 120, ErrorMessage = "Composer name is too long")]
        public string Composer { get; set; }
        [Required(ErrorMessage = "Milliseconds is a required field")]
        [Range(minimum: 1.0, maximum: double.MaxValue, ErrorMessage = "Invalid Msec, greater than 1 is the right value")]
        public int Milliseconds { get; set; }
        [Range(minimum: 1.0, maximum: double.MaxValue, ErrorMessage = "Invalid Bytes, greater than 1 is the right value")]
        public int? Bytes { get; set; }
        [Required(ErrorMessage = "Price is a required field")]
        [Range(minimum: 0.0, maximum: double.MaxValue, ErrorMessage = "Invalid Price, greater than 0 is the right value")]
        public decimal UnitPrice { get; set; }

        //navigation properties for use by Linq
        //these properties will be of type vitural
        //there are two types of navigation properties
        //properties that point to "children" use ICollection<T>
        //properties that point to "Parent" use ParentName as the datatype
        public virtual MediaType MediaType { get; set; }
        public virtual Album Album { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        //Tracks may be on one or more PlayList. Each PlayList has one or more Tracks
        //this many to many relationship was normalized using a table called PlaylistTracks
        //We can simplify our model by using navigation properties to directly
        //    represent our many-to-many relationship and thereby omit having to
        //    create a PlaylistTrack entity
        //The navigation property set would be as  "children" 

        //Modeling of this relationship will be done in the context class
        public virtual ICollection<PlayList> PlayLists { get; set; }
    }
}