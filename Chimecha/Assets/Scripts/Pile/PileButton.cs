using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileButton : MonoBehaviour
{
    bool clicked = false;
    public void ButtonClicked()
    {
        if (clicked) return;
        Debug.Log("Clicked");
        this.GetComponentInParent<AssignCards>().StartDistribution();
        clicked = true;
    }
}
