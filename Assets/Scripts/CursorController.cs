using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D customCursor; // Перетащите сюда вашу текстуру курсора в инспекторе
    public Vector2 hotspot = new Vector2(16, 16); // Точка, которая будет использоваться как "горячая" точка курсора


    void Start()
    {
        // Установить пользовательский курсор
        Cursor.SetCursor(customCursor, hotspot, CursorMode.Auto);
    }

    void OnDisable()
    {
        // Вернуть стандартный курсор при отключении скрипта
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
