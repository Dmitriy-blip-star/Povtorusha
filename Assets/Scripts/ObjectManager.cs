using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] initialObjects; // Начальный массив объектов
    private GameObject[] currentObjects; // Текущий массив объектов
    private int remainingObjects; // Количество оставшихся объектов

    private void Start()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        // Инициализация начального массива объектов
        //initialObjects = new GameObject[4];
        // Заполните начальный массив своими объектами
        currentObjects = new GameObject[initialObjects.Length];
        System.Array.Copy(initialObjects, currentObjects, initialObjects.Length);
        remainingObjects = currentObjects.Length;
    }

    public void OnObjectSelected(int index)
    {
        // Обработка выбора объекта игроком
        if (index >= 0 && index < currentObjects.Length && currentObjects[index] != null)
        {
            // Уберите выбранный объект из текущего массива
            GameObject selectedObject = currentObjects[index];
            currentObjects[index] = null;
            remainingObjects--;

            // Создайте новые объекты из оставшихся в текущем массиве
            SpawnNewObjects();
        }
    }

    private void SpawnNewObjects()
    {
        if (remainingObjects > 0)
        {
            // Выберите случайный объект из оставшихся в текущем массиве
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, currentObjects.Length);
            } while (currentObjects[randomIndex] == null);

            GameObject newObject = currentObjects[randomIndex];

            // Создайте новый объект на сцене
            Instantiate(newObject, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("No more objects to spawn!");
            // Восстановите текущий массив объектов к начальному состоянию
            System.Array.Copy(initialObjects, currentObjects, initialObjects.Length);
            remainingObjects = currentObjects.Length;
        }
    }
}
