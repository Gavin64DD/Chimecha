using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Card : MonoBehaviour
{
    public delegate void ChangeTurns();
    public event ChangeTurns OnTurnChange;
    public delegate void Attacked(Card sender);
    public event Attacked OnAttacked;

    public enum CardTier
    {
        Junk,
        Eh,
        Average,
        Cool,
        RealSteel
    }
    public enum BodyPart
    {
        Head,
        Arms,
        Torso,
        Legs,
        Weapon
    }
    [SerializeField] int attack;
    [SerializeField] int maxHealth;
    [SerializeField] int health;
    [SerializeField] int speed;
    [SerializeField] int maxCooldown;
    [SerializeField] int cooldown;
    [SerializeField] bool hasSpecial;
    public bool selected;
    public bool isTurn;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text attackText;
    [SerializeField] TMP_Text speedText;
    [SerializeField] CardTier tier = CardTier.Average;
    [SerializeField] BodyPart bodyPart = BodyPart.Torso;
    public SpriteRenderer spriteRenderer;
    [SerializeField] Card[] playerDeck;
    


    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    public int Defense
    {
        get;
        set;
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    private void Awake()
    {
        maxHealth = Random.Range(7, 12);
        attack = Random.Range(1, 5);
        attackText.text = $"{attack}";
        speed = Random.Range(1, 3);
        speedText.text = $"{speed}";
        health = maxHealth;
        healthText.text = $"{health}";
    }
    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void SpecialAbility()
    {
        if (cooldown != 0)
        {

        }
    }
    public void AdjustHealth(int adjustment)
    {
        health += adjustment;
        if (health <= 0)
        {
            this.transform.parent.transform.parent.GetComponent<Player>().mech.Remove(this);
            Destroy(this.gameObject);
        }
        healthText.text = $"{health}";
    }

    private void OnMouseDown()
    {
        if(enabled)
        {
            if (isTurn)
            {
                if (!enabled) return;
                selected = !selected;
                playerDeck = transform.parent.GetComponentsInChildren<Card>();
                if (selected == true)
                {
                    foreach (Card card in playerDeck)
                    {
                        if (card == this)
                        {
                            card.spriteRenderer.color = Color.white;
                        }
                        else
                        {
                            card.DisableCard();
                        }
                    }
                }
                else
                {
                    foreach (Card card in playerDeck)
                    {
                        card.enabled = true;
                        card.spriteRenderer.color = Color.white;
                    }
                }
            }
            else
            {
                OnAttacked(this);
                OnTurnChange();
            }
        }
    }

    public void DisableCard()
    {
        this.enabled = false;
        this.spriteRenderer.color = Color.gray;
    }
}
