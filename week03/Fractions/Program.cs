using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // CREATIVITY AND EXCEEDING REQUIREMENTS:
            // 1. Random scripture selection - User can choose a random scripture from the library
            // 2. Progress tracking - Shows how many words are still visible
            // 3. Smart word hiding - Avoids hiding the same word twice (stretch challenge)
        
            
            Console.WriteLine("Welcome to Book of Mormon Scripture Memorizer!");
            Console.WriteLine("==============================================");
            
        
            Scripture[] scriptureLibrary = {
                new Scripture(new Reference("1 Nephi", 3, 7), 
                    "And it came to pass that I spake unto my brethren, saying: The Lord hath commanded me, and I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
                new Scripture(new Reference("2 Nephi", 2, 25), 
                    "Adam fell that men might be; and men are, that they might have joy."),
                new Scripture(new Reference("2 Nephi", 32, 3), 
                    "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do."),
                new Scripture(new Reference("Mosiah", 2, 17), 
                    "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."),
                new Scripture(new Reference("Alma", 32, 21), 
                    "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."),
                new Scripture(new Reference("Helaman", 5, 12), 
                    "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation."),
                new Scripture(new Reference("3 Nephi", 11, 10, 11), 
                    "Behold, I am Jesus Christ, whom the prophets testified shall come into the world. And behold, I am the light and the life of the world; and I have drunk out of that bitter cup which the Father hath given me."),
                new Scripture(new Reference("Moroni", 10, 4, 5), 
                    "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things.")
            };
            
            // Let user choose a scripture
            Console.WriteLine("Choose your scripture:");
            for (int i = 0; i < scriptureLibrary.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptureLibrary[i].GetReference()}");
            }
            Console.WriteLine($"{scriptureLibrary.Length + 1}. Random scripture");
            Console.Write("Enter your choice (1-" + (scriptureLibrary.Length + 1) + "): ");
            
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > scriptureLibrary.Length + 1)
            {
                choice = scriptureLibrary.Length + 1; 
            }
            
            Scripture selectedScripture;
            if (choice == scriptureLibrary.Length + 1)
            {
                Random random = new Random();
                selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Length)];
                Console.WriteLine("Random scripture selected!");
            }
            else
            {
                selectedScripture = scriptureLibrary[choice - 1];
            }
            
            // Main memorization loop
            string userInput = "";
            
            while (userInput.ToLower() != "quit" && !selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("Scripture Memorizer");
                Console.WriteLine("===================");
                Console.WriteLine();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine();
                
                // Show progress
                int visibleWords = selectedScripture.GetVisibleWordCount();
                int totalWords = selectedScripture.GetTotalWordCount();
                Console.WriteLine($"Progress: {totalWords - visibleWords}/{totalWords} words hidden");
                Console.WriteLine();
                
                if (!selectedScripture.IsCompletelyHidden())
                {
                    Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
                    userInput = Console.ReadLine();
                    
                    if (userInput.ToLower() != "quit")
                    {
                        selectedScripture.HideRandomWords(3); // Hide 3 words at a time
                    }
                }
            }
            
            // Final display
            Console.Clear();
            Console.WriteLine("Scripture Memorizer - Complete!");
            Console.WriteLine("===============================");
            Console.WriteLine();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            
            if (selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have successfully hidden all words in the scripture.");
                Console.WriteLine("Practice reciting it from memory!");
            }
            else
            {
                Console.WriteLine("Thanks for using Scripture Memorizer!");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}