using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_POCO
{
    public class DevTeam_Repo
    {
        //Add and remove team members by ID

        //They should be able to see a list of existing developers to choose from and add to existing teams

        //Challenge: Our HR Department uses the software monthly to get a list of all our Developers that need a Pluralsight license.Create this functionality in the Console Application

        //Challenge: Some of our managers are nitpicky and would like the functionality to add multiple Developers to a team at once, rather than one by one.Integrate this into your application.

        Developer_Repo _developerRepo = new Developer_Repo();
        //List of DevTeams
        List<DevTeam> _devTeams = new List<DevTeam>();
        private DevTeam _devTeam;

        //Create
        public bool CreateTeam(DevTeam devTeam)
        {
            int initialCount = _devTeams.Count;
            _devTeams.Add(devTeam);
            int newCount = _devTeams.Count;
            return initialCount < newCount;
        }
        //Add to Team by developer ID
        public bool AddDeveloperToTeam(int devTeamID, int developerID)
        {
            foreach (var team in _devTeams)
            {
                if (team.ID == devTeamID)
                {
                    int initialCount = team.Developers.Count;
                    team.Developers.Add(_developerRepo.GetByID(developerID));
                    int newCount = team.Developers.Count;
                    return initialCount < newCount;
                }
            }
            return false;
        }

        //READ (get list of teams)
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }

        //UPDATE
        public DevTeam UpdateDevTeam(DevTeam devTeam)
        {
            _devTeam.ID = devTeam.ID;
            _devTeam.Name = devTeam.Name;
            return _devTeam;
        }
        //REMOVE Developer from team by developer ID
        public bool RemoveDeveloperFromTeam(int devTeamID, int developerID)
        {
            foreach (var team in _devTeams)
            {
                if (devTeamID == team.ID)
                {
                    int initialCount = team.Developers.Count;
                    team.Developers.Remove(_developerRepo.GetByID(developerID));
                    int newCount = team.Developers.Count;
                    return initialCount > newCount;
                }
            }
            return false;
        }
        //DELETE
        public bool DeleteDevTeam(int id)
        {
            int initialCount = _devTeams.Count;
            _devTeams.Remove(GetTeamByID(id));
            int newCount = _devTeams.Count;
            return initialCount > newCount;
        }

        //HELPER
        public DevTeam GetTeamByID(int id)
        {
            foreach (var team in _devTeams)
            {
                if (id == team.ID)
                {
                    return team;
                }
            }
            return null;
        }

    }
}
