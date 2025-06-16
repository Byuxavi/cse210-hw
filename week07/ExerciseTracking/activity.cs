using System;

namespace ExerciseTracker
{
    public abstract class Activity
    {
        private string _date;
        private int _lengthInMinutes;

        protected Activity(string date, int lengthInMinutes)
        {
            _date = date;
            _lengthInMinutes = lengthInMinutes;
        }

        protected string Date => _date;
        protected int LengthInMinutes => _lengthInMinutes;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            string activityType = this.GetType().Name;
            double distance = GetDistance();
            double speed = GetSpeed();
            double pace = GetPace();

            return $"{_date} {activityType} ({_lengthInMinutes} min): Distance {distance:F1} km, Speed: {speed:F1} kph, Pace: {pace:F2} min per km";
        }
    }
}