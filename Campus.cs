using System;

namespace CITYDRIVE_MANAGER.PointOfInterest_Folder
{
    public class Campus : PointOfInterest
    {
        public int Capacity { get; set; }

        public override string ToString()
        {
            return (this.Name ?? "Unknown") + "\nCoordonnées : (Lat=" + this.Latitude + ", Long=" + this.Longitude + ")\n" + "Capacité du campus : " + this.Capacity + " étudiants\n" + "Google Maps : " + GetGoogleMapsUrl();
        }
    }
}