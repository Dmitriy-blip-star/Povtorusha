using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AnimalQuizButton : MonoBehaviour
    { 
        [SerializeField] private GameObject _marker;

        public bool isCorrect = false; 

        public void ActivateMarker()
        {
            _marker.SetActive(true);
        }

        public void DeactivateMarker()
        {
            _marker.SetActive(false);
        }
    }
}