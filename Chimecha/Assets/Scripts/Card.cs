using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Card : MonoBehaviour
{
    public Camera mainCamera;
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
    [SerializeField] protected int attack;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int maxCooldown;
    [SerializeField] public int cooldown;
    [SerializeField] public bool hasSpecial;
    public bool isGrowable;
    public bool isGrown;
    public bool selected;
    public bool isTurn;
    [SerializeField] protected TMP_Text healthText;
    [SerializeField] protected TMP_Text attackText;
    [SerializeField] protected TMP_Text speedText;
    [SerializeField] CardTier tier = CardTier.Average;
    [SerializeField] BodyPart bodyPart = BodyPart.Torso;
    public SpriteRenderer spriteRenderer;
    [SerializeField] Card[] playerDeck;
    [SerializeField] public Color baseColor;
    [SerializeField] public Color baseOffColor;


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
    virtual public void Start()
    {
        baseColor = Color.white;
        baseOffColor = Color.gray;
        mainCamera = Camera.main;
        isGrowable = true;
        isGrown = false;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    virtual public void SpecialAbility()
    {
        if (cooldown != 0)
        {

        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D mouseHit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (mouseHit.collider.gameObject != null && mouseHit.collider.gameObject == this.gameObject)
            {
                if (isGrowable)
                {
                    HandleRightClick();
                }
            }
        }
    }
    virtual public void AdjustHealth(int adjustment)
    {
        health += adjustment;
        if (health <= 0)
        {
            this.transform.parent.transform.parent.GetComponent<Player>().mech.Remove(this);
            Destroy(this.gameObject);
        }
        if(health > maxHealth)
        {
            health = maxHealth;
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
                            card.spriteRenderer.color = baseColor;
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
                        card.spriteRenderer.color = baseColor;
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
    public void HandleRightClick()
    {
        Debug.Log($"{this.name} Right Clicked");
        if (isGrowable)
        {
            StartCoroutine(GrowCard());
        }
    }

    IEnumerator GrowCard()
    {
        isGrowable = false;

        if (!isGrown)
        {
            spriteRenderer.sortingLayerName = "Top";
            float now = Time.time;
            while (Time.time - now < .5f)
            {
                float t = (Time.time - now) / .5f;
                transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1.5f, 1.5f, 1.5f), t);
                yield return null;
            }
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            isGrown = true;
        }
        else
        {
            float now = Time.time;
            while (Time.time - now < .5f)
            {
                float t = (Time.time - now) / .5f;
                transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1.5f), new Vector3(1, 1, 1), t);
                yield return null;
            }
            transform.localScale = new Vector3(1, 1, 1);
            isGrown = false;
            spriteRenderer.sortingLayerName = "Default";
        }
        isGrowable = true;
    }
    public void DisableCard()
    {
        this.enabled = false;
        this.spriteRenderer.color = Color.gray;
    }
}
