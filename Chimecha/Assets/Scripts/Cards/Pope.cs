using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pope : Card
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        attack = 3;
        attackText.text = "3";
        health = 14;
        maxHealth = health;
        healthText.text = "14";
        maxCooldown = 3;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void SpecialAbility()
    {
        Card[] deckCards = transform.parent.GetComponentsInChildren<Card>();
        foreach(Card card in deckCards)
        {
            card.AdjustHealth(3);
        }
        cooldown = maxCooldown;
    }
}
