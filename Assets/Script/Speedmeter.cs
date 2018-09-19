using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedmeter : MonoBehaviour
{
    public Rigidbody voiture;
    public Text Speedmeterui;
    private double Speed;

    void Update()
    {
        Speed = (voiture.velocity.magnitude * 3.6);

        Speedmeterui.text = ""+Speed.ToString("F0")+ " KM/H";

        if (Speed >= 175)
        {
            Speedmeterui.color = Color.red;
        }
        if (Speed > 100 && Speed < 175)
        {
            Speedmeterui.color = Color.yellow;
        }
        if (Speed < 100)
        {
            Speedmeterui.color = Color.white;
        }
    }
}
