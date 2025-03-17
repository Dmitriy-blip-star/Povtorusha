using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] public AnimalCardSO Card;

    private Image image; // Компонент Image для отображения спрайта
    private bool isFlipped = false; // Состояние переворота карточки, теперь хранится в самом объекте

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Метод для переворота карточки
    public void Flip()
    {
        if (isFlipped) return; // Игнорировать, если карточка уже перевернута
        image.sprite = Card.Sprite; // Показать лицевую сторону
        isFlipped = true; // Установить состояние перевернутой карточки
    }

    // Метод для сравнения карточек
    public bool CompareTo(MemoryCard otherCard)
    {
        return Card.Sprite == otherCard.Card.Sprite; // Сравнить спрайты
    }

    // Метод для переворота карточки обратно
    public void Unflip()
    {
        image.sprite = Card.BackSprite; // Скрыть спрайт (или использовать спрайт задней стороны)
        isFlipped = false; // Установить состояние карточки как не перевернутое
    }

    // Свойство для доступа к состоянию переворота
    public bool IsFlipped
    {
        get { return isFlipped; }
    }
}
