using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Variable;

public class CardDisplay : MonoBehaviour
{
    [Header("Card Type")]
    public CardBase card;

    //UI Connections
    [Header("Sprites")]
    public Image iconImage, backgroundImage;

    [Header("Text")]
    public Text nameText, descriptionText, costText, attackText, healthText;
    private void OnEnable()
    {
        nameText.text = card.title;

        iconImage.sprite = card.icon;
        backgroundImage.sprite = card.background;

        descriptionText.text = card.description;
        costText.text = card.cost.ToString();
        healthText.text = card.health.ToString();
        attackText.text = card.attack.ToString();
    }
}
