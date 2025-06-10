namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points) { _target = target; _bonus = bonus; }
        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points) { _target = target; _bonus = bonus; _amountCompleted = amountCompleted; }

        public override void RecordEvent() { if (_amountCompleted < _target) _amountCompleted++; }
        public override bool IsComplete() { return _amountCompleted >= _target; }
        public override int GetPoints() { return _amountCompleted == _target ? _points + _bonus : _points; }
        public override string GetDetailsString() { return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target} times"; }
        public override string GetStringRepresentation() { return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}"; }
    }
}