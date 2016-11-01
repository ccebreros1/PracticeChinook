using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additonal Namespaces
using System.ComponentModel; //ODS
using ChinookSystem.Data.Entities;
using ChinookSystem.Data.POCOs;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Track> ListTracks()
        {
            using (var context = new ChinookContext())
            {
                //Return all records and attributes
                return context.Tracks.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Track GetTrack(int TrackId)
        {
            using (var context = new ChinookContext())
            {
                //Return a record and attributes of it
                return context.Tracks.Find(TrackId);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void AddTrack(Track trackInfo)
        {
            using (var context = new ChinookContext())
            {
                //any business rules that may prevent you for doing an add
                if(trackInfo.UnitPrice > 1.0m)
                {
                    throw new Exception("I am your father");
                }
                //Any data refinements
                //review of iif
                //composer can be a null string
                //We do not wish to store an empty string
                trackInfo.Composer = string.IsNullOrEmpty(trackInfo.Composer) ?
                                       null : trackInfo.Composer;

                //add the instance of track info to the Database
                context.Tracks.Add(trackInfo);

                //Commit of the add
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public void UpdateTrack(Track trackInfo)
        {
            using (var context = new ChinookContext())
            {
                //any business rules that may prevent you for doing an update

                //Any data refinements
                //review of iif
                //composer can be a null string
                //We do not wish to store an empty string
                trackInfo.Composer = string.IsNullOrEmpty(trackInfo.Composer) ?
                                       null : trackInfo.Composer;

                //update the existing instance of track info to the Database
                context.Entry(trackInfo).State = System.Data.Entity.EntityState.Modified;

                //Commit update
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteTrack(Track trackInfo)
        {
            DeleteTrack(trackInfo.TrackId);
        }

        public void DeleteTrack(int trackId)
        {
            using (var context = new ChinookContext())
            {
                //Any business rules

                //Do the delete
                //Find the existent record on the Database
                var existing = context.Tracks.Find(trackId);
                //delete the record from the database
                context.Tracks.Remove(existing);
                //Commit update
                context.SaveChanges();
            }
        }
    }
}