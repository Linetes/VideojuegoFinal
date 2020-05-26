using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{
    public Text coin;
    public static int numCoins;
    // Use this for initialization
    void Start()
    {
        coin.text = "Monedas : ";
        numCoins = 0;
    }
    // Update is called once per frame
    void Update()
    {
        coin.text = "Monedas : " + numCoins;
    }
}