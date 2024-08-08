using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private PreAnimalQuiz _animal;
        [SerializeField] private GameObject _quizPanel;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Image[] _animalSpriteButtons;
        //[SerializeField] private Sprite[] _currentAnimalSprites;
        private List<int> _selectedIndex = new List<int>();
        private int _iterations = 0;
        private void Start()
        {
            _selectedIndex.AddRange(_animal.SelectedIndex);
            StartQuiz();
        }

        void StartQuiz ()
        {
            ChangeCards();
        }

        void ChangeCards()
        {
            _audioSource.PlayOneShot(_animal.AnimalAudios[_animal.SelectedIndex[_iterations]]);
            
            int randomCorrectButtonIndex = Random.Range(0, _animalSpriteButtons.Length);
            for (int i = 0; i < _animalSpriteButtons.Length; i++)
            {
                _animalSpriteButtons[i].sprite = _animal.AnimalSprites[_animal.SelectedIndex[GetRandomIndex()]];
                if (i == randomCorrectButtonIndex)
                {
                    _animalSpriteButtons[i].sprite = _animal.AnimalSprites[_animal.SelectedIndex[_iterations]];
                    _iterations++;
                    _animalSpriteButtons[i].gameObject.GetComponent<AnimalQuizButton>().isCorrect = true;
                }

            }
            _selectedIndex.AddRange(_animal.SelectedIndex);

        }

        int GetRandomIndex()
        {
            if (_selectedIndex.Count == 0)
            {
                Debug.LogWarning("Все индексы уже использованы!");
                return -1; // Возвращаем -1, если все индексы использованы
            }

            int randomIndex = Random.Range(0, _selectedIndex.Count);
            int selectedIndex = _selectedIndex[randomIndex];
            _selectedIndex.RemoveAt(randomIndex); // Удаляем использованный индекс из списка
            return selectedIndex;
        }

        public void SelectCard(AnimalQuizButton animalQuizButton)
        {
            if (animalQuizButton.isCorrect)
            {
                animalQuizButton.isCorrect = false;
                ChangeCards();
            }
            else
            {
                TryAgain();
            }
        }

        private void TryAgain()
        {
            throw new System.NotImplementedException();
        }
    }
}