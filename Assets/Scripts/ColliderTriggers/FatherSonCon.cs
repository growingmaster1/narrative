using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherSonCon : MonoBehaviour
{
    public bool isCollided = false;
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
            transform.parent.GetChild(1).gameObject.SetActive(true);
            transform.parent.GetChild(4).gameObject.SetActive(true);
            transform.parent.GetChild(5).gameObject.SetActive(true);
        }
    }
}
