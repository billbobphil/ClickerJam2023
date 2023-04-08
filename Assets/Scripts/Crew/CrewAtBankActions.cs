using System;
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
        public AudioSource ButtonHoverAudioSource;
        public AudioSource ButtonClickAudioSource;
        public AudioSource ButtonFailAudioSource;

        private void Awake()
        {
            _crewManager = GameObject.FindWithTag("Player").GetComponent<CrewManager>();
        }

        private void OnMouseDown()
        {
            bool success;
            if (isAddButton)
            {
                success = _crewManager.AssignCrewMemberToBank(bank);
            }
            else
            {
                success = _crewManager.RemoveCrewMemberFromBank(bank);
            }

            if (success)
            {
                ButtonClickAudioSource.Play();
            }
            else
            {
                ButtonFailAudioSource.Play();
            }
            
            StartCoroutine(AnimateButton());
        }

        private void OnMouseEnter()
        {
            ButtonHoverAudioSource.Play();
            transform.localScale += new Vector3(.5f, .5f, 0);
        }

        private void OnMouseExit()
        {
            transform.localScale -= new Vector3(.5f, .5f, 0);
        }

        private IEnumerator AnimateButton()
        {
            transform.localScale += new Vector3(.8f, .8f, 0);
            yield return new WaitForSeconds(.1f);
            transform.localScale -= new Vector3(.8f, .8f, 0);
        }
    }
}
