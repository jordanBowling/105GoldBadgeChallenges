using KomodoBadges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Console
{
    public class ProgramUI
    {
        private BadgesRepository _doorRepo = new BadgesRepository();

        public void Run()
        {
            SeedData();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine($"Hello Komodo Security Admin, What would you like to do today?\n\n" +
                    $"1. Add a badge\n" +
                    $"2. Edit a badge\n" +
                    $"3. List all badges\n" +
                    $"4. Exit\n\n" +
                    $"Please enter the number of the option you would like to select(1 - 4):");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //AddBadge
                        AddBadge();
                        break;
                    case "2":
                        //Editbadge
                        EditBadge();
                        break;
                    case "3":
                        //ListBadges
                        SeeBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1 - 4");
                        break;
                }
            }

        }

        private void AddBadge()
        {
            Console.Clear();

            Badges addedBadge = new Badges();
            addedBadge.DoorAccess = new List<string>();

            Console.WriteLine("Enter the new badge number:\n");
            addedBadge.BadgeID = Convert.ToInt32(Console.ReadLine());

            bool newBadgeDoors = true;

            while (newBadgeDoors == true)
            {
                Console.WriteLine("\nEnter a door that this badge needs access to:\n");
                string doorAdded = Console.ReadLine();

                //Adding to verify for user that the door was actually added
                int beforeAdd = addedBadge.DoorAccess.Count;
                addedBadge.DoorAccess.Add(doorAdded);


                int afterAdd = addedBadge.DoorAccess.Count;
                if (beforeAdd < afterAdd)
                {
                    Console.WriteLine($"Access to door activated\n");
                }
                else
                {
                    Console.WriteLine($"Could not activate door\n");
                }

                Console.WriteLine($"Would you like to activate another door for this badge number? (Y / N)");
                string userInput = Console.ReadLine().ToLower();

                if (userInput != "y")
                {
                    newBadgeDoors = false;
                }


            }

            _doorRepo.AddNewbadge(addedBadge);

            PressAnyKey();


        }

        private void EditBadge()
        {
            Console.Clear();

            Badges editedBadge = new Badges();
            editedBadge.DoorAccess = new List<string>();

            Console.WriteLine($"Enter the badge number that you would like to edit:\n");
            editedBadge.BadgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What would you like to do with this badge?\n" +
                "1. Add a door\n" +
                "2. Remove a door\n" +
                "3. Return to Main Menu\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddDoor(editedBadge.BadgeID);
                    break;
                case "2":
                    RemoveDoor(editedBadge.BadgeID);
                    break;
                case "3":

                    break;
                default:
                    Console.WriteLine("Please enter a valid number(1 - 3):");
                    break;
            }
        }

        private void AddDoor(int badgeID)
        {
            Console.WriteLine("Enter a door that you would like to add:\n");
            string newDoor = Console.ReadLine();

            _doorRepo.UpdateBadge(badgeID, newDoor);

            Console.WriteLine($"\nAccess to door {newDoor} has been ACTIVATED\n");

            PressAnyKey();
        }

        private void RemoveDoor(int badgeID)
        {
            Console.WriteLine("Enter a door that you would like to remove:\n");
            string oldDoor = Console.ReadLine();

            _doorRepo.RemoveADoor(badgeID, oldDoor);

            Console.WriteLine($"\nAccess to door {oldDoor} has been DEACTIVATED\n");

            PressAnyKey();
        }

        private void SeeBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> badgeList = _doorRepo.GetListOfbadges();

            foreach (KeyValuePair<int, List<string>> badge in badgeList)
            {
                Console.WriteLine($"\nBadge: {badge.Key}\n");

                foreach (string doorsAvailable in badge.Value)
                {
                    Console.WriteLine($"{doorsAvailable}");
                }
                Console.WriteLine("\n_________________________________________________________________________________________________________");
            }

            PressAnyKey();



        }

        //Helpers
        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }


        //SeedData
        private void SeedData()
        {
            Badges personOne = new Badges(1234, new List<string> { "A1", "A2", "B2" });
            Badges personTwo = new Badges(2345, new List<string> { "A1", "A2", "B1", "B2" });
            Badges personThree = new Badges(3456, new List<string> { "A2", "B2" });

            _doorRepo.AddNewbadge(personOne);
            _doorRepo.AddNewbadge(personTwo);
            _doorRepo.AddNewbadge(personThree);
        }

    }
}
