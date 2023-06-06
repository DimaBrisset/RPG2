using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinPick : MonoBehaviour
{
  
    public TMP_Text СoinsText;
    public static float Coins = 0;
   
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag != "Coin") return;
        Coins++;
        СoinsText.text = Coins.ToString();
        Destroy(collider2D.gameObject);
        
       
    }
    


}