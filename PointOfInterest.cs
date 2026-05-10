using System;

namespace CITYDRIVE_MANAGER.PointOfInterest_Folder
{
    public class PointOfInterest
    {
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public string? Name { get; set; }

        public PointOfInterest() { }

        public PointOfInterest(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string GetGoogleMapsUrl()
        {
            return "https://www.google.com/maps?q=" + this.Latitude + "," + this.Longitude;
        }

        public override string ToString()
        {
            return (this.Name ?? "Unknown") + " (Lat=" + this.Latitude + ", Long=" + this.Longitude + ")";
        }

        public double GetDistance(PointOfInterest other)
        {
            return GetDistanceBetween(this, other);
        }

        public static double GetDistanceBetween(PointOfInterest p1, PointOfInterest p2)
        {
            Double lat1 = p1.Latitude;
            Double lon1 = p1.Longitude;
            Double lat2 = p2.Latitude;
            Double lon2 = p2.Longitude;

            // Distance euclidienne simplifiée
            double latDiff = lat2 - lat1;
            double lonDiff = lon2 - lon1;
            double distance = Math.Sqrt((latDiff * latDiff) + (lonDiff * lonDiff));
            
            return Math.Round(distance, 2);
        }
    }
}