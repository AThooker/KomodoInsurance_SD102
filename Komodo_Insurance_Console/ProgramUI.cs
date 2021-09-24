using Komodo_Insurance_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Komodo_Insurance_Console
{
    public class ProgramUI
    {
        Developer_Repo _devRepo = new Developer_Repo();
        DevTeam_Repo _teamRepo = new DevTeam_Repo();
        public void Run()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Komodo Insurance";
            SeedMethod();
            Menu();
        }
        public void Menu()
        {
            bool bigLoop = true;
            while (bigLoop)
            {
                Console.Clear();
                Console.WriteLine("Komodo Insurance\n\n" +
                    "1.  Create a Developer profile\n" +
                    "2.  See all Developers\n" +
                    "3.  Update a Developer\n" +
                    "4.  Delete a developer\n" +
                    "5.  Create a Team\n" +
                    "6.  See all the teams\n" +
                    "7.  Update a team\n" +
                    "8.  Delete a team\n" +
                    "9.  Add a Developer to a Team\n" +
                    "10. Remove a Developer from a Team\n" +
                    "11. Exit");
                string input = Console.ReadLine();
                try
                {
                    int integerInput = int.Parse(input);
                    switch (integerInput)
                    {
                        case 1:
                            CreateDeveloper();
                            break;
                        case 2:
                            GetAllDevelopers();
                            break;
                        case 3:
                            UpdateDeveloper();
                            break;
                        case 4:
                            DeleteDeveloper();
                            break;
                        case 5:
                            CreateTeam();
                            break;
                        case 6:
                            GetListOfTeams();
                            break;
                        case 7:
                            UpdateTeam();
                            break;
                        case 8:
                            DeleteTeam();
                            break;
                        case 9:
                            AddDeveloperToTeam();
                            break;
                        case 10:
                            RemoveDeveloperFromTeam();
                            break;
                        case 11:
                            bigLoop = false;
                            break;
                        default:
                            Console.WriteLine("Not one of the options slick!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("This is not an integer, try again skip.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }

            }
        }
        //DEVELOPERS
        private void CreateDeveloper()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Developer developer = new Developer();
                Console.Write("Name of Developer: ");
                developer.Name = Console.ReadLine();
                Console.Write("Do they have access to Pluralsight?: ");
                string pluralSightInput = Console.ReadLine().ToLower();
                if (pluralSightInput.StartsWith("y"))
                {
                    developer.PluralSight = true;
                }
                else
                {
                    developer.PluralSight = false;
                }

                if (_devRepo.CreateDeveloper(developer))
                {
                    Console.Clear();
                    Console.WriteLine("Developer created successfully");
                    DisplayDeveloper(developer);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("There has been an issue, try again\n");
                    keepRunning = true;
                }

                //Console.WriteLine("Would you like to add this Developer to a team? (y or n): ");
                //string response = Console.ReadLine();
                //if (response == "y")
                //{
                //    AddDeveloperToTeam();
                //    List<DevTeam> devTeams = _teamRepo.GetDevTeams();
                //    foreach(var team in devTeams)
                //    {
                //        DisplayTeam(team);
                //    }
                //    Console.WriteLine("\nDeveloper successfully added!\n");
                //    GetListOfTeams();
                //    Console.WriteLine("Press any key to continue");
                //    Console.ReadKey();
                //    break;
                //}

            }
        }
        private void DisplayDeveloper(Developer developer)
        {
            Console.WriteLine("\n" +
                $"Developer ID: {developer.ID}\n" +
                $"Name: {developer.Name}\n" +
                $"Access to PluralSight: {developer.PluralSight}\n\n");
        }
        private void GetAllDevelopers()
        {
            Console.Clear();
            List<Developer> developers = _devRepo.GetDevelopers();
            foreach (var developer in developers)
            {
                DisplayDeveloper(developer);
            }
            Console.WriteLine("\n" +
                "Press any key to continue");
            Console.ReadKey();
        }
        private void UpdateDeveloper()
        {
            GetAllDevelopers();
            Console.WriteLine("\nWhich developer would you like to update?(Choose their ID): ");
            int input = int.Parse(Console.ReadLine());
            var developer = _devRepo.GetByID(input);
            Console.WriteLine("These are their current credentials: \n");
            DisplayDeveloper(developer);
            Developer changingDev = new Developer();
            Console.WriteLine("What do you want their name to be now?: ");
            changingDev.Name = Console.ReadLine();
            Console.WriteLine("Do you want them to have access to PluralSight?: ");
            string inputPlural = Console.ReadLine().ToLower();
            changingDev.PluralSight = inputPlural.StartsWith("y") ? true : false;
            var updatedDeveloper = _devRepo.UpdateDeveloper(input, changingDev);
            Console.Clear();
            Console.WriteLine("Here are their credentials now!\n");
            DisplayDeveloper(updatedDeveloper);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        private void DeleteDeveloper()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                GetAllDevelopers();
                Console.WriteLine("\nWhich developer would you like to delete?(Choose their ID): ");
                int input = int.Parse(Console.ReadLine());
                if (_devRepo.DeleteDeveloper(input))
                {
                    Console.Clear();
                    Console.WriteLine("Developer successfully deleted\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Developer deletion unsuccessful, try again.");
                    keepRunning = true;
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        //TEAMS
        private void CreateTeam()
        {
            Console.Clear();
            while (true)
            {
                DevTeam team = new DevTeam();
                team.Developers = new List<Developer>();
                Console.WriteLine("What would you like this team's name to be: ");
                team.Name = Console.ReadLine();
                if (_teamRepo.CreateTeam(team))
                {
                    Console.Clear();
                    DisplayTeam(team);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("There has been an issue, try again");
                    continue;
                }
                break;
            }
        }
        private void DisplayTeam(DevTeam team)
        {
            Console.WriteLine("Your team\n\n" +
                                    $"Team ID: {team.ID}\n" +
                                    $"Team Name: {team.Name}\n\n");
        }
        private void GetListOfTeams()
        {
            Console.Clear();
            List<DevTeam> teams = _teamRepo.GetDevTeams();
            foreach (var team in teams)
            {
                Console.WriteLine($"Team ID {team.ID}\n" +
                    $"Team Name {team.Name}\n");
                foreach (var developer in team.Developers)
                {
                    Console.WriteLine($"Developer ID: {developer.ID}\n" +
                        $"Developer Name: {developer.Name}");
                }
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        private void UpdateTeam()
        {
            Console.Clear();
            GetListOfTeams();
            Console.WriteLine("\nWhich team would you like to update?(Choose the team's ID): \n");
            int input = int.Parse(Console.ReadLine());
            DevTeam team = _teamRepo.GetTeamByID(input);
            Console.WriteLine("These are the team's credentials: \n");
            DisplayTeam(team);
            DevTeam updatingTeam = new DevTeam();
            Console.WriteLine("what would you like the teams name to be now?: ");
            updatingTeam.Name = Console.ReadLine();
            var updatedTeam = _teamRepo.UpdateDevTeam(input, updatingTeam);
            Console.WriteLine("These are the team's credentials now:\n");
            DisplayTeam(team);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        private void DeleteTeam()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Which team would you like to delete?(Choose team ID): \n");
                _teamRepo.GetDevTeams();
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine("This is the team you are deleting: \n");
                _teamRepo.GetTeamByID(input);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                if (_teamRepo.DeleteDevTeam(input))
                {
                    Console.WriteLine("Team deleted successfully!!\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Something went wrong, try again");
                    continue;
                }
            }
        }
        private void AddDeveloperToTeam()
        {
            Console.Clear();
            do
            {
                GetAllDevelopers();
                Console.WriteLine("\nWhich developer would you like to put on a team?(Choose ID): ");
                int devId = int.Parse(Console.ReadLine());
                var dev = _devRepo.GetByID(devId);
                DisplayDeveloper(dev);
                GetListOfTeams();
                Console.WriteLine("\nWhich team would you like to put the developer on?(Choose ID): ");
                int teamId = int.Parse(Console.ReadLine());
                var team = _teamRepo.GetTeamByID(teamId);
                DisplayTeam(team);
                if (_teamRepo.AddDeveloperToTeam(teamId, devId))
                {
                    Console.WriteLine($"Developer {devId} added to team {teamId}\n\n" +
                        $"Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("You done messed it up, try again.\n\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
            } while (true);
        }
        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            while(true)
            {
                GetListOfTeams();
                Console.WriteLine("From which team would you like to remove a developer? ");
                int teamId = int.Parse(Console.ReadLine());
                var team = _teamRepo.GetTeamByID(teamId);
                DisplayTeam(team);
                GetAllDevelopers();
                Console.WriteLine("Which developer would you like to remove?: ");
                int devId = int.Parse(Console.ReadLine());
                var dev = _devRepo.GetByID(devId);
                DisplayDeveloper(dev);
                if(_teamRepo.RemoveDeveloperFromTeam(teamId, devId))
                {
                    Console.WriteLine("Developer removed successfully\n\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Something went wrong, try again\n\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
            }
        }
        public void SeedMethod()
        {
            //Seed teams
            List<Developer> devTeamAlpha = new List<Developer>();
            DevTeam teamOne = new DevTeam("Alpha", devTeamAlpha);
            _teamRepo.CreateTeam(teamOne);

            List<Developer> devTeamBravo = new List<Developer>();
            DevTeam teamTwo = new DevTeam("Bravo", devTeamBravo);
            _teamRepo.CreateTeam(teamTwo);

            List<Developer> devTeamCharlie = new List<Developer>();
            DevTeam teamThree = new DevTeam("Charlie", devTeamCharlie);
            _teamRepo.CreateTeam(teamThree);

            //Seed developers

            Developer devOne = new Developer("Alex", true);
            Developer devTwo = new Developer("Bryce", false);
            Developer devThree = new Developer("Chuck", true);

            _devRepo.CreateDeveloper(devOne);
            _devRepo.CreateDeveloper(devTwo);
            _devRepo.CreateDeveloper(devThree);
        }
    }
}
