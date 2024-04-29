using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hot : Card
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        attack = 2;
        attackText.text = "2";
        health = 9;
        maxHealth = health;
        healthText.text = "9";
        maxCooldown = 0;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void SpecialAbility()
    {
        Card[] allCards = FindObjectsOfType<Card>();
        foreach (Card card in allCards)
        {
            Debug.Log($"Found {card.name}");
            int roll = (int)Random.Range(1, 10) + 1;
            Debug.Log(roll);
            if(roll == 10)
            {
                int newRoll = (int)Random.Range(1, 3) + 1;
                if(newRoll == 2)
                {
                    card.baseColor = Color.red;
                    card.baseOffColor = new Color(.155f, 0, .1f);
                }
                else
                {
                    card.baseColor = Color.yellow;
                    card.baseOffColor = new Color(.155f, .155f, 0);
                }
                return;
            }
        }
        cooldown = maxCooldown;
    }
}
