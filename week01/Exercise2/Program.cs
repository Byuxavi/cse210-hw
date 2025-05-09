using System; // Necesario para usar Console

class Program
{
    static void Main(string[] args) // punto de entrada del programa
    {
        // 1️⃣ Pedir al usuario el porcentaje
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine(); // leer lo que escribió (es string)
        
        int percent = int.Parse(answer); // convertir string a int

        string letter = ""; // variable donde guardaremos la letra

        // 2️⃣ Decidir la letra con if-else
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // 3️⃣ Mostrar la letra
        Console.WriteLine($"Your grade is: {letter}");
        
        // 4️⃣ Decir si aprobó o no
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
