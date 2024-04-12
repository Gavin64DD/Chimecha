using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightingLoop : MonoBehaviour
{
    int numOfPlayers;
    int currentPlayer;
    public List<Player> playerList;
    public GameObject player1tint;
    public GameObject player2tint;
    public bool player1Turn;
    bool cardSelected;
    Card currentSelected;
    [SerializeField] TMP_Text statusText;
    public GameObject resetButton;
    // Start is called before the first frame update
    void Start()
    {
        numOfPlayers = 2;
        currentPlayer = 1;

        player1Turn = true;
        foreach(Player player in playerList)
        {
            foreach(Card card in player.mech)
            {
                card.OnTurnChange += newTurn;
                card.OnAttacked += handleAttacks;
            }
        }
        foreach(Card card in playerList[0].mech)
        {
            card.isTurn = true;
        }
        AdjustText();
    }

    // Update is called once per frame
    void Update()
    {
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
        /*if (waiting) return;
        else{
            newTurn();
            if (currentPlayer == numOfPlayers) currentPlayer = 1;
            else currentPlayer++;
        }*/
    }

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
    
    //Will display all cards that the current player has
    void newTurn()
    {
        player1Turn = !player1Turn;
        AdjustText();
        foreach (Player player in playerList)
        {
            foreach (Card card in player.mech)
            {
                card.isTurn = !card.isTurn;
                card.selected = false;
                if(card.isTurn)
                {
                    card.enabled = true;
                    card.spriteRenderer.color = Color.white;
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
        if(loser == playerList[0])
        {
            statusText.text = "Player 2 wins!";
        }
        else
        {
            statusText.text = "Player 1 wins!";
        }
    }
}
