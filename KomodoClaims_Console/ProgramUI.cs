using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Console
{
    class ProgramUI
    {
        private ClaimsRepository _repo = new ClaimsRepository();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        public void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Starting Menu Options
                Console.WriteLine($"\n" +
                    $"Welcome to the Agent Claims Center!\n" +
                    $"Please select an option below to get started:\n\n" +
                    $"1. See all claims\n" +
                    $"2. Take care of next claim\n" +
                    $"3. Enter a new claim\n" +
                    $"4. Exit");

                //User Input
                string input = Console.ReadLine();

                //Menu Logic
                switch (input)
                {
                    case "1":
                        DisplayItemsInQueue();
                        break;
                    case "2":
                        //Next Claim
                        TakeCareOfClaim();
                        break;
                    case "3":
                        //New Claim
                        AddNewClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option(1 - 3):");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayItemsInQueue()
        {
            Console.Clear();
            Queue<Claims> listOfClaims = _repo.ViewClaimsInQueue();
            foreach (Claims claim in listOfClaims)
            {
                DisplayContent(claim);
            }
        }

        private void TakeCareOfClaim()
        {
            Queue<Claims> nextClaim = _repo.ViewClaimsInQueue();
            DisplayContent(nextClaim.Peek());

            Console.WriteLine("\nWould you like to deal with this claim now? (Y / N)");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                nextClaim.Dequeue();
                Console.WriteLine("Claim has been pulled from database.");
            }
            else
            {
                Console.WriteLine("\nClain not dealt with. Press any key to return to main menu...");
            }

        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();
            Console.WriteLine("Enter the ID number of the new claim:\n");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nPlease enter type of Claim(1 - 3):\n" +
                $"1. Car\n" +
                $"2. Home\n" +
                $"3. Theft\n");
            string claimType = Console.ReadLine();
            int claimTypeID = int.Parse(claimType);
            newClaim.ClaimType = (ClaimType)claimTypeID;

            Console.WriteLine("\nEnter a description for the new claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("\nEnter the amount of the new claim:");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nPlease enter the date of the incident(mm/dd/yyyy):");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("\nPlease enter the date the claim was filed(mm/dd/yyyy):");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _repo.AddClaimToQueue(newClaim);

        }



        //Helpers
        private void DisplayContent(Claims claim)
        {
            Console.WriteLine($"\n" +
                $"Claim ID: {claim.ClaimID}\n" +
                $"Claim Type: {claim.ClaimType}\n" +
                $"Description: {claim.Description}\n" +
                $"Claim Amount: ${claim.ClaimAmount}\n" +
                $"Date of Incident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Is Claim Valid?: {claim.IsValid}\n");
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //SeedData
        private void SeedData()
        {
            Claims claim1 = new Claims(1, ClaimType.Car, "Accident on Washington St", 5000.00, new DateTime(2021, 07, 22), new DateTime(2021, 07, 23));
            _repo.AddClaimToQueue(claim1);
            
            Claims claim2 = new Claims(2, ClaimType.Theft, "Car stolen in Washington DC", 15000.00, new DateTime(2021, 01, 06), new DateTime(2021, 02, 14));
            _repo.AddClaimToQueue(claim2);
            
            Claims claim3 = new Claims(3, ClaimType.Home, "Tree fell on roof", 8000.00, new DateTime(2021, 09, 25), new DateTime(2021, 10, 02));
            _repo.AddClaimToQueue(claim3);
        }
    }
}
