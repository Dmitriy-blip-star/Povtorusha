using UnityEngine;
using UnityEngine.UI;
public class MemoryCardNew : MonoBehaviour
{
    [SerializeField] private Sprite frontSprite; // Спрайт лицевой стороны карточки
    private Image image; // Компонент Image для отображения спрайта
    private Sprite backSprite;
    public bool IsFlipped { get; private set; } // Свойство для отслеживания состояния карточки
    [SerializeField] public AudioClip AudioClip;
    private void Awake()
    {
        image = GetComponent<Image>();
        backSprite = image.sprite;

    }
    // Метод для переворота карточки
    public void Flip()
    {
        if (IsFlipped) return; // Игнорировать, если карточка уже перевернута
        image.sprite = frontSprite; // Показать лицевую сторону
        IsFlipped = true; // Установить состояние перевернутой карточки

    }
    // Метод для сравнения карточек
    public bool CompareTo(MemoryCardNew otherCard)
    {
        return frontSprite == otherCard.frontSprite; // Сравнить спрайты
    }
    // Метод для переворота карточки обратно
    public void Unflip()
    {
        image.sprite = backSprite; // Скрыть спрайт (или использовать спрайт задней стороны)
        IsFlipped = false; // Установить состояние карточки как не перевернутое
    }
}
