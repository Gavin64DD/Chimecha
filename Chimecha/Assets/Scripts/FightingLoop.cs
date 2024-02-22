using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingLoop : MonoBehaviour
{
    int numOfPlayers;
    int currentPlayer;
    bool waiting;
    public List<Player> playerList;

    // Start is called before the first frame update
    void Start()
    {
        numOfPlayers = 2;
        waiting = false;
        currentPlayer = 1;

        //Temporary loop that automatically gives each player 4 sets of random cards
        for (int i = 0; i < numOfPlayers; i++)
        {
            playerList[i] = new Player();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting) return;
        else{
            newTurn();
            if (currentPlayer == numOfPlayers) currentPlayer = 1;
            else currentPlayer++;
        }
    }

    //Will display all cards that the current player has
    void newTurn()
    {
        /*foreach(Card card in playerList[currentPlayer])
        {

        }*/
    }
}
