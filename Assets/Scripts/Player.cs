using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        xMove = xMove == 0 ? joystick.Horizontal : xMove;
        yMove = yMove == 0 ? joystick.Vertical : yMove;

        transform.Translate(xMove, yMove, 0);
    }
}
