using UnityEngine;
public class MemoryCardShuffler : MonoBehaviour
{
    [SerializeField] private Transform[] cards; // Массив трансформов карточек, который нужно перемешать
    private void Start()
    {
        Shuffle(); // Перемешивание карточек при запуске игры
    }
    private void Shuffle()
    {
        if (cards.Length == 0)
        {
            Debug.LogWarning("Массив карточек пуст!");
            return;
        }
        Debug.Log("Перемешивание карточек...");
        ShuffleArray(cards); // Перемешать карточки
        Debug.Log("Карточки перемешаны!");
    }
    // Метод для случайного перемешивания массива трансформов карточек
    private void ShuffleArray(Transform[] cardArray)
    {
        for (int i = 0; i < cardArray.Length; i++)
        {
            // Генерируем случайный индекс
            int randomIndex = Random.Range(0, cardArray.Length);
            // Меняем местами трансформы
            Transform temp = cardArray[i];
            cardArray[i] = cardArray[randomIndex];
            cardArray[randomIndex] = temp;
            // Обновляем порядок объектов в иерархии
            cardArray[i].SetSiblingIndex(i);
            cardArray[randomIndex].SetSiblingIndex(randomIndex);
        }
    }
}
