using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBTriggerCon : MonoBehaviour
{
    public bool isCollided = false;
    public GameObject MysteryBlack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            isCollided = true;
            MysteryBlack.SetActive(true);
        }
    }
}
