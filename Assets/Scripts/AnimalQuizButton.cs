using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AnimalQuizButton : MonoBehaviour
    {
        //public static AnimalQuizButton Instance;
        [SerializeField] private GameObject _marker;

        public bool isCorrect = false;
        private void Start()
        {
            //Instance = this;
        }

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