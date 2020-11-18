using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuLib;

namespace ConsoleUISeparate
{


    class Menu
    {

        bool keepLooping;
        bool refreshScreen;
    
        public Menu() {



            init();

            do
            {

                string input = Console.ReadLine();
                keepLooping = true;
                refreshScreen = true;


                switch (input)
                {
                    case "1":
                        Options.incrementLevel();
                        break;
                    case "2":
                        Options.incrementStartBalance();
                        break;
                    case "3":
                        Options.incrementGameDuration();
                        break;
                    case "4":
                        Options.resetSettings();
                        break;
                    case "5":
                        keepLooping = false;
                        refreshScreen = false;
                        
                        new Game();
                        break;
                    default:
                        refreshScreen = false;
                        Console.WriteLine("[Invalid Input]");
                        break;
                }

                if (refreshScreen) {
                    Console.Clear();
                    init();
                }

            } while (keepLooping); 
            


        }

        public static void init() {
            Console.Clear();

            Console.WriteLine("1) [Level] ==> {0}", Options.level[Options.lvl_active % Options.level.Length]);
            Console.WriteLine("2) [Start Balance] ==> {0}", Options.startBalance[Options.startBalance_active % Options.startBalance.Length]);
            Console.WriteLine("3) [Game Duration] ==> {0}", Options.gameDuration[Options.gameDuration_active % Options.gameDuration.Length]);
            Console.WriteLine("4) [Reset Settings]");
            Console.WriteLine("5) [Start Game]");

       
            
        }

        static void Main(string[] args) { 
            new Menu();
        }

    }
}
