using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AreaPotrolPointsGo : MonoBehaviour
{
  public float speed;
  public Transform[] moveSpot;
  public float startWaitTime;
  private int randomSpot;
  private float waitTime;
  
  private void Start()
  {
    randomSpot = Random.Range(0, moveSpot.Length);
    waitTime = startWaitTime;
  }

  private void Update()
  {
    transform.position = Vector3.MoveTowards(transform.position, moveSpot[randomSpot].position, speed * Time.deltaTime);
    if (Vector2.Distance(transform.position, moveSpot[randomSpot].position) <= 0.2)
    {
      if (waitTime <= 0)
      {
        randomSpot = Random.Range(0, moveSpot.Length);
        waitTime = startWaitTime;
      }
      else
      {
        waitTime -= Time.deltaTime;
      }
    }
  }
}
