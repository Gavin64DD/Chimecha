using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IED : Card
{
    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();
        attack = 0;
        attackText.text = "0";
        health = 14;
        maxHealth = health;
        healthText.text = "14";
    }

    override public void SpecialAbility()
    {
        Card[] allCards = FindObjectsOfType<Card>();
        foreach(Card card in allCards)
        {
            card.AdjustHealth(((int) Random.Range(1, 6) + 1) * -1);
        }
        this.transform.parent.transform.parent.GetComponent<Player>().mech.Remove(this);
        Destroy(this.gameObject);
    }
}
