using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCard : MonoBehaviour
{
    [SerializeField] bool isPlayer1;
    [SerializeField] FightingLoop loop;
    Player attackTarget;
    Player player;
    int attackValue;
    int healValue;

    // Start is called before the first frame update
    void Start()
    {
        attackValue = Random.Range(1, 10);
        healValue = Random.Range(1, 10);
        if (isPlayer1){
            attackTarget = loop.playerList[1];
            player = loop.playerList[0];
        }
        else{
            attackTarget = loop.playerList[0];
            player = loop.playerList[1];
        }
    }

    public void Attack(int value, Player target, Player player){
        int dodge = Random.Range(1, 10);
        if(dodge > target.totalSpeed){
            target.totalHP -= value * player.totalAttack;
        }
    }

    public void Heal(int value, Player target) {
        target.totalHP += value * player.totalAttack;
    }
}
