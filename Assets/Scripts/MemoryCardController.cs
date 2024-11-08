using System.Collections;
using UnityEngine;
public class MemoryCardController : MonoBehaviour
{
    private MemoryCard firstCard; // Первая перевернутая карточка
    private bool isFirstCard; // Флаг для отслеживания первой карточки
    private bool canFlip; // Флаг, позволяющий переворачивать карточки
    private void Awake()
    {
        canFlip = true; // Изначально можно переворачивать карточки
    }
    public void Click(MemoryCard card)
    {
        if (!canFlip || card.IsFlipped)
        {
            Debug.Log("Card already flipped or cannot flip now.");
            return; // Игнорировать, если карточка уже перевернута или нельзя переворачивать
        }
        card.Flip(); // Перевернуть карточку
        if (!isFirstCard)
        {
            isFirstCard = true;
            firstCard = card; // Запомнить первую карточку
        }
        else
        {
            // Это вторая перевернутая карточка
            canFlip = false; // Запретить переворот новых карточек
            if (firstCard.CompareTo(card)) // Проверить на совпадение
            {
                Debug.Log("Match found!");
                // Здесь можно добавить логику для обработки совпадения
                canFlip = true; // Разрешить переворот карточек
                GameManager.instance.WinCheck(); 
            }
            else
            {
                Debug.Log("No match, flipping back...");
                StartCoroutine(FlipBack(firstCard, card)); // Перевернуть карточки обратно
            }
            // Сбросить состояние первой карточки
            isFirstCard = false;
            firstCard = null;
        }
    }
    private IEnumerator FlipBack(MemoryCard card1, MemoryCard card2)
    {
        yield return new WaitForSeconds(0.5f); // Задержка перед переворотом обратно
        card1.Unflip(); // Перевернуть первую карточку обратно
        card2.Unflip(); // Перевернуть вторую карточку обратно
        canFlip = true; // Разрешить переворот карточек
    }
}
