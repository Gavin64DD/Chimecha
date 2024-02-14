using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingLoop : MonoBehaviour
{
    int numOfPlayers;
    int currentPlayer;
    bool waiting;
    List<List<Card>> cardLists;

    // Start is called before the first frame update
    void Start()
    {
        numOfPlayers = 4;
        waiting = true;
        currentPlayer = 1;

        //Temporary loop that automatically gives each player 4 sets of random cards
        for (int i = 0; i < numOfPlayers; i++)
        {
            for (int j = 0; j < 6; j++)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting) return;


    }
}
