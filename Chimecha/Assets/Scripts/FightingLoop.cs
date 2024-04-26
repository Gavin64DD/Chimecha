using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightingLoop : MonoBehaviour
{
    int numOfPlayers;
    int currentPlayer;
    bool waiting;
    public List<Player> playerList;
<<<<<<< Updated upstream
    [SerializeField] Text player1Health;
    [SerializeField] Text player2Health;
    [SerializeField] Text player1Attack;
    [SerializeField] Text player2Attack;
    [SerializeField] Text player1Speed;
    [SerializeField] Text player2Speed;

=======
    public GameObject player1tint;
    public GameObject player2tint;
    public bool player1Turn;
    bool cardSelected;
    Card currentSelected;
    [SerializeField] TMP_Text statusText;
    public GameObject resetButton;
    public SpecialButton specialButton;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        numOfPlayers = 2;
        waiting = false;
        currentPlayer = 1;

        //Temporary loop that automatically gives each player 4 sets of random cards
        for (int i = 0; i < 2; i++)
        {
            Player tempPlayer = new Player();
            playerList.Add(tempPlayer);
        }
<<<<<<< Updated upstream
=======
        foreach(Card card in playerList[0].mech)
        {
            card.isTurn = true;
        }
        AdjustText();
        specialButton.OnPressed += SpecialHit;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        if(cardSelected)
        {
            if(player1Turn)
            {
                SetCardsActive(playerList[1]);
                player2tint.SetActive(false);
                foreach (Card card in playerList[0].mech)
                {
                    if (card.selected)
                    {
                        if(card.hasSpecial)
                        {
                            if(card.cooldown == 0)
                            {
                                specialButton.GetComponent<SpecialButton>().enabled = true;
                                specialButton.GetComponent<BoxCollider>().enabled = true;
                                specialButton.image.color = Color.green;
                            }
                            else
                            {
                                specialButton.GetComponent<SpecialButton>().enabled = false;
                                specialButton.GetComponent<BoxCollider>().enabled = false;
                                specialButton.image.color = new Color(.25f, .45f, .25f);
                            }
                            return;
                        }
                        specialButton.GetComponent<SpecialButton>().enabled = false;
                        specialButton.GetComponent<BoxCollider>().enabled = false;
                        specialButton.image.color = new Color(.15f, .15f, .25f);
                        return;
                    }
                }
                cardSelected = false;
                currentSelected = null;
                return;
            }
            else
            {
                SetCardsActive(playerList[0]);
                player1tint.SetActive(false);
                foreach (Card card in playerList[1].mech)
                {
                    if (card.selected)
                    {
                        if (card.hasSpecial)
                        {
                            if (card.cooldown == 0)
                            {
                                specialButton.GetComponent<SpecialButton>().enabled = true;
                                specialButton.GetComponent<BoxCollider>().enabled = true;
                                specialButton.image.color = Color.green;
                            }
                            else
                            {
                                specialButton.GetComponent<SpecialButton>().enabled = false;
                                specialButton.GetComponent<BoxCollider>().enabled = false;
                                specialButton.image.color = new Color(.25f, .45f, .25f);
                            }
                            return;
                        }
                        specialButton.GetComponent<SpecialButton>().enabled = false;
                        specialButton.GetComponent<BoxCollider>().enabled = false;
                        specialButton.image.color = new Color(.15f, .15f, .25f);
                        return;
                    }
                }
                currentSelected = null;
                cardSelected = false;
                return;
            }
        }
        else
        {
            specialButton.GetComponent<SpecialButton>().enabled = false;
            specialButton.GetComponent<BoxCollider>().enabled = false;
            specialButton.image.color = new Color(.15f, .15f, .25f);
            if (player1Turn)
            {
                player1tint.SetActive(false);
                player2tint.SetActive(true);
                foreach (Card card in playerList[1].mech)
                {
                    card.DisableCard();
                }
                foreach (Card card in playerList[0].mech)
                {
                    if (card.selected)
                    {
                        currentSelected = card;
                        cardSelected = true;
                    }
                }
            }
            else
            {
                foreach (Card card in playerList[0].mech)
                {
                    card.DisableCard();
                }
                foreach (Card card in playerList[1].mech)
                {
                    if (card.selected)
                    {
                        currentSelected = card;
                        cardSelected = true;
                    }
                }
                player1tint.SetActive(true);
                player2tint.SetActive(false);
            }
        }

        foreach (Player player in playerList)
        {
            if (player.mech.Count == 0)
            {
                EndGame(player);
            }
        }
>>>>>>> Stashed changes
        /*if (waiting) return;
        else{
            newTurn();
            if (currentPlayer == numOfPlayers) currentPlayer = 1;
            else currentPlayer++;
        }*/

        player1Health.text = "Health: " + playerList[0].totalHP;
        player2Health.text = "Health: " + playerList[1].totalHP;
        player1Attack.text = "Attack: " + playerList[0].totalAttack;
        player2Attack.text = "Attack: " + playerList[1].totalAttack;
        player1Speed.text = "Speed: " + playerList[0].totalSpeed;
        player2Speed.text = "Speed: " + playerList[1].totalSpeed;
    }

<<<<<<< Updated upstream
=======
    private void SetCardsActive(Player play)
    {
        foreach(Card card in play.mech)
        {
            card.enabled = true;
            card.isTurn = false;
        }
    }

    void handleAttacks(Card card)
    {
        card.AdjustHealth(currentSelected.Attack * -1);
    }
    

    void UseSpecial(Card card)
    {
        card.SpecialAbility();
        newTurn();
    }

    void SpecialHit()
    {
        UseSpecial(currentSelected);
    }
>>>>>>> Stashed changes
    //Will display all cards that the current player has
    void newTurn()
    {
        /*foreach(Card card in playerList[currentPlayer])
        {
<<<<<<< Updated upstream

        }*/
=======
            foreach (Card card in player.mech)
            {
                card.isTurn = !card.isTurn;
                card.selected = false;
                if(card.cooldown != 0)
                {
                    card.cooldown -= 1;
                }
                if(card.isTurn)
                {
                    card.enabled = true;
                    card.spriteRenderer.color = card.baseColor;
                }
            }
        }
    }
    void AdjustText()
    {
        if(player1Turn)
        {
            statusText.text = "Player 1's Turn";
        }
        else
        {
            statusText.text = "Player 2's Turn";
        }
    }
    void EndGame(Player loser)
    {
        resetButton.SetActive(true);
        specialButton.gameObject.SetActive(false);
        if (loser == playerList[0])
        {
            statusText.text = "Player 2 wins!";
        }
        else
        {
            statusText.text = "Player 1 wins!";
        }
>>>>>>> Stashed changes
    }
}
