using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardTier
    {
        Junk,
        Eh,
        Average,
        Cool,
        RealSteel
    }
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] CardTier tier = CardTier.Average;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void SpecialAbility()
    {

    }
}
