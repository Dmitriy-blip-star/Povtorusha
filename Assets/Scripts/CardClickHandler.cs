using UnityEngine;
using UnityEngine.EventSystems;
public class CardClickHandler : MonoBehaviour, IPointerClickHandler
{
    private MemoryCardController controller;
    private MemoryCard memoryCard;
    private void Awake()
    {
        controller = FindObjectOfType<MemoryCardController>();
        memoryCard = GetComponent<MemoryCard>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        controller.Click(memoryCard);
    }
}
