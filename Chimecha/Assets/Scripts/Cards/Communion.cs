using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communion : Card
{
    public bool underProtection;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        attack = 0;
        attackText.text = "2";
        health = 9;
        maxHealth = health;
        healthText.text = "9";
        maxCooldown = 2;
        cooldown = 0;
        underProtection = false;
    }

    public override void SpecialAbility()
    {
        underProtection = true;
        cooldown = 2;
    }

    public override void AdjustHealth(int adjustment)
    {
        if(underProtection && adjustment < 0)
        {
            adjustment /= 2;
        }
        health += adjustment;
        if (health <= 0)
        {
            this.transform.parent.transform.parent.GetComponent<Player>().mech.Remove(this);
            Destroy(this.gameObject);
        }
        healthText.text = $"{health}";
        underProtection = false;
    }
}
