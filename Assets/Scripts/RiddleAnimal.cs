using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class RiddleAnimal : CardChangerNew
    {
        [SerializeField] private GameObject _quizPanel;
        [SerializeField] private GameObject _nextCardPanel;

        protected override void EndOfCards()
        {
            _quizPanel.SetActive(true);
            _nextCardPanel.SetActive(false);
        }
    }
}