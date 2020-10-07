using _03_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    class ProgramUI
    {
        private readonly BadgesRepository _badgesRepo = new BadgesRepository();


        public void Run()
        {
            SeedContent();
            RunMenu();

        }

        private void RunMenu()
        {
            bool continuetoRun = true;
            while (continuetoRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, what would you like to do? \n" +
                    "1) Add a badge \n" +
                    "2) Edit a badge \n" +
                    "3) List all badges \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        //Exit
                        continuetoRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number (1, 2, 3 or 4). \n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }

            }
        }
        public void AddNewBadge()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Badges content = new Badges();
                Console.WriteLine("What is the badge number?");
                int userInput = int.Parse(Console.ReadLine());
                content.BadegeID = userInput;

                Console.WriteLine("Select a door this badge needs access to: \n" +
                    "1) A1 \n" +
                    "2) A2 \n" +
                    "3) A3 \n" +
                    "4) A4 \n" +
                    "5) A5 \n" +
                    "6) A6 \n" +
                    "7) A7 \n" +
                    "8) B1 \n" +
                    "9) B2 \n" +
                    "10) B3 \n" +
                    "11) B4 \n" +
                    "12) B5 \n");
                string genreResponse = Console.ReadLine();
                int doorID = int.Parse(genreResponse);
                content.DoorID = (DoorNames)doorID;

                Console.WriteLine("Any other doors?\n" +
                    "y \n" +
                    "n \n");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "y":
                        AnswerIsYes();
                        break;
                    case "n":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a 'y' for YES or a 'n' for NO");
                        Console.ReadLine();
                        break;
                }
                _badgesRepo.AddContentToDictionary(content);
            }
        }
        public void AnswerIsYes()
        {
            Console.WriteLine("List a door that it needs access to:");
            string genreInput = Console.ReadLine();
            int doorID = int.Parse(genreInput);
            Console.WriteLine("Add another doors?");
            Console.ReadLine();
        }

        public void EditBadge()
        {
            Console.Clear();
            Badges content = new Badges();
            Console.WriteLine("What is the badge number to update?");
            int userInput = int.Parse(Console.ReadLine());
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a door \n" +
                "2. Add a door" );
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Which door would you like to remove?");
                string uInput = Console.ReadLine();
            }
            if (input == "2")
            {
                Console.WriteLine("which door would you like to add?");
                string UsInput = Console.ReadLine();
            }

        }

        public void ListAllBadges()
        {

            Console.Clear();

            Dictionary<int, DoorNames> listOfContents = _badgesRepo.GetContent();

            foreach (KeyValuePair<int, DoorNames> content in listOfContents)
            {
                Console.WriteLine(listOfContents);
                Console.ReadLine();
            }
            

        }
        public void SeedContent()
        {
            var badgeOne = new Badges(12345, DoorNames.A1);
            var badgeTwo = new Badges(22345, DoorNames.A5);
            var badgeThree = new Badges(32345, DoorNames.A7);
            var badgeFour = new Badges(47698, DoorNames.B1);

            _badgesRepo.AddContentToDictionary(badgeOne);
            _badgesRepo.AddContentToDictionary(badgeTwo);
            _badgesRepo.AddContentToDictionary(badgeThree);
            _badgesRepo.AddContentToDictionary(badgeFour);






        }



    }

}




