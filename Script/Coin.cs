using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI textCoin;

    // coin collection
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            coin++;

            textCoin.text = coin.ToString();

            Destroy(other.gameObject);
        }
    }
}
