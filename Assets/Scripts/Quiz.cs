using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private CardChangerNew _animal;
        [SerializeField] private AllAnimalSO _allAnimalButtons;
        [SerializeField] private GameObject _quizPanel;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Image[] _animalSpriteButtons;
        //private List<int> _selectedIndex = new();
        private int _iterations = 0;

        //private int currentIndex;

        [SerializeField] private Image _markerImage;
        [SerializeField] private Sprite _wrongChoose;
        [SerializeField] private Sprite _rightChoose;
        [SerializeField] private GameObject _endOfGamePanel;

        [SerializeField] private AnimalQuizButton[] _animalQuizButtons;

        private int _rigthAnswer;
        private int _wrongAnswer;

        [SerializeField] private Image[] stars;
        [SerializeField] private ParticleSystem[] starsEffect;
        private const int _numberOfResponses = 5;

        private void Start()
        {
            //_selectedIndex = new List<int>(_animal.SelectableIndex);

            StartQuiz();
        }
        public List<T> GetRandomItems<T>(List<T> list, int numberOfItems)
        {
            if (numberOfItems > list.Count)
            {
                Debug.LogError("Запрашиваемое количество элементов больше, чем в списке.");
                return null;
            }

            List<T> selectedItems = new List<T>();
            HashSet<int> selectedIndices = new HashSet<int>(); // Множество для хранения уникальных индексов

            System.Random random = new System.Random();

            while (selectedItems.Count < numberOfItems)
            {
                int randomIndex = random.Next(list.Count);

                // Если индекс не был выбран ранее, добавляем его в список
                if (!selectedIndices.Contains(randomIndex))
                {
                    selectedIndices.Add(randomIndex);
                    selectedItems.Add(list[randomIndex]);
                }
            }

            return selectedItems;
        }

        void StartQuiz()
        {
            if (CardChangerNew.AvailableNumberSelectedCards > 0)
            {
                ChangeCards();
            }
            else
            {
                Debug.LogWarning("Нет доступных индексов для начала викторины.");
            }
        }

        private void Update()
        {   // перезапуск сцены
            if (Input.GetKeyUp(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                    UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
        }

        void ChangeCards()
        {
            RemoveMarkers(); 

            if (_iterations >= 0 && _iterations < CardChangerNew.AvailableNumberSelectedCards)
            {
                PlayAudio();
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
                    if (_iterations >= 0 && _iterations < CardChangerNew.AvailableNumberSelectedCards)
                    {
                        _animalSpriteButtons[i].sprite = _allAnimalButtons.AnimalButtonsSO[_iterations].Sprite;
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
                    int randomIndex = GetRandomIncorrectIndex(_iterations);
                    if (randomIndex != -1 && randomIndex < _allAnimalButtons.AnimalButtonsSO.Length)
                    {
                        _animalSpriteButtons[i].sprite = _allAnimalButtons.AnimalButtonsSO[randomIndex].Sprite;
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

        private void PlayAudio()
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
            _audioSource.PlayOneShot(_allAnimalButtons.AnimalButtonsSO[_iterations].Audio);
        }

        private void RemoveMarkers()
        {
            foreach(AnimalQuizButton animalQuizButton in _animalQuizButtons)
            {
                animalQuizButton.DeactivateMarker();
            }
        }

        private void CheckGameEnd()
        {
            foreach(Image buttons in _animalSpriteButtons)
            {
                buttons.gameObject.SetActive(false);
            }
            _endOfGamePanel.SetActive(true);
        }

        int GetRandomIncorrectIndex(int correctIndex)
        {
            List<int> incorrectIndices = new List<int>();

            for (int i = 0; i < _allAnimalButtons.AnimalButtonsSO.Length; i++)
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

        private void TryAgain(AnimalQuizButton animalQuizButton)
        {
            Debug.Log("Попробуйте снова!");

            _markerImage.sprite = _wrongChoose;
            _wrongAnswer++;
            animalQuizButton.ActivateMarker();
        }

        public void SelectCard(AnimalQuizButton animalQuizButton)
        {
            if (animalQuizButton.isCorrect)
            {
                animalQuizButton.isCorrect = false;
                RightChosoe();
            }
            else
            {
                TryAgain(animalQuizButton);
            }
        }

        private void RightChosoe()
        {
            _markerImage.sprite = _rightChoose;
            stars[_rigthAnswer].color = Color.white;
            starsEffect[_rigthAnswer].Play();
            _rigthAnswer++;

            if (_iterations >= _numberOfResponses)
            {
                Debug.LogWarning("Все карточки использованы. Игра завершена.");
                CheckGameEnd();
                return;
            }

            ChangeCards();
        } 
            
    }
}
