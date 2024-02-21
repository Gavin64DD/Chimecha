using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCard : MonoBehaviour
{
    [SerializeField] bool isAttack;
    [SerializeField] bool isHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack) Attack();
        else if (isHealth) Heal();
    }

    void Attack(){

    }

    void Heal(){

    }
}
