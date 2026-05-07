using System;

namespace CITYDRIVE_MANAGER.PointOfInterest
{
    public class PointOfInterest
    {
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public String Name { get; set; }

        public string GetGoogleMapsUrl()
        {
            return "https://www.google.com/maps/place/" + this.Name.Replace(' ', '+') + "/@" + this.Latitude + "," + this.Longitude + ",15z/";
        }

        public override string ToString()
        {
            return this.Name + " (Lat=" + this.Latitude + ", Long=" + this.Longitude + ")";
        }

        public static int GetDistance(PointOfInterest one, PointOfInterest other)
        {
            return GetDistanceBetween(one, other);
        }

        private static int GetDistanceBetween(PointOfInterest p1, PointOfInterest p2)
        {
            Double lat1 = p1.Latitude;
            Double lon1 = p1.Longitude;
            Double lat2 = p2.Latitude;
            Double lon2 = p2.Longitude;
            char unit = 'K';

            if ((lat1 == lat2) && (lon1 == lon2)) {
                return 0;
            }
            else {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K') {
                    dist = dist * 1.609344;
                } else if (unit == 'N') {
                    dist = dist * 0.8684;
                }
                return (int)Math.Round(dist);;
            }
        }
    }
}