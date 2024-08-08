using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public SpriteRenderer[] animalSpriteButtons;
    public PreAnimalQuiz animal; // ��������������, ��� � ��� ���� ����� Animal � ��������� animalSprites � selectedIndex
    private List<int> availableIndices = new List<int>();

    void Start()
    {
        // ������������� ������ ��������� ��������
        for (int i = 0; i < animal.SelectedIndex.Count; i++)
        {
            availableIndices.Add(i);
        }

        // ��������� ��������
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
            Debug.LogWarning("��� ������� ��� ������������!");
            return -1; // ���������� -1, ���� ��� ������� ������������
        }

        int randomIndex = Random.Range(0, availableIndices.Count);
        int selectedIndex = availableIndices[randomIndex];
        availableIndices.RemoveAt(randomIndex); // ������� �������������� ������ �� ������
        return selectedIndex;
    }
}
