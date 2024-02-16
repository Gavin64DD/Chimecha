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
    public enum BodyPart
    {
        Head,
        Arm,
        Torso,
        Legs
    }
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] int cooldown;
    [SerializeField] CardTier tier = CardTier.Average;
    [SerializeField] BodyPart bodyPart = BodyPart.Torso;


    public int Attack
    {
        get;
        set;
    }
    public int Defense
    {
        get;
        set;
    }
    public int Speed
    {
        get;
        set;
    }
    public void SpecialAbility()
    {
        if (cooldown != 0)
        {

        }
    }
}
