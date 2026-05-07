using System;

namespace CITYDRIVE_MANAGER.PointOfInterest_Folder
{
    public class HistoricalMonument : PointOfInterest
    {
        public int BuildYear { get; set; }

        public HistoricalMonument(){}

        public HistoricalMonument(string name, double latitude, double longitude, int buildYear)
            : base(name, latitude, longitude)
        {
            BuildYear = buildYear;
        }

        public override string ToString()
        {
            return this.Name + " is a historical monument built in " + this.BuildYear.ToString();
        }
    }
}