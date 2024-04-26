using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public Camera mainCamera;
    public delegate void ChangeTurns();
    public event ChangeTurns OnTurnChange;
    public delegate void Attacked(Card sender);
    public event Attacked OnAttacked;

>>>>>>> Stashed changes
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
        Arm,
        Torso,
        Legs
    }
<<<<<<< Updated upstream
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] int cooldown;
    [SerializeField] CardTier tier = CardTier.Average;
    [SerializeField] BodyPart bodyPart = BodyPart.Torso;
=======
    public Color baseColor = Color.white;
    public Color baseOffColor = Color.gray;
    [SerializeField] bool hasAttack;
    [SerializeField] protected int attack;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int maxCooldown;
    public int cooldown;
    public bool hasSpecial = false; 
    public bool selected;
    public bool isTurn;
    public bool isGrowable;
    public bool isGrown;
    [SerializeField] protected TMP_Text healthText;
    [SerializeField] protected TMP_Text attackText;
    [SerializeField] protected TMP_Text speedText;
    [SerializeField] CardTier tier = CardTier.Average;
    [SerializeField] BodyPart bodyPart = BodyPart.Torso;
    public SpriteRenderer spriteRenderer;
    [SerializeField] Card[] playerDeck;
>>>>>>> Stashed changes

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
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

    public int Attack
    {
        get;
        set;
    }
    public int Defense
    {
        get;
        set;
    }
    public int Speed
    {
<<<<<<< Updated upstream
        get;
        set;
=======
        get { return speed; }
        set { speed = value; }
    }
    private void Awake()
    {
        mainCamera = Camera.main;
        isGrowable = true;
        isGrown = false;
        maxHealth = Random.Range(7, 12);
        attack = Random.Range(1, 5);
        attackText.text = $"{attack}";
        speed = Random.Range(1, 3);
        speedText.text = $"{speed}";
        health = maxHealth;
        healthText.text = $"{health}";
        cooldown = 0;
    }
    virtual public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
>>>>>>> Stashed changes
    }
    virtual public void SpecialAbility()
    {
        if (cooldown != 0)
        {

        }
    }
<<<<<<< Updated upstream
=======
    virtual public void AdjustHealth(int adjustment)
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
                            card.spriteRenderer.color = card.baseColor;
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
                        card.spriteRenderer.color = card.baseColor;
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
        if(isGrowable)
        {
            StartCoroutine(GrowCard());
        }
    }

    IEnumerator GrowCard()
    {
        isGrowable = false;
        
        if(!isGrown)
        {
            spriteRenderer.sortingLayerName = "Top";
            float now = Time.time;
            while(Time.time - now < .5f)
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
        this.spriteRenderer.color = baseOffColor;
    }
>>>>>>> Stashed changes
}
