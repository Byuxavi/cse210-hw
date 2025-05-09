using System; // Importamos la librería básica de C#

class Program
{
    static void Main(string[] args)
    {
        // Llamamos a la función que muestra el mensaje de bienvenida
        DisplayWelcomeMessage();

        // Llamamos a la función que pide el nombre al usuario y guardamos el resultado
        string userName = PromptUserName();

        // Llamamos a la función que pide el número favorito al usuario y guardamos el resultado
        int userNumber = PromptUserNumber();

        // Llamamos a la función que calcula el cuadrado del número y guardamos el resultado
        int squaredNumber = SquareNumber(userNumber);

        // Llamamos a la función que muestra el resultado final al usuario
        DisplayResult(userName, squaredNumber);
    }

    // Función que muestra un mensaje de bienvenida
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!"); // Muestra el mensaje
    }

    // Función que pide el nombre al usuario y devuelve ese nombre como string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: "); // Pide al usuario que ingrese su nombre
        string name = Console.ReadLine(); // Lee la respuesta del usuario
        return name; // Devuelve el nombre
    }

    // Función que pide al usuario su número favorito y devuelve ese número como entero
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: "); // Pide al usuario su número favorito
        int number = int.Parse(Console.ReadLine()); // Lee la respuesta y la convierte a entero
        return number; // Devuelve el número
    }

    // Función que recibe un número entero y devuelve su cuadrado
    static int SquareNumber(int number)
    {
        int square = number * number; // Calcula el cuadrado del número
        return square; // Devuelve el cuadrado
    }

    // Función que recibe el nombre del usuario y el número al cuadrado, y muestra el mensaje final
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}"); // Muestra el mensaje
    }
}
