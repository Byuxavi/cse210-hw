using System;  // Necesario para usar Console y Random

class Program
{
    static void Main(string[] args)
    {
        // Crea un generador de números aleatorios
        Random randomGenerator = new Random();

        // Genera un número aleatorio entre 1 y 100
        int magicNumber = randomGenerator.Next(1, 101);

        // Inicializa la variable guess (adivinanza) con -1 (un número imposible)
        int guess = -1;

        // Bucle: sigue mientras guess no sea igual al número mágico
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());  // lee y convierte a entero

            // Si el número es mayor que la adivinanza
            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            // Si el número es menor que la adivinanza
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            // Si adivinó
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
