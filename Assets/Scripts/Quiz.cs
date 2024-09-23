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
        private List<int> _selectedIndex = new();
        private int _iterations = 0;

        private void Start()
        {
            _selectedIndex = new List<int>(_animal.SelectedIndex);
            StartQuiz();
        }

        void StartQuiz()
        {
            if (_selectedIndex.Count > 0)
            {
                ChangeCards();
            }
            else
            {
                Debug.LogWarning("Нет доступных индексов для начала викторины.");
            }
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                    UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
        }

        void ChangeCards()
        {
            if (_iterations >= _selectedIndex.Count)
            {
                Debug.LogWarning("Все карточки использованы. Игра завершена.");
                // Логика завершения игры
                return;
            }

            int currentIndex = _selectedIndex[_iterations];

            if (currentIndex >= 0 && currentIndex < _animal.AnimalAudios.Length)
            {
                _audioSource.PlayOneShot(_animal.AnimalAudios[currentIndex]);
            }
            else
            {
                Debug.LogWarning("Индекс звука выходит за пределы массива!");
                return;
            }

            int randomCorrectButtonIndex = Random.Range(0, _animalSpriteButtons.Length);

            for (int i = 0; i < _animalSpriteButtons.Length; i++)
            {
                if (i == randomCorrectButtonIndex)
                {
                    if (currentIndex >= 0 && currentIndex < _animal.AnimalSprites.Length)
                    {
                        _animalSpriteButtons[i].sprite = _animal.AnimalSprites[currentIndex];
                        _animalSpriteButtons[i].gameObject.GetComponent<AnimalQuizButton>().isCorrect = true;
                    }
                    else
                    {
                        Debug.LogWarning("Индекс картинки выходит за пределы массива!");
                        return;
                    }
                }
                else
                {
                    int randomIndex = GetRandomIncorrectIndex(currentIndex);
                    if (randomIndex != -1 && randomIndex < _animal.AnimalSprites.Length)
                    {
                        _animalSpriteButtons[i].sprite = _animal.AnimalSprites[randomIndex];
                        _animalSpriteButtons[i].gameObject.GetComponent<AnimalQuizButton>().isCorrect = false;
                    }
                    else
                    {
                        Debug.LogWarning("Неверный случайный индекс!");
                    }
                }
            }

            _iterations++;
        }

        int GetRandomIncorrectIndex(int correctIndex)
        {
            List<int> incorrectIndices = new List<int>();

            for (int i = 0; i < _animal.AnimalSprites.Length; i++)
            {
                if (i != correctIndex)
                {
                    incorrectIndices.Add(i);
                }
            }

            if (incorrectIndices.Count == 0)
            {
                Debug.LogWarning("Нет доступных неправильных индексов!");
                return -1;
            }

            int randomIndex = Random.Range(0, incorrectIndices.Count);
            return incorrectIndices[randomIndex];
        }

        private void TryAgain()
        {
            Debug.Log("Попробуйте снова!");
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
    }
}
