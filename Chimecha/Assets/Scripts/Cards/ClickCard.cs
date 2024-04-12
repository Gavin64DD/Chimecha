using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCard : MonoBehaviour
{
    [SerializeField] Text turnIndicator;
    [SerializeField] bool isPlayer1;
    [SerializeField] List<Player> playerList;
    Player target;
    Player player;
    int startingHP;
    int attackValue;
    int healValue;
    bool set = false;
    // Start is called before the first frame update
    void Start()
    {
        attackValue = Random.Range(1, 10);
        healValue = Random.Range(1, 10);
    }

    void setPlayers()
    {
        if (set) return;

        playerList = GameObject.Find("Main Camera").GetComponent<FightingLoop>().playerList;
        if (isPlayer1)
        {
            target = playerList[1];
            player = playerList[0];
            startingHP = playerList[0].totalHP; 
        }
        else
        {
            target = playerList[0];
            player = playerList[1];
            startingHP = playerList[1].totalHP;
        }
        set = true;
        
    }

    public void Attack(){
        setPlayers();
        int dodge = Random.Range(1, 10);
        if(dodge > target.totalSpeed){
            target.totalHP = target.totalHP - player.totalAttack;
        }
        if (target.totalHP < 0) target.totalHP = 0;
        if(isPlayer1)
        {   
            turnIndicator.text = "It is currently Player 2's turn.";
        }
        else
        {
            turnIndicator.text = "It is currently Player 1's turn.";
        }
    }

    public void Heal() {
        Debug.Log("Healing");
        setPlayers();
        player.totalHP = player.totalHP + Random.Range(1, 5);
        if (player.totalHP > startingHP) player.totalHP = startingHP;
        if (isPlayer1)
        {
            turnIndicator.text = "It is currently Player 2's turn.";
        }
        else
        {
            turnIndicator.text = "It is currently Player 1's turn.";
        }
    }
}
