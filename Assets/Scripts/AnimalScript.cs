using UnityEngine;
using UnityEngine.UI;

public class AnimalScript : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public AudioClip[] AnimalAudios;
    [SerializeField] private AudioClip[] _currentAnimalAudios;

    [SerializeField] private Image _animalSpriteButton;
    [SerializeField] private GameObject _animalButton;
    [SerializeField] public Sprite[] AnimalSprites;
    [SerializeField] private Sprite[] _currentAnimalSprites;

    [SerializeField] private GameObject _quizPanel;
    [SerializeField] private GameObject _nextCardPanel;
    private int _randomCurentObjIndex = 0;
    private int _amountOfObj = 0;
    public int[] SelectedIndex = new int[5];
    private int _iterations = 0;
    private int _reminingObj;

    private void Start()
    {
        _amountOfObj = AnimalAudios.Length;
        _reminingObj = AnimalAudios.Length;
        _currentAnimalAudios = new AudioClip[_amountOfObj];
        _currentAnimalSprites = new Sprite[_amountOfObj];
        System.Array.Copy(AnimalAudios,_currentAnimalAudios, _amountOfObj);
        System.Array.Copy(AnimalSprites, _currentAnimalSprites, _amountOfObj);
    }

    public void StartGame(GameObject startBatton)
    {
        NextCard();
        startBatton.SetActive(false);
        _animalButton.SetActive(true);
    }

    public void NextCard()
    {
        if (_iterations == SelectedIndex.Length)
        {
            StartQuiz();
        }
        else
        {
            _randomCurentObjIndex = GetRandomIndex();
            SelectedIndex[_iterations] = _randomCurentObjIndex;
            _iterations++;
            _audioSource.PlayOneShot(AnimalAudios[_randomCurentObjIndex]);
            _animalSpriteButton.sprite = AnimalSprites[_randomCurentObjIndex];
        }
    }

    private void StartQuiz()
    {
        _nextCardPanel.SetActive(false);
        _quizPanel.SetActive(true);
    }

    int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, _reminingObj);
        _currentAnimalAudios[randomIndex] = null;
        _currentAnimalSprites[randomIndex] = null;
        _reminingObj--;
        return randomIndex;
    }
}
