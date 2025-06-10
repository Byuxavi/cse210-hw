using System;
using System.Collections.Generic;
using System.IO;

// Creativity and Exceeding Requirements:
// 1. Added level system that increases with score (every 1000 points = new level)
// 2. Added point multiplier based on level (10% bonus per level above 1)

namespace EternalQuest
{
    public class Program
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _score = 0;

        public static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 6)
            {
                DisplayPlayerInfo();
                choice = DisplayMenu();
                switch (choice)
                {
                    case 1: CreateGoal(); break;
                    case 2: ListGoals(); break;
                    case 3: SaveGoals(); break;
                    case 4: LoadGoals(); break;
                    case 5: RecordEvent(); break;
                    case 6: Console.WriteLine("Goodbye!"); break;
                }
            }
        }

        static void DisplayPlayerInfo()
        {
            int level = (_score / 1000) + 1;
            Console.WriteLine($"\nLevel: {level}, Score: {_score} points\n");
        }

        static int DisplayMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            Console.Write("Select a choice from the menu: ");
            return int.Parse(Console.ReadLine());
        }

        static void CreateGoal()
        {
            Console.WriteLine("\nThe types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            int goalType = int.Parse(Console.ReadLine());

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (goalType)
            {
                case 1: _goals.Add(new SimpleGoal(name, description, points)); break;
                case 2: _goals.Add(new EternalGoal(name, description, points)); break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
            }
        }

        static void ListGoals()
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        static void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                    outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        static void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();
            if (!File.Exists(filename)) return;

            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                string goalType = parts[0].Split(':')[0];

                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                        break;
                }
            }
        }

        static void RecordEvent()
        {
            ListGoals();
            Console.Write("Which goal did you accomplish? ");
            int listIndex = int.Parse(Console.ReadLine()) - 1;

            Goal goal = _goals[listIndex];
            goal.RecordEvent();
            
            int level = (_score / 1000) + 1;
            double multiplier = 1.0 + (level - 1) * 0.1;
            int pointsEarned = (int)(goal.GetPoints() * multiplier);
            
            int oldScore = _score;
            _score += pointsEarned;
            
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");

            
            if (oldScore < 1000 && _score >= 1000) Console.WriteLine("🎉 Achievement: First Thousand!");
            if (oldScore < 5000 && _score >= 5000) Console.WriteLine("🎉 Achievement: High Achiever!");
            
            if (goal.IsComplete())
                Console.WriteLine($"🎉 Goal '{goal.GetName()}' completed! Well done! 🎉");
        }
    }
}