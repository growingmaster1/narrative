using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public bool moveable;
    public FixedJoystick joystick;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(moveable)
        {
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");

            xMove = xMove == 0 ? joystick.Horizontal : xMove;
            yMove = yMove == 0 ? joystick.Vertical : yMove;

            transform.Translate(xMove, yMove, 0);
        }
    }
}
