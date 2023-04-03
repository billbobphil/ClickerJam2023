using System.Collections;
using Banks;
using Player;
using UnityEngine;

namespace Crew
{
    public class CrewAtBankActions : MonoBehaviour
    {
        private CrewManager _crewManager;
        public bool isAddButton = false;
        public Bank bank;

        private void Awake()
        {
            _crewManager = GameObject.FindWithTag("Player").GetComponent<CrewManager>();
        }

        private void OnMouseDown()
        {
            if (isAddButton)
            {
                _crewManager.AssignCrewMemberToBank(bank);
            }
            else
            {
                _crewManager.RemoveCrewMemberFromBank(bank);
            }

            StartCoroutine(AnimateButton());
        }

        private IEnumerator AnimateButton()
        {
            transform.localScale += new Vector3(.5f, .5f, .5f);
            yield return new WaitForSeconds(.1f);
            transform.localScale -= new Vector3(.5f, .5f, .5f);
        }
    }
}
