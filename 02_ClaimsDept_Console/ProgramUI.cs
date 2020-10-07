using _02_ClaimsDept_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsDept_Console
{
    class ProgramUI
    {

        private readonly ClaimsRepository _claimRepo = new ClaimsRepository();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item: \n" +
                    "1) See all claims \n" +
                    "2) Take care of the next claim \n" +
                    "3) Enter a new claim \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        UpdateExistingClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
        }
        private void AddNewClaim()
        {
            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim id:");
            string idAsString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(idAsString);

            Console.WriteLine($"Enter the claim type for {newClaim.ClaimID} (Car, Home or Theft)");
            newClaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter a description of the claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter damage amount:");
            string decimalAsString = Console.ReadLine();
            newClaim.ClaimAmount = decimal.Parse(decimalAsString);

            DateTime validFrom, validTo;
            Console.WriteLine("Enter date of incident:");
            validFrom = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfIncident = validFrom;

            Console.WriteLine("Enter date of claim:");
            validTo = Convert.ToDateTime(Console.ReadLine());
            newClaim.DateOfClaim = validTo;

            Console.WriteLine("Is this claim valid -- y/n? (claim must be filed within 30 days of incident)?");
            string isClaimValid = Console.ReadLine().ToLower();

            if (isClaimValid == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

        }



        public void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claims> claimDetails = _claimRepo.GetClaims();
            foreach (Claims content in claimDetails)
            {
                Console.WriteLine($"{content.ClaimID}, {content.ClaimType} ,{content.Description}, {content.ClaimAmount.ToString()}, {content.DateOfIncident}, {content.DateOfClaim}, {content.IsValid}");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            
        }

        public void UpdateExistingClaim()
        {
            Console.Clear();
            Queue<Claims> workOnClaim = _claimRepo.GetClaims();
            foreach (Claims claimOne in workOnClaim)
            {
                Console.WriteLine("Here are the details for the next claim to be handled:");
                Console.WriteLine("Do you want to deal with this claim now (y/n)?");
                Console.WriteLine($"{claimOne.ClaimID}, {claimOne.ClaimType} ,{claimOne.Description}, {claimOne.ClaimAmount.ToString()}, {claimOne.DateOfIncident}, {claimOne.DateOfClaim}, {claimOne.IsValid}");
                Console.ReadLine();
                

                string yesOrNo = Console.ReadLine().ToLower();

                if (yesOrNo == "y")
                {
                    Console.WriteLine("Next item in queue: {0}", workOnClaim.Dequeue());
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Press any key to return to main menu.");
                }
            }

        }


        private void SeedContent()
        { 

            var claimOne = new Claims(1, "Car", "Car accident on 465.", 400.00m, Convert.ToDateTime("4/25/18"),Convert.ToDateTime("4/27/18"), true) ;
            var claimTwo = new Claims(2, "Home", "House fire in kitchen.", 4000.00m, Convert.ToDateTime("4/11/18"), Convert.ToDateTime("4/12/18"), true);
            var claimThree = new Claims(3, "Theft", "Stolen pancakes", 4.00m, Convert.ToDateTime ("4/27/18"), Convert.ToDateTime("6/01/18"), false);

            _claimRepo.AddNewClaim(claimOne);
            _claimRepo.AddNewClaim(claimTwo);
            _claimRepo.AddNewClaim(claimThree);

        }
    }
}

