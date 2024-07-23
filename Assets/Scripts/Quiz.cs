using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private AnimalScript _animal;
        [SerializeField] private GameObject _quizPanel;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Image[] _animalSpriteButtons;
        [SerializeField] private Sprite[] _currentAnimalSprites;
        private int _iterations = 0;
        private void Start()
        {
            _currentAnimalSprites = new Sprite[_animal.AnimalSprites.Length];
            System.Array.Copy(_animal.AnimalSprites, _currentAnimalSprites, _animal.AnimalSprites.Length);

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

        }

        int GetRandomIndex()
        {
            int randomIndex = Random.Range(0, _animal.SelectedIndex.Length);
            _currentAnimalSprites[_animal.SelectedIndex[randomIndex]] = null;
            return randomIndex;
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