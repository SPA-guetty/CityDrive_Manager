using System;

namespace CITYDRIVE_MANAGER
{
    public class Trip
    {
        public Vehicles.Vehicle Vehicle { get; set; }
        const double AVERAGE_SPEED = 50;
        public CITYDRIVE_MANAGER.PointOfInterest_Folder.PointOfInterest Start { get; set; }
        public CITYDRIVE_MANAGER.PointOfInterest_Folder.PointOfInterest Destination { get; set; }
        public DateTime Starttime { get; set; }

        public double GetDistance() 
        {
            return CITYDRIVE_MANAGER.PointOfInterest_Folder.PointOfInterest.GetDistanceBetween(Start, Destination);
        }

        public double GetDurationInMinutes()
        {
            return (GetDistance() / AVERAGE_SPEED) * 60;
        }

        public static double DifferenceInMinutes(DateTime start, DateTime end)
        {
            if (start > end)
            {
                DateTime temp = start;
                start = end;
                end = temp;
            }
            double minutes = 0;

            while (start.Minute != end.Minute)
            {
                start = start.AddMinutes(1);
                minutes += 1;
            }

            while (start.Hour != end.Hour)
            {
                start = start.AddHours(1);
                minutes += 60;
            }

            while (start < end)
            {
                start = start.AddDays(1);
                minutes += 60*24;
            }

            return minutes;
        }

        public static string DisplayDateWithoutTime(DateTime date)
        {
            int day = date.Day;
            string strday = day.ToString();
            if (day < 10) {strday = "0"+strday;}

            int month = date.Month;
            string strmonth = month.ToString();
            if (month < 10) {strmonth = "0"+strmonth;}

            int year = date.Year;
            string stryear = year.ToString();
            if (year < 10) {stryear = "0"+stryear;}
            if (year < 100) {stryear = "0"+stryear;}
            if (year < 1000) {stryear = "0"+stryear;}

            return strday + "/" + strmonth + "/" + stryear;
        }

        public static DateTime FromStringToDateTime(string dateStr)
        {
            return DateTime.ParseExact(dateStr, "dd/MM/yyyy HH:mm", null);
        }

        public override string ToString()
        {
            string tripstring = "";
            tripstring += "Véhicule : " + this.Vehicle.Brand + "\n";
            tripstring += "Départ : " + this.Start.Name + "\n";
            tripstring += "Arrivée : " + this.Destination.Name + "\n";
            tripstring += "Distance : " + GetDistance() + "\n";
            tripstring += "Durée estimée : " + GetDurationInMinutes() + " minutes" + "\n";
            tripstring += "Départ prévu le : " + DisplayDateWithoutTime(this.Starttime) + "\n";

            return tripstring;
        }
    }
}