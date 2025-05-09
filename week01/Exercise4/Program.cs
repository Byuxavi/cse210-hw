using System; // Importamos la librería básica de C#
using System.Collections.Generic; // Importamos la librería para poder usar Listas

class Program
{
    static void Main(string[] args)
    {
        // Creamos una nueva lista vacía de enteros para guardar los números que el usuario ingrese
        List<int> numbers = new List<int>();
        
        int userNumber = -1; // Inicializamos la variable con -1 (un número distinto de 0)

        // Pedimos números al usuario hasta que escriba 0
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): "); // Mensaje para el usuario
            string userResponse = Console.ReadLine(); // Leemos la respuesta (como texto)
            userNumber = int.Parse(userResponse); // Convertimos el texto a número entero

            // Si el número ingresado NO es 0, lo agregamos a la lista
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // ---------- Parte 1: Calcular la suma de todos los números ----------
        int sum = 0; // Variable para acumular la suma

        // Recorremos la lista y sumamos todos los números
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}"); // Mostramos la suma

        // ---------- Parte 2: Calcular el promedio ----------
        // Hacemos la conversión a float para que la división sea decimal
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}"); // Mostramos el promedio

        // ---------- Parte 3: Encontrar el número más grande ----------
        // Suponemos que el primer número es el mayor
        int max = numbers[0];

        // Recorremos la lista para encontrar el número más grande
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number; // Si encontramos uno mayor, actualizamos el máximo
            }
        }

        Console.WriteLine($"The largest number is: {max}"); // Mostramos el número más grande

        // ---------- Reto adicional 1: Encontrar el número positivo más pequeño ----------
        int smallestPositive = int.MaxValue; // Empezamos con el mayor valor posible
        bool foundPositive = false; // Bandera para verificar si encontramos al menos un número positivo

        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number; // Actualizamos si encontramos un positivo más pequeño
                foundPositive = true; // Indicamos que encontramos un número positivo
            }
        }

        // Mostramos el resultado solo si encontramos un número positivo
        if (foundPositive)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        // ---------- Reto adicional 2: Ordenar la lista y mostrarla ----------
        numbers.Sort(); // Ordenamos la lista de menor a mayor
        Console.WriteLine("The sorted list is:");

        // Mostramos cada número ordenado
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
