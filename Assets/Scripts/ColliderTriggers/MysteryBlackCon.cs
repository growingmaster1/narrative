using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlackCon : MonoBehaviour
{
    public GameObject hudou;
    bool isDropped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(((transform.position-Player.instance.transform.position).magnitude<6.0f)&&!isDropped)
        {
            isDropped = true;
            hudou.transform.position = transform.position;
        }
    }

    private void OnBecameVisible()
    {
        if (!isDropped)
        {
            Player.instance.StopMoving();
        }
    }
    private void OnBecameInvisible()
    {
        if (isDropped)
        {
            Player.instance.moveable = true;
        }
    }
}
