using UnityEngine;
using UnityEngine.UI;

public class MemoryCard1 : MonoBehaviour
{
    Image frontImage;
    public Button cardButton;

    private Sprite cardImage;
    MemoryGameController1 memoryGameController;
    private bool isFlipped = false;

    public Sprite CardImage => cardImage;
    private void Start()
    {
        memoryGameController = FindObjectOfType<MemoryGameController1>();
        frontImage = GetComponent<Image>();
    }
    public void Initialize(Sprite image)
    {
        cardImage = image;
        cardButton.onClick.AddListener(OnCardClicked);
    }

    private void OnCardClicked()
    {
        if (isFlipped) return;

        isFlipped = true;
        frontImage.enabled = true;
        memoryGameController.CardFlipped(gameObject);
    }

    public void FlipBack()
    {
        isFlipped = false;
        frontImage.enabled = false;
    }
}
