using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCardsPart : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public AudioClip[] AnimalAudios;
    private List<int> _selectedIndex = new List<int>();

    [SerializeField] private Image _animalSpriteButton;
    [SerializeField] private GameObject _animalButton;
    [SerializeField] public Sprite[] AnimalSprites;
    [SerializeField] private GameObject _quizPanel;
    [SerializeField] private GameObject _nextCardPanel;
    [SerializeField] private int _amountOfSelectingCards;
    private int _randomCurentObjIndex = 0;
    //public int[] SelectedIndex = new int[5];
    public List<int> SelectedIndex = new List<int>();
    private int _iterations = 0;
    private void Start()
    {
        for (int i = 0; i < AnimalAudios.Length; i++)
        {
            _selectedIndex.Add(i);
        }
        StartGame();
    }

    public void StartGame()
    {
        NextCard();
        _animalButton.SetActive(true);
    }

    virtual public void NextCard()
    {
        if (_iterations == _amountOfSelectingCards)
        {
            EndOfChangeCards();
        }
        else
        {
            _randomCurentObjIndex = GetRandomIndex();
            SelectedIndex.Add(_randomCurentObjIndex);
            _iterations++;
            _audioSource.PlayOneShot(AnimalAudios[_randomCurentObjIndex]);
            _animalSpriteButton.sprite = AnimalSprites[_randomCurentObjIndex];
        }
    }

    private void EndOfChangeCards()
    {
        _nextCardPanel.SetActive(false);
        _quizPanel.SetActive(true);
    }

    int GetRandomIndex()
    {
        if (_selectedIndex.Count == 0)
        {
            Debug.LogWarning("Все индексы уже использованы!");
            return -1;
        }

        int randomIndex = Random.Range(0, _selectedIndex.Count);
        int selectedIndex = _selectedIndex[randomIndex];
        _selectedIndex.RemoveAt(randomIndex);
        return selectedIndex;
    }
}
