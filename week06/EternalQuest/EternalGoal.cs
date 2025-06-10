namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _timesCompleted;

        public EternalGoal(string name, string description, int points) : base(name, description, points) { }
        public EternalGoal(string name, string description, int points, int timesCompleted) : base(name, description, points) { _timesCompleted = timesCompleted; }

        public override void RecordEvent() { _timesCompleted++; }
        public override bool IsComplete() { return false; }
        public override string GetDetailsString() { return $"[ ] {_shortName} ({_description}) - Completed {_timesCompleted} times"; }
        public override string GetStringRepresentation() { return $"EternalGoal:{_shortName},{_description},{_points},{_timesCompleted}"; }
    }
}