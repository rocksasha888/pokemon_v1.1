using System;
using System.Threading;

public class HelloWorld
{
    static string[] pokemons = { "Bulbasaur", "Charmander", "Squirtle", "Pikachu", "Jigglypuff", "Meowth", "Psyduck", "Machop", "Geodude", "Slowpoke", "Gastly", "Onix", "Cubone", "Rhyhorn", "Magikarp", "Eevee", "Snorlax", "Dratini", "Mewtwo", "Chikorita" }; //the library that contains the array
    static Random rnd = new Random();
    static string[] pokAsh = new string[5];
    static string[] pokGary = new string[5]; //select a 5 randoms pokemons from array without the 5 before pokemons

    public static void Main(string[] args) //Main function in the script
    {
        pokemons_generator();
        menu();
    }

    static void menu() //Menu function
    {
        int op;
        do
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("       Welcome to the program");
            Console.WriteLine("\n=====================================");
            Console.WriteLine("             2. Search Pokemons");
            Console.WriteLine("=====================================");
            Console.WriteLine("             1. ShowTeams");
            Console.WriteLine("=====================================");
            Console.WriteLine("             0. Refresh");
            Console.WriteLine("=====================================");
            Console.WriteLine("         Select an option\n");
            op = user_op(); //Call a user_op where it checks the answer if it's a correct character or invalid
            Console.Clear();
        } while (op == 0);

        switch (op)
        {
            case 1:
                Console.WriteLine("=====================================");
                Console.WriteLine("              Characters");
                Console.WriteLine("\n=====================================");
                Console.WriteLine("             0. Ash");
                Console.WriteLine("=====================================");
                Console.WriteLine("             1. Gary");
                Console.WriteLine("=====================================");
                Console.WriteLine("         Select a character\n");
                int character_op = user_op(); //Call a user_op where it checks the answer if it's a correct character or invalid
                Console.Clear();
                showteams(character_op); //Send variables to a function
                break;
            case 2:
                Console.Clear();
                string[] newPok = new string[1];
                do
                {
                    LoadScreen();
                    int rand = rnd.Next(1, 100);
                    if (rand <= 25)
                    {
                        for (int k = 0; k < 1; k++)
                        {
                            int rndIndex = rnd.Next(0, pokemons.Length);
                            newPok[k] = pokemons[rndIndex];
                        }

                        Console.WriteLine("=====================================");
                        Console.WriteLine("You search: " + string.Join(", ", newPok));
                        Console.WriteLine("\n=====================================");
                        Console.WriteLine("             0. I want collect it");
                        Console.WriteLine("=====================================");
                        Console.WriteLine("             1. Try again");
                        Console.WriteLine("=====================================");
                        Console.WriteLine("             2. Exit");
                        Console.WriteLine("=====================================");
                        Console.Write("         Select a character\n");
                        op = user_op();

                        switch (op)
                        {
                            case 0:
                                Console.WriteLine("=====================================");
                                Console.WriteLine("             Where do you want collect it?");
                                Console.WriteLine("\n=====================================");
                                Console.WriteLine("             0. In Ash pokedex");
                                Console.WriteLine("=====================================");
                                Console.WriteLine("             1. In Gary pokedex ");
                                Console.WriteLine("=====================================");
                                Console.Write("         Select a character\n");
                                op = user_op();
                                string player;
                                if (op == 0)
                                {
                                    player = "Ash";
                                }
                                else
                                {
                                    player = "Gary";
                                }
                                Console.Clear();
                                deletePok(player, op);
                                Console.Clear();
                                addPokemon(newPok[0]);
                                Console.Clear();
                                if(player == "Ash"){
                                    Console.WriteLine("Updated team:");
                                    Console.WriteLine(string.Join(", ", pokAsh));
                                } else{
                                    Console.WriteLine("Updated team:");
                                    Console.WriteLine(string.Join(", ", pokGary)); 
                                }
                                break;

                            case 2:
                                menu();
                                break;
                        }
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("=====================================");
                            Console.WriteLine("             You don't find anything");
                            Console.WriteLine("\n=====================================");
                            Console.WriteLine("             0. Try again");
                            Console.WriteLine("=====================================");
                            Console.WriteLine("             1. Exit");
                            Console.WriteLine("=====================================");
                            Console.Write("         Select a character\n");
                            op = user_op();
                            switch (op)
                            {
                                case 1:
                                    menu();
                                    break;
                            }
                        } while (op == 0);
                    }
                } while (op == 1);
                break;
        }
    }

    static void showteams(int character_op) //Function take variables
    {
        Console.Clear();
        if (character_op == 1)
        {
            Console.WriteLine("Team Gary: " + string.Join(", ", pokGary)); //"string.Join" it's used for write in the same line the content from array, where we can put what was between the variables and we could select their positions
        }
        else
        {
            Console.WriteLine("Team Ash: " + string.Join(", ", pokAsh));
        }
    }
    
    /* 
    If we have selected the option to show the teams, only the team we have selected will appear on the console. 
    However, if we have chosen the other option, a random Pokémon will be generated and we can then replace it in one of these teams.
    And this is the method to check what position it's null

                                    for(int y = 0; y <= 4; y++ ){
                                    if(pokGary[y] == null || pokAsh[y] == null){
                                    Console.WriteLine("The position " + y + "it's null");
                                    }
                                    }
    */

    static void deletePok(string player, int op) // Is used for delete pokemons traverses the index initialized by 1, so that it is from 1 to 5 and not from 0 to 4
    {

        switch (player)
    {
    case "Ash":
        int index = 1;
        foreach (string pokemon in pokAsh)
        {
            Console.WriteLine(index + ". " + pokemon);
            index++;
        }
        Console.WriteLine("Select a number to delete:");
        op = user_op() - 1;
        pokAsh[op] = null;
        break;
    case "Gary":
        index = 1;
        foreach (string pokemon in pokGary)
        {
            Console.WriteLine(index + ". " + pokemon);
            index++;
        }
        Console.WriteLine("Select a number to delete:");
        op = user_op() - 1;
        pokGary[op] = null;
        break;
    }
    
}

    static void addPokemon(string newPok) //Check all positions in the character array until a null is found and replace it
    {
        for (int i = 0; i < pokAsh.Length; i++)
        {
            if (pokAsh[i] == null)
            {
                pokAsh[i] = newPok;
            }
        }
        for (int o = 0; o < pokGary.Length; o++)
        {
            if (pokGary[o] == null)
            {
                pokGary[o] = newPok;
            }
        }
    }

    static int user_op()
    {
        while (true)
        {
            try
            {
                int op = Convert.ToInt32(Console.ReadLine());
                if (op >= 0 && op <= 2)
                {
                    return op;
                }
                else
                {
                    Console.WriteLine("Select a correct number (0 to 2)");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Select a number, not other characters");
            }
        }
    }

    static void pokemons_generator() //Generate pokemons randomly, there are two variables created so that they are totally random pokemons and not the same, that is why they are separated
    {
        int rndIndex;
        for (int i = 0; i < 5; i++)
        {
            rndIndex = rnd.Next(pokemons.Length);
            pokAsh[i] = pokemons[rndIndex];
        }

        for (int p = 0; p < 5; p++)
        {
            rndIndex = rnd.Next(pokemons.Length);
            pokGary[p] = pokemons[rndIndex];
        }
    }

    static void LoadScreen() //A loading screen that works based on delays
    {
        Console.Write("Searching Pokemons... [");
        Thread.Sleep(500);
        for (int i = 0; i < 30; ++i)
        {
            Console.Write("#");
            Thread.Sleep(100);
        }
        Console.Write("]");
        Thread.Sleep(1500);
    }
}
