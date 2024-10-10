using UnityEngine;

public class PreQuizChangeCardsPart : CardChanger
{
    [SerializeField] private GameObject _quizPanel;
    [SerializeField] private GameObject _nextCardPanel;
    protected override void EndOfCards()
    {
        _nextCardPanel.SetActive(false);
        _quizPanel.SetActive(true);
    }
}
