using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCard : MonoBehaviour
{
    [SerializeField] bool isPlayer1;
    List<Player> playerList;
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
        }
        else
        {
            target = playerList[0];
            player = playerList[1];
        }
        set = true;
        startingHP = player.totalHP;
    }

    public void Attack(){
        setPlayers();
        int dodge = Random.Range(1, 10);
        if(dodge > target.totalSpeed){
            target.totalHP = target.totalHP - player.totalAttack;
        }
        if (target.totalHP < 0) target.totalHP = 0;
    }

    public void Heal() {
        setPlayers();
        player.totalHP = player.totalHP + Random.Range(1, 5);
        if (player.totalHP > startingHP) player.totalHP = startingHP;
    }
}
