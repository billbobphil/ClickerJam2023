using System.Collections.Generic;
using Banks;
using Crew;
using UnityEngine;

namespace Player
{
    public class CrewManager : MonoBehaviour
    {
        public List<CrewMember> crew = new();
        public List<CrewMember> availableCrewMembers = new();
        public List<CrewMember> assignedCrewMembers = new();

        private void Awake()
        {
            availableCrewMembers = crew;
        }
        
        public void AddNewCrewMember(CrewMember crewMember)
        {
            crew.Add(crewMember);
            availableCrewMembers.Add(crewMember);
        }

        public void RemoveCrewMemberFromBank(Bank bank)
        {
            Debug.Log("Trying to remove crew member");
            if (assignedCrewMembers.Count > 0)
            {
                CrewMember member = assignedCrewMembers.Find(member => member.bank == bank);
                member.bank.RemoveCrewMember();
                assignedCrewMembers.Remove(member);
                availableCrewMembers.Add(member);
            }
            else
            {
                Debug.Log("No crew members at that bank");
            }
        }
        
        public void AssignCrewMemberToBank(Bank bank)
        {
            Debug.Log("Trying to assign crew member");
            if (availableCrewMembers.Count > 0)
            {
                CrewMember crewMember = availableCrewMembers[0];
                crewMember.MoveToBank(bank);
                bank.AddCrewMember();
                availableCrewMembers.Remove(crewMember);
                assignedCrewMembers.Add(crewMember);
            }
        }
    }
}