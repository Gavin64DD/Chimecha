using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public List<Card> mech;


    public int totalHP;
    public int totalAttack;
    public int totalSpeed;

    private void OnEnable()
    {
        
    }
    private void Awake()
    {
        Card[] cards = GetComponentsInChildren<Card>();
        foreach(Card card in cards)
        {
            mech.Add(card);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        int speedSum = 0;
        foreach (Card card in mech)
        {
            speedSum += card.Speed;
        }
        totalSpeed = speedSum;
 
    }

    // Update is called once per frame
    void Update()
    {

    }
}

