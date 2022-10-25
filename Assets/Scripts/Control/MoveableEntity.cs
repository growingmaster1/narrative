using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyNav;

public class MoveableEntity : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spRenderer;
    private PolyNavAgent agent;

    private Vector3 lastPos;
    private Vector3 dis;
    private Vector3 lastDis = Vector3.zero;
    private string lastMoveDir = "s";

    public Sprite idle_s;
    public Sprite idle_w;
    public Sprite idle_e;
    public Sprite idle_n;

    public bool turnable = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
        lastPos = transform.position;
        agent = GetComponent<PolyNavAgent>();
    }

    private void FixedUpdate()
    {
        spRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
        if(turnable)
        {
            dis = transform.position - lastPos;
            //dis = dis.normalized;
            lastPos = transform.position;
            anim.enabled = true;
            if (dis.magnitude > float.Epsilon)
            {
                if (lastDis == Vector3.zero || Vector3.Angle(dis, lastDis) > 5)
                {
                    if (dis.x > 0.5f)
                    {
                        anim.Play(name + "_move_e");
                        lastMoveDir = "e";
                    }
                    else if (dis.x < -0.5f)
                    {
                        anim.Play(name + "_move_w");
                        lastMoveDir = "w";
                    }
                    else
                    {
                        if (dis.y > 0.5f)
                        {
                            anim.Play(name + "_move_n");
                            lastMoveDir = "n";
                        }
                        else if (dis.y < -0.5f)
                        {
                            anim.Play(name + "_move_s");
                            lastMoveDir = "s";
                        }
                    }
                    lastDis = dis;
                }
            }
            else
            {
                anim.enabled = false;
                Turn(lastMoveDir);
            }
        }
    }

    public void Turn(string dir)
    {
        switch(dir)
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
        lastMoveDir = dir;
    }

    public void PolyNavSpeedChange(float newSpeed)
    {
        agent.maxSpeed = newSpeed;
    }

}
