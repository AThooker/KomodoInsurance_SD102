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
                    "1. I would like to create a Developer profile\n" +
                    "2. I would like to see all Developers\n" +
                    "3. I would like to update a Developer\n" +
                    "4. I would like to delete a developer\n" +
                    "5. I would like to create a Team\n" +
                    "6. I would like to see all the teams\n" +
                    "7. I would like to update a team\n" +
                    "8. I would like to delete a team\n" +
                    "9. I would like to add a Developer to a Team\n" +
                    "10. I would like to remove a Developer from a Team\n" +
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
        private static void CreateDeveloper()
        {
            Developer developer = new Developer();
            Console.Write("Name of Developer: ");
            developer.Name = Console.ReadLine();
            Console.Write("Do they have access to Pluralsight?");
            developer.PluralSight = bool.Parse(Console.ReadLine());
            Console.WriteLine("Would you like to add them to a team? y/n: ");
            string response = Console.ReadLine();
            if (response == "y")
            {
                Console.WriteLine("Which team? (Choose the team ID): \n");


            }
        }
        private static void GetAllDevelopers()
        {
            throw new NotImplementedException();
        }
        private static void UpdateDeveloper()
        {
            throw new NotImplementedException();
        }

        private static void DeleteDeveloper()
        {
            throw new NotImplementedException();
        }

        //TEAMS
        private void CreateTeam()
        {
            Console.Clear();
            while (true)
            {
                DevTeam team = new DevTeam();
                Console.WriteLine("What would you like this team's name to be: ");
                team.Name = Console.ReadLine();
                if (_teamRepo.CreateTeam(team))
                {
                    Console.Clear();
                    Console.WriteLine("Your team has been created successfully\n\n" +
                        $"Team ID: {team.ID}\n" +
                        $"Team Name: {team.Name}\n\n");
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
        private void GetListOfTeams()
        {
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
        }
        private static void UpdateTeam()
        {
            throw new NotImplementedException();
        }
        private static void DeleteTeam()
        {
            throw new NotImplementedException();
        }
        private static void AddDeveloperToTeam()
        {
            throw new NotImplementedException();
        }
        private static void RemoveDeveloperFromTeam()
        {
            throw new NotImplementedException();
        }
        public static void SeedMethod()
        {

        }
    }
}
