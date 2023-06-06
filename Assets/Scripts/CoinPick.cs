using UnityEngine;
using TMPro;

public class CoinPick : MonoBehaviour
{

    public TMP_Text СoinsText;
    private float _coins = 0;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag != "Coin") return;
        _coins++;
        СoinsText.text = _coins.ToString();
        Destroy(collider2D.gameObject);
    }
}