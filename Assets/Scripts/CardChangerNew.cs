using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardChangerNew : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public List<int> SelectableIndex = new List<int>();
    private List<int> _selectedIndexes = new List<int>();
    private Image _animalSpriteButton;
    [SerializeField] private Button _animalButton;
    [SerializeField] private Button _startButton;

    [SerializeField] private AllAnimalSO _animalsCardSO;

    private int _iterations = 0;

    [SerializeField] public static int AvailableNumberSelectedCards;
    [SerializeField] private const int _amountOfCardsInGame = 10;

    private void Awake()
    {
        _animalSpriteButton = _animalButton.GetComponent<Image>();
    }

    private void Start()
    {
        InitializeSelectableIndexes();
    }

    private void InitializeSelectableIndexes()
    {
        AvailableNumberSelectedCards = _animalsCardSO.AnimalButtonsSO.Length;
        SelectableIndex.Clear();

        SelectableIndex.AddRange(Enumerable.Range(0, _animalsCardSO.AnimalButtonsSO.Length));

        for (int i = 0; i < _amountOfCardsInGame; i++)
        {
            _selectedIndexes.Add(GetRandomIndex());
        }
    }

    public void StartGame()
    {
        NextCard();
        _startButton.gameObject.SetActive(false);
        _animalButton.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextCard();
        }
    }

    private void NextCard()
    {
        if (_iterations == _amountOfCardsInGame)
        {
            EndOfCards();
        }
        else
        {
            PlayAudio(_animalsCardSO.AnimalButtonsSO[_selectedIndexes[_iterations]].Audio);
            _animalSpriteButton.sprite = _animalsCardSO.AnimalButtonsSO[_selectedIndexes[_iterations]].Sprite;
            _iterations++;
        }
    }

    private void PlayAudio(AudioClip currentAnimalAudio)
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        _audioSource.PlayOneShot(currentAnimalAudio);
    }

    protected virtual void EndOfCards()
    {
        _iterations = 0;
        InitializeSelectableIndexes();
        NextCard();
    }

    int GetRandomIndex()
    {
        if (SelectableIndex.Count == 0)
        {
            Debug.LogWarning("Все индексы уже использованы!");
            return -1;
        }

        int randomIndex = Random.Range(0, SelectableIndex.Count);
        int selectedIndex = SelectableIndex[randomIndex];
        SelectableIndex.RemoveAt(randomIndex);
        return selectedIndex;
    }
}

