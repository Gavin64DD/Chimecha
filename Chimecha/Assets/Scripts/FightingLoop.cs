using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightingLoop : MonoBehaviour
{
    int numOfPlayers;
    int currentPlayer;
    public List<Player> playerList;
    [SerializeField] Text player1Health;
    [SerializeField] Text player2Health;
    [SerializeField] Text player1Attack;
    [SerializeField] Text player2Attack;
    [SerializeField] Text player1Speed;
    [SerializeField] Text player2Speed;
    [SerializeField] public Button player1AttackButton;
    [SerializeField] public Button player1HealButton;
    [SerializeField] public Button player2AttackButton;
    [SerializeField] public Button player2HealButton;
    // Start is called before the first frame update
    void Start()
    {
        numOfPlayers = 2;
        currentPlayer = 1;

        //Temporary loop that automatically gives each player 4 sets of random cards
        for (int i = 0; i < 2; i++)
        {
            Player tempPlayer = new Player();
            playerList.Add(tempPlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
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

    //Will display all cards that the current player has
    void newTurn()
    {
        /*foreach(Card card in playerList[currentPlayer])
        {

        }*/
    }
}
