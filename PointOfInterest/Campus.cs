using System;

namespace CITYDRIVE_MANAGER
{
    public class Campus : PointOfInterest
    {
        public int Capacity { get; set; }

        public override string ToString()
        {
            return this.Name + " is a campus with a capacity of " + this.Capacity + " students";
        }
    }
}