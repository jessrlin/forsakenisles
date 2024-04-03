using System;
using System.Threading;

class Program
{
    static string beachArt = @"
    _.====.._
         ,:._        ~-_
             `\ welcome ~-_
               |  to the    `.
             ,/ forsaken isles ~-_
    -..__..-''                   ~~--..__...----...

";

static void GameOver(){
    
    Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⡀⠀");
    Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣤⠀⠀⠀⢀⣴⣿⡶⠀⣾⣿⣿⡿⠟⠛⠁");
    Console.WriteLine("⠀⠀⠀⠀⠀⠀⣀⣀⣄⣀⠀⠀⠀⠀⣶⣶⣦⠀⠀⠀⠀⣼⣿⣿⡇⠀⣠⣿⣿⣿⠇⣸⣿⣿⣧⣤⠀⠀⠀");
    Console.WriteLine("⠀⠀⢀⣴⣾⣿⡿⠿⠿⠿⠇⠀⠀⣸⣿⣿⣿⡆⠀⠀⢰⣿⣿⣿⣷⣼⣿⣿⣿⡿⢀⣿⣿⡿⠟⠛⠁⠀⠀");
    Console.WriteLine("⠀⣴⣿⡿⠋⠁⠀⠀⠀⠀⠀⠀⢠⣿⣿⣹⣿⣿⣿⣿⣿⣿⡏⢻⣿⣿⢿⣿⣿⠃⣼⣿⣯⣤⣴⣶⣿⡤⠀");
    Console.WriteLine("⣼⣿⠏⠀⣀⣠⣤⣶⣾⣷⠄⣰⣿⣿⡿⠿⠻⣿⣯⣸⣿⡿⠀⠀⠀⠁⣾⣿⡏⢠⣿⣿⠿⠛⠋⠉⠀⠀⠀");
    Console.WriteLine("⣿⣿⠲⢿⣿⣿⣿⣿⡿⠋⢰⣿⣿⠋⠀⠀⠀⢻⣿⣿⣿⠇⠀⠀⠀⠀⠙⠛⠀⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀");
    Console.WriteLine("⠹⢿⣷⣶⣿⣿⠿⠋⠀⠀⠈⠙⠃⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
    Console.WriteLine("⠀⠀⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣴⣶⣦⣤⡀⠀");
    Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⣠⡇⢰⣶⣶⣾⡿⠷⣿⣿⣿⡟⠛⣉⣿⣿⣿⠆");
    Console.WriteLine("⠀⠀⠀⠀⠀⠀⢀⣤⣶⣿⣿⡎⣿⣿⣦⠀⠀⠀⢀⣤⣾⠟⢀⣿⣿⡟⣁⠀⠀⣸⣿⣿⣤⣾⣿⡿⠛⠁⠀");
    Console.WriteLine("⠀⠀⠀⠀⣠⣾⣿⡿⠛⠉⢿⣦⠘⣿⣿⡆⠀⢠⣾⣿⠋⠀⣼⣿⣿⣿⠿⠷⢠⣿⣿⣿⠿⢻⣿⣧⠀⠀⠀");
    Console.WriteLine("⠀⠀⠀⣴⣿⣿⠋⠀⠀⠀⢸⣿⣇⢹⣿⣷⣰⣿⣿⠃⠀⢠⣿⣿⢃⣀⣤⣤⣾⣿⡟⠀⠀⠀⢻⣿⣆⠀⠀");
    Console.WriteLine("⠀⠀⠀⣿⣿⡇⠀⠀⢀⣴⣿⣿⡟⠀⣿⣿⣿⣿⠃⠀⠀⣾⣿⣿⡿⠿⠛⢛⣿⡟⠀⠀⠀⠀⠀⠻⠿⠀⠀");
    Console.WriteLine("⠀⠀⠀⠹⣿⣿⣶⣾⣿⣿⣿⠟⠁⠀⠸⢿⣿⠇⠀⠀⠀⠛⠛⠁⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀");
    Console.WriteLine("⠀⠀⠀⠀⠈⠙⠛⠛⠛⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
}


    static bool AgeVerification()
    {
    Console.WriteLine("You must be 10 years old to play this game.");
    Thread.Sleep(1000);
    Console.WriteLine("What is your age?");

    if (int.TryParse(Console.ReadLine(), out int age)) //integer and ignore past inputs, internet help
    {
        if (age >= 10) // if age is equal to or older than 10, continute
        {
            Console.WriteLine("You are old enough to play. Enjoy your adventure!");
            return true;
        }
        else // if the integer is less than 10, end game
        {
            Console.WriteLine("You are not old enough to play this game.");
            Thread.Sleep (2000);
            Console.Clear();
            return false;
        }
    }
    else // if user doesnt input a integery
    {
        Console.WriteLine("Invalid age entered. Please enter a valid age.");
        return false; //figure outhowto re ask age
    }
} // End age verificaition

static void ProtagonistAwakening()
    {
        Console.WriteLine(beachArt);// display ascii
        Console.WriteLine("The sound of waves crashing against the shore fills the air.");
        Thread.Sleep(1000); //2 seconds til the line will be displayed
        Console.WriteLine("You wake up on the sandy shores of the forsaken isles");
        Thread.Sleep(1000); //2 seconds til the line will be displayed
        Console.WriteLine("Your adventure begins. You find a map and some food in your backpack.\n");// new line before viewing inventory
        Thread.Sleep(1000);
    } // end Protagontist awakening

 static void CheckInventory(string[] items, int[] quantities) //advanced technique 1
    {
        Console.WriteLine("⋅.˳˳.⋅ॱ˙˙ॱ⋅.˳Inventory⋅.˳˳.⋅ॱ˙˙ॱ⋅.˳");
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{items[i]}: {quantities[i]}");
        }
        Console.WriteLine("⋅.˳˳.⋅ॱ˙˙ॱ⋅.˳˳.⋅ॱ˙˙ॱᐧ.˳˳.⋅ॱ˙˙ॱ⋅.˳˳.⋅ॱ˙\n");
    }


    static void Main()
    {
       bool isOldEnough = AgeVerification();

        if (isOldEnough){
        Thread.Sleep(2000);
        ProtagonistAwakening();
        Thread.Sleep(2000);

        string[] items = { "food", "water", "map", "mystical herb" };
        int[] quantities = { 3, 2, 1, 0 };

        // Check and display the initial inventory
        CheckInventory(items, quantities);

      }
        
     else {
        Thread.Sleep(2000);
        GameOver();

     }
        
    
    
    } // static main
} // end class program
