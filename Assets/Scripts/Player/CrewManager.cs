using System.Collections.Generic;
using Banks;
using Crew;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Player
{
    public class CrewManager : MonoBehaviour
    {
        public List<CrewMember> crew = new();
        public List<CrewMember> availableCrewMembers = new();
        public List<CrewMember> assignedCrewMembers = new();
        public TextMeshProUGUI availableCrewMembersText;
        public Pulsate crewMemberPulsate;
        public Image crewMemberIcon;
        private Color membersAvailableColor = new Color(255f/255f, 232f/255f, 55f/255f);
        private Color noMembersAvailableColor = new Color(255f/255f, 255f/255f, 255f/255f);

        private void Awake()
        {
            foreach (CrewMember crewMember in crew)
            {
                availableCrewMembers.Add(crewMember);
            }
        }

        public void AddNewCrewMember(CrewMember crewMember)
        {
            Debug.Log("Got new crew member!");
            crew.Add(crewMember);
            availableCrewMembers.Add(crewMember);
            availableCrewMembersText.text = availableCrewMembers.Count.ToString();
            UpdateCrewMemberIcon();
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
                availableCrewMembersText.text = availableCrewMembers.Count.ToString();
                member.RemoveFromBank();
                UpdateCrewMemberIcon();
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
                availableCrewMembersText.text = availableCrewMembers.Count.ToString();
                UpdateCrewMemberIcon();
            }
            else
            {
                Debug.Log("No available crew members");
                //TODO: show a message of some sort
            }
        }

        private void UpdateCrewMemberIcon()
        {
            if (availableCrewMembers.Count > 0)
            {
                crewMemberPulsate.enabled = true;
                crewMemberIcon.color = membersAvailableColor;
            }
            else
            {
                crewMemberPulsate.enabled = false;
                crewMemberIcon.color = noMembersAvailableColor;
            }
        }
    }
}