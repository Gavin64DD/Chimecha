using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] List<Card> mech = new List<Card>();
    public int totalHP = Random.Range(10, 30);
    public int totalAttack = Random.Range(1, 5);
    public int totalSpeed = Random.Range(1, 3);


<<<<<<< Updated upstream
=======
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
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
