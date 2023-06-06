using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;

public class CoinPick : MonoBehaviour
{

    public TMP_Text coinsText;
    private float coins = 0;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(collider2D.gameObject);
        }
    }
}
