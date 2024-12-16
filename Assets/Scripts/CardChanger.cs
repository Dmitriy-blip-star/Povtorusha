using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardChanger : MonoBehaviour
{
    [SerializeField] public float Delay = 3.5f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public AudioClip[] AnimalAudios;
    private List<int> _selectedIndex = new List<int>();
    [SerializeField] private Image _animalSpriteButton;
    [SerializeField] private GameObject _animalButton;
    [SerializeField] public Sprite[] AnimalSprites;
    private int _randomCurentObjIndex = 0;
    public List<int> SelectedIndex = new List<int>();
    private int _iterations = 0;

    private bool _canPressed = true;

    [SerializeField] protected int _amountOfSelectingCards;

    [SerializeField] public GameObject QuizPanel;
    [SerializeField] public GameObject NextCardPanel;

    private void Start()
    {
        if (_amountOfSelectingCards == 0)
        {
            _amountOfSelectingCards = AnimalSprites.Length;
        }
        InitializeSelectedIndexes();
        StartGame();
    }

    private void InitializeSelectedIndexes()
    {
        for (int i = 0; i < AnimalAudios.Length; i++)
        {
            _selectedIndex.Add(i);
        }
    }

    public void StartGame()
    {
        NextCard();
        _animalButton.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextCard();
        }
    }

    virtual public void NextCard()
    {
        if(_canPressed)
        {
            _canPressed = false;
            if (_iterations == _amountOfSelectingCards)
            {
                EndOfCards();
            }
            else
            {
                StartCoroutine(DelayBeforeNextCard());
                _randomCurentObjIndex = GetRandomIndex();
                SelectedIndex.Add(_randomCurentObjIndex);
                _iterations++;
                _audioSource.PlayOneShot(AnimalAudios[_randomCurentObjIndex]);
                _animalSpriteButton.sprite = AnimalSprites[_randomCurentObjIndex];
            }
        }
    }

    IEnumerator DelayBeforeNextCard()
    {
        yield return new WaitForSeconds(Delay);
        _canPressed = true;
    }

    protected virtual void EndOfCards()
    {
        NextCardPanel.SetActive(false);
        QuizPanel.SetActive(true);
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
