using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Transform hand;
    public CardBase[] cards;
    public GameObject cardPrefab;
    public int handSize = 5;

    private void Start()
    {
        //for (int i = 0; i < cards.Length; i++)
        for (int i = 0; i < handSize; i++)
        {
            GameObject cardClone = Instantiate(cardPrefab, hand);
            cardClone.GetComponent<CardDisplay>().card = cards[Random.Range(0, cards.Length)];
            cardClone.SetActive(true);
        }
    }
}
