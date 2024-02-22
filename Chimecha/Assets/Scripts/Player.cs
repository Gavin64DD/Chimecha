using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] List<Card> mech = new List<Card>();
    public int totalHP = 0;
    public int totalAttack = 0;
    public int totalSpeed = 0;


    // Start is called before the first frame update
    void Start()
    {
        totalHP = Random.Range(10, 30);
        totalAttack = Random.Range(1, 5);
        totalSpeed = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
