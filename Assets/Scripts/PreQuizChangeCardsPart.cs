using UnityEngine;

public class PreQuizChangeCardsPart : CardChanger
{
    protected override void EndOfCards()
    {
        NextCardPanel.SetActive(false);
        QuizPanel.SetActive(true);
    }
}
