using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] List<Card> mech;
    
    public int totalHP = Random.Range(10, 30);
    public int totalAttack = Random.Range(1, 5);
    public int totalSpeed = Random.Range(1, 3);


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
