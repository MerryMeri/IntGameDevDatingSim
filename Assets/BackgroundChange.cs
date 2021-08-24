using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    public Sprite SupplyCloset;
    public Sprite StudentCenter;
    public Sprite Bus;
    public Sprite Kitchen;
    public Sprite Diner;
    public Sprite Apartment;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void modifyBackground(string background) {
        Debug.Log(background);
        if (background.Contains("SupplyCloset")) {
            sr.sprite = SupplyCloset;
        }
        else if (background.Contains("StudentCenter")) {
            sr.sprite = StudentCenter;
        }
        else if (background.Contains("Bus")) {
            sr.sprite = Bus;
        }
        else if (background.Contains("Kitchen")) {
            sr.sprite = Kitchen;
        }
        else if (background.Contains("Diner")) {
            sr.sprite = Diner;
        }
        else if (background.Contains("Apartment")) {
            sr.sprite = Apartment;
        }
    }
}
