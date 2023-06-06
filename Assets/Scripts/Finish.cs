using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.tag=="Player" && CoinPick.Coins>=10)
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
      }
     
   }

   
}