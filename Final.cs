using System;
using System.Globalization;
using System.Threading; // allow for program to wait before compokleted next action called

class Program
{
    // ASCII art representing the beach where the protagonist wakes up - AI
static string BeachArt = @"
    _.====.._
         ,:._       ~-_
             `\        ~-_
               | welcome  `.
             ,/    to the   ~-_
    -..__..-'' forsaken isles     ~~--..__...----...
";
static string ScollArt = @"
        _______________
   ()==(   Objective  (@==()
        '--------------'|
          |    find     |
          |  supplies   |
          | to get off  |
          | the island  |
        __)_____________|
   ()==(               (@==()
        '--------------'";
static string WildBoar = @"
           __,---.__
        ,-'         `-.__
      &/           `._\ _\
      /               ''._
      |   ,             ("")
      |__,'`-..--|__|--''";


static int WaitTime = 1000;
// dervived varibles are created from value of 1000, E
    
static int currentFoodQuantity = 3; // Variable to track current food quantity

    static void UpdateFoodQuantity(int change)
    {
        currentFoodQuantity += change;
    }

static int currentWoodQuantity = 0; // Variable to track current food quantity

    static void UpdateWoodQuantity(int change)
    {
        currentFoodQuantity += change;
    }


    const int InitialWaterQuantity = 2;
    const int InitialMapQuantity = 1;


static bool AgeVerification()
{
    Console.WriteLine("You must be 10 years old to play this game.");
    Thread.Sleep(WaitTime);

    while (true)
    {
        Console.WriteLine("What is your age?");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int age))
        {
            if (age >= 10)
            {
                Console.WriteLine("You are old enough to play. Enjoy your adventure!");
                return true;
            }
            else
            {
                Console.WriteLine("You are not old enough to play this game.");
                GameOver();
                return false;
            }
        }
        else
        {
            Console.WriteLine("Invalid age entered. Please enter a valid age.");
        }
    }
}
static void ProtagonistAwakening()//game begins
    {
        
        Console.WriteLine(BeachArt);//display the ascii art
        Thread.Sleep(WaitTime); // wait 1 second
        Console.WriteLine("You wake up on the sandy shores of the forsaken isles.");
        Thread.Sleep(WaitTime);
        Console.WriteLine("The sound of waves crashing against the shore fills the dark air.");
        Thread.Sleep(WaitTime);
        Console.WriteLine("Your adventure begins.\n");
        Thread.Sleep(WaitTime*2);

    } // end Protagontist awakening
static void StoryContinue(){
    Console.WriteLine("You see a scroll in the sand and open it");
    Thread.Sleep(WaitTime); // wait 1 second
    Console.WriteLine(ScollArt);
    Thread.Sleep(WaitTime); // wait 1 second
    Console.WriteLine("You must collect enough supplies to make a raft to sail to the next island");
    Thread.Sleep(WaitTime); // wait 1 second
}
static void CheckInventory(string[] inventory)
{
    
    Console.SetCursorPosition(Console.WindowWidth - 20, 0);
        Console.WriteLine("--- Inventory ---");

        int row = 1;
        foreach (string item in inventory)
        {
            Console.SetCursorPosition(Console.WindowWidth - 20, row);
            Console.WriteLine(item);
            row++;
        }

}
static void WildlifeEncounter(string[] inventory)//wild life encounter effect on inventory
{
        
    Console.WriteLine(WildBoar);

        bool validChoice = false;
        while (!validChoice)
        {
            Console.WriteLine("As you explore the surroundings, you encounter a wild boar!");
            Thread.Sleep(WaitTime);
            Console.WriteLine("What will you do?");
            Console.WriteLine("");
            Console.WriteLine("1. Attempt to hunt the boar");
            Console.WriteLine("2. Retreat slowly");

            string choice = Console.ReadLine(); //asking user for their choice
            Console.WriteLine("");

            if (choice == "1") //when they click 1
            {
                Console.WriteLine("You successfully hunt the boar and gain additional food.");
                inventory[0] = $"Food ({currentFoodQuantity + 2})";
                CheckInventory(inventory);
                validChoice = true;
            }
            else if (choice == "2") //when they click 2
            {
                Console.WriteLine("You choose to retreat and avoid confrontation.");
                validChoice = true;
            }
            else //if enter an integer or string not 1 or 2
            {
                Console.WriteLine("Invalid choice. Please enter '1' to hunt or '2' to retreat.");
            }
        }
    }
static void PuzzleTime(string[] inventory)
{
    bool PuzzleChoice = false;
    while (!PuzzleChoice)
    {
        Console.WriteLine("");
        Console.WriteLine("You spot a tribesman and decide to approach him,");
        Thread.Sleep(WaitTime);
        Console.WriteLine("He says, if you play this puzzle, I will give you wood and oars for a boat.");
        Thread.Sleep(WaitTime);
        Console.WriteLine("What will you do?");
        Console.WriteLine("");
        Thread.Sleep(WaitTime);
        Console.WriteLine("1. Play the puzzle");
        Console.WriteLine("2. Go back to your shelter");
        

        string Puzzle = Console.ReadLine(); //asking user for their choice
        Console.WriteLine("");

        if (Puzzle == "1") //when they click 1
        {
            Console.WriteLine("You are invited to play a riddle game:");
            Thread.Sleep(WaitTime);
            PlayRiddleGame(inventory);
            PuzzleChoice = true;
        }
        else if (Puzzle == "2") //when they click 2
        {
            Console.WriteLine("You choose to go back to your shelter and cook dinner.");
            UpdateFoodQuantity(-1); // Reduce food quantity by 1
            inventory[0] = $"Food ({currentFoodQuantity})"; // Update inventory
            CheckInventory(inventory);
            PuzzleChoice = true;

        }
        else //if enter an integer or string not 1 or 2
        {
            Console.WriteLine("Invalid choice. Please enter '1' to play or '2' to go home.");
        }
    }
}
static void PlayRiddleGame(string[] inventory)
{
    string[] riddles = {
        "How many months of the year have 28 days?",
        "The more you take, the more you leave behind. What am I?",
        "What has keys but can't open locks?",
    };

    string[] answers = {
        "12",
        "Footsteps",
        "A piano",
    };

    Random rnd = new Random();
    int index = rnd.Next(0, riddles.Length); // Get a random riddle index

    Console.WriteLine("Here's your riddle:");
    Console.WriteLine(riddles[index]);
    Console.WriteLine("Your answer:");

    string userAnswer = Console.ReadLine();

    if (userAnswer.Equals(answers[index]))
    {
       Console.WriteLine("Correct! You receive wood for a boat as a reward.");
        UpdateWoodQuantity(-1); // Reduce wood quantity by 1
        inventory[3] = $"Wood ({currentWoodQuantity})";

        // Add a new item to the inventory
        string newInventoryItem = "Rope (1)";
        Array.Resize(ref inventory, inventory.Length + 1);
        inventory[inventory.Length - 1] = newInventoryItem;

        // Update inventory display
        CheckInventory(inventory);
        Thread.Sleep(WaitTime*3);
            
    }
    else
    {
        Console.WriteLine("Incorrect! The tribesman shakes his head in disappointment.");
    }
}//end PRG
static bool NeedWaterEvent(string[] inventory)
    {
        Random rnd = new Random();
        int eventChance = rnd.Next(1, 101); // Generate a random number between 1 and 100

        if (eventChance <= 40) // 40% chance of needing more water
        {
            Console.WriteLine("You feel thirsty and realize you need more water!");
            inventory[1] = $"Water ({InitialWaterQuantity -1})";// Reduce water in inventory
            CheckInventory(inventory);
            return true;
        }

        return false;
    }

static void MoreStory(){
    Console.WriteLine("After a long day exploring all the island has to offer, you decide to get some sleep");
    Thread.Sleep(WaitTime); // wait 1 second
    Console.SetCursorPosition(0, 0);
    Console.Clear();
    Console.WriteLine("Welcome to Day 2!");
    Console.WriteLine("Time to collect your items for a boat.");
    Thread.Sleep(WaitTime); // wait 1 second
}


static void GameOver()
{
    
    Thread.Sleep(WaitTime*2);
    Console.SetCursorPosition(0, 0);
    Console.Clear();
    Console.WriteLine("Game Over! Press Space to replay or Backspace to quit.");

    while (true)
    {
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.Spacebar)
        {
            Main(); // Restart the game by calling Main method
            return;
        }
        else if (key == ConsoleKey.Backspace)
        {
            Environment.Exit(0); // Quit the game
        }
    }
}


static void Main()
    {

    Console.SetCursorPosition(0, 0);
    Console.Clear();

    if (!AgeVerification()) {
        GameOver();
        return;
    } //if the age verification returns flase (not old enought), end game

    Thread.Sleep(WaitTime*3);
    Console.SetCursorPosition(0, 0);
    Console.Clear();
    
    
    //begin to display the game if the age is accepted
    ProtagonistAwakening();
    Thread.Sleep(WaitTime*3);
    Console.SetCursorPosition(0, 0);
    Console.Clear();

    //continue story
    StoryContinue();
    Thread.Sleep(WaitTime*3);
    Console.SetCursorPosition(0, 0);
    Console.Clear();

    //show and display the initial inventory
      string[] inventory = { $"Food ({currentFoodQuantity})", $"Water ({InitialWaterQuantity})", $"Map ({InitialMapQuantity})", $"Wood ({currentWoodQuantity})" };  //array orginal
    CheckInventory(inventory);

    //1st encounter
    Thread.Sleep(WaitTime*2);
    WildlifeEncounter(inventory);
    Thread.Sleep(WaitTime*2);
    Console.SetCursorPosition(0, 0);
    Console.Clear();

    //puzzle with tribes man
    Thread.Sleep(WaitTime*2);
    CheckInventory(inventory);
    PuzzleTime(inventory);
    

     if (NeedWaterEvent(inventory))
        {
            Console.WriteLine("Oh no! You feel thirsty and realize you need more water!");
            inventory[1] = "Water (1)"; // Reduce water in inventory
            CheckInventory(inventory);
        }
        
    
    Thread.Sleep(WaitTime*3);

    MoreStory();

    GameOver();

    } // static main

} // end class program
