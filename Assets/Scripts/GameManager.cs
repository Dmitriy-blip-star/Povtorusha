using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public List<MemoryCard> cards; // Список карточек в игре
    private int pairsFound = 0;

    [SerializeField] GameObject winPanel;

    public static GameManager instance;

    private void Start()
    {
        instance = this;
    }
    public void WinCheck()
    {
        pairsFound++;
        Debug.Log("Найдено пар: " + pairsFound);
        // Проверяем условие победы
        if (pairsFound >= cards.Count / 2) // Предполагаем, что каждая пара состоит из 2 карточек
        {
            WinGame();
        }
    }
    // Метод для обработки выигрыша
    private void WinGame()
    {
        Debug.Log("Поздравляем! Вы выиграли!");
        winPanel.SetActive(true);
    }
}
