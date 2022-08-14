using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IInit
{
    public static Player instance;
    public bool moveable;
    public FixedJoystick joystick;

    private SpriteRenderer spRenderer;
    private Animator anim;
    private string lastMoveDir = "s";

    public Sprite idle_s;
    public Sprite idle_w;
    public Sprite idle_e;
    public Sprite idle_n;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        anim = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
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

            anim.enabled = true;
            if(xMove > 0)
            {
                anim.Play("player_move_e");
                lastMoveDir = "e";
            }
            else if(xMove<0)
            {
                anim.Play("player_move_w");
                lastMoveDir = "w";
            }
            else
            {
                if(yMove>0)
                {
                    anim.Play("player_move_n");
                    lastMoveDir = "n";
                }
                else if(yMove<0)
                {
                    anim.Play("player_move_s");
                    lastMoveDir = "s";
                }
                else
                {
                    anim.enabled = false;
                    switch(lastMoveDir)
                    {
                        case "e":
                            {
                                spRenderer.sprite = idle_e;
                                break;
                            }
                        case "s":
                            {
                                spRenderer.sprite = idle_s;
                                break;
                            }
                        case "w":
                            {
                                spRenderer.sprite = idle_w;
                                break;
                            }
                        case "n":
                            {
                                spRenderer.sprite = idle_n;
                                break;
                            }
                    }
                }
            }

        }
    }
}
