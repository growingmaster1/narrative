using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableEntity : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spRenderer;

    private Vector3 lastPos;
    private Vector3 dis;
    private string lastMoveDir = "s";

    public Sprite idle_s;
    public Sprite idle_w;
    public Sprite idle_e;
    public Sprite idle_n;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
        lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        spRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -1000);
        dis = transform.position - lastPos;
        lastPos = transform.position;
        anim.enabled = true;
        if(dis.sqrMagnitude>float.Epsilon)
        {
            if(dis.x>0.005f)
            {
                anim.Play(name + "_move_e");
                lastMoveDir = "e";
            }
            else if(dis.x< -0.005f)
            {
                anim.Play(name + "_move_w");
                lastMoveDir = "w";
            }
            else
            {
                if(dis.y> 0.005f)
                {
                    anim.Play(name + "_move_n");
                    lastMoveDir = "n";
                }
                else if(dis.y<-0.005f)
                {
                    anim.Play(name + "_move_s");
                    lastMoveDir = "s";
                }
            }
        }
        else
        {
            anim.enabled = false;
            switch (lastMoveDir)
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
    }
}
