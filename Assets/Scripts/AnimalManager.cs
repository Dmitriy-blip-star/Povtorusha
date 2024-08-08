using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public SpriteRenderer[] animalSpriteButtons;
    public PreAnimalQuiz animal; // Предполагается, что у вас есть класс Animal с массивами animalSprites и selectedIndex
    private List<int> availableIndices = new List<int>();

    void Start()
    {
        // Инициализация списка доступных индексов
        for (int i = 0; i < animal.SelectedIndex.Count; i++)
        {
            availableIndices.Add(i);
        }

        // Установка спрайтов
        for (int i = 0; i < animalSpriteButtons.Length; i++)
        {
            int randomIndex = GetRandomIndex();
            animalSpriteButtons[i].sprite = animal.AnimalSprites[animal.SelectedIndex[randomIndex]];
        }
    }

    int GetRandomIndex()
    {
        if (availableIndices.Count == 0)
        {
            Debug.LogWarning("Все индексы уже использованы!");
            return -1; // Возвращаем -1, если все индексы использованы
        }

        int randomIndex = Random.Range(0, availableIndices.Count);
        int selectedIndex = availableIndices[randomIndex];
        availableIndices.RemoveAt(randomIndex); // Удаляем использованный индекс из списка
        return selectedIndex;
    }
}
