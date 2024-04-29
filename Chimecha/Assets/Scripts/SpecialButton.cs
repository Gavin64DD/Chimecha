using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpecialButton : MonoBehaviour
{
    public delegate void Pressed();
    public event Pressed OnPressed;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log("hi");
        OnPressed();
    }
}
