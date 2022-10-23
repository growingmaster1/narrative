using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBTriggerCon : MonoBehaviour
{
    public bool isCollided = false;
    public GameObject MysteryBlack;
    // Start is called before the first frame update
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player"&&!isCollided)
        {
            isCollided = true;
            Player.instance.StopMoving();
            MysteryBlack.SetActive(true);
        }
    }
}
