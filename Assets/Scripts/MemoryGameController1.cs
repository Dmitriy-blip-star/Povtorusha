using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController1 : MonoBehaviour
{
    public List<Sprite> cardImages; // Список изображений для карт public GameObject cardPrefab; // Префаб карты
    public Transform gridParent; // Родительский объект для размещения карт private List<GameObject> cards = new List<GameObject>();
    private GameObject firstFlippedCard;
    private GameObject secondFlippedCard;
    private bool canFlip = true;

    //void Start()
    //{
    //    InitializeCards();
    //}

    //void InitializeCards()
    //{
    //    List<Sprite> images = new List<Sprite>(cardImages);
    //    images.AddRange(cardImages); // Дублируем список для пар for (int i = 0; i < images.Count; i++)
    //    {
    //        int randomIndex = Random.Range(0, images.Count);
    //        Sprite image = images[randomIndex];
    //        images.RemoveAt(randomIndex);

    //        GameObject card = Instantiate(cardPrefab, gridParent);
    //        card.GetComponent<MemoryCard>().Initialize(image, this);
    //        cards.Add(card);
    //    }
    //}

    public void CardFlipped(GameObject card)
    {
        if (!canFlip) return;

        if (firstFlippedCard == null)
        {
            firstFlippedCard = card;
        }
        else if (secondFlippedCard == null)
        {
            secondFlippedCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        canFlip = false;

        yield return new WaitForSeconds(1f);

        if (firstFlippedCard.GetComponent<MemoryCard1>().CardImage == secondFlippedCard.GetComponent<MemoryCard1>().CardImage)
        {
            Destroy(firstFlippedCard);
            Destroy(secondFlippedCard);
        }
        else
        {
            firstFlippedCard.GetComponent<MemoryCard1>().FlipBack();
            secondFlippedCard.GetComponent<MemoryCard1>().FlipBack();
        }

        firstFlippedCard = null;
        secondFlippedCard = null;
        canFlip = true;
    }
}
