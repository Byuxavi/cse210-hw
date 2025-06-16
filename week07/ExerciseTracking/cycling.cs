namespace ExerciseTracker
{
    public class Cycling : Activity
    {
        private double _speedInKph;

        public Cycling(string date, int lengthInMinutes, double speedInKph) 
            : base(date, lengthInMinutes)
        {
            _speedInKph = speedInKph;
        }

        public override double GetDistance()
        {
            return (_speedInKph * LengthInMinutes) / 60;
        }

        public override double GetSpeed()
        {
            return _speedInKph;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            return LengthInMinutes / distance;
        }
    }
}