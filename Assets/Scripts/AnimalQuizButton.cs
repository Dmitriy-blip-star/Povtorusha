using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AnimalQuizButton : MonoBehaviour
    {
        public static AnimalQuizButton Instance;

        public bool isCorrect = false;
        private void Start()
        {
            Instance = this;
        }
    }
}