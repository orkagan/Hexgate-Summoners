using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variable;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class CardBase : ScriptableObject
{
    //name
    public String title;
    //desciption
    public String description;
    //icon
    public SpriteImage icon;
    //background
    public SpriteImage background;
    //cost
    public int cost;

    //attack
    public int attack;
    //health
    public int health;
}
