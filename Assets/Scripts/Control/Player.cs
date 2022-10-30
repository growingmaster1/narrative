using Articy.Unity;
using Articy.Unity.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyNav;

public class Player : MonoBehaviour,IInit,IWithEntity
{
    public static Player instance;
    public bool moveable = true;
    public FixedJoystick joystick;
    public GameObject TracedTarget = null;

    private SpriteRenderer spRenderer;
    private Animator anim;
    private string lastMoveDir = "s";

    private PolyNavAgent agent;

    public Sprite idle_s;
    public Sprite idle_w;
    public Sprite idle_e;
    public Sprite idle_n;

    private Vector2 lastVel = new Vector2(0,0);
    private Vector3 lastPos;
    private Vector3 dis;
    private Vector3 lastDis = Vector3.zero;

    public ArticyRef givenEntity;
    public IArticyObject entity { get; set; }
    public string entityName { get; set; }
    public bool atDialog { get; set; }

    public bool turnable = true;
    public bool moveOped = true;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        entity = givenEntity.GetObject();
        entityName = "Íæ¼Ò";
        anim = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
        EntityManager.EntitiesDic.Add("Íæ¼Ò", this);
        agent = GetComponent<PolyNavAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        spRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }

    private void Move()
    {
        if (moveable)
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            float yMove = Input.GetAxisRaw("Vertical");

            xMove = xMove == 0 ? joystick.Horizontal : xMove;
            yMove = yMove == 0 ? joystick.Vertical : yMove;

            Vector2 vel = new Vector2(xMove, yMove);
            if((vel-lastVel).magnitude > float.Epsilon)
            {
                moveOped = true;
                lastVel = vel;
                StopTrace();
            }
            else
            {
                moveOped = false;
                lastVel = vel;
                if (TracedTarget != null)
                {
                    ControlTrace();
                    return;
                }
            }
            

            gameObject.GetComponent<Rigidbody2D>().MovePosition(
                new Vector2(transform.position.x + xMove * Time.deltaTime * 4, transform.position.y + yMove * Time.deltaTime * 4));

            anim.enabled = true;
            if (xMove > 0)
            {
                anim.Play("player_move_e");
                lastMoveDir = "e";
            }
            else if (xMove < 0)
            {
                anim.Play("player_move_w");
                lastMoveDir = "w";
            }
            else
            {
                if (yMove > 0)
                {
                    anim.Play("player_move_n");
                    lastMoveDir = "n";
                }
                else if (yMove < 0)
                {
                    anim.Play("player_move_s");
                    lastMoveDir = "s";
                }
                else
                {
                    anim.enabled = false;
                    Turn(lastMoveDir);
                }
            }

        }
    }

    public void ControlTrace()
    {
        if (TracedTarget != null)
        {
            dis = transform.position - lastPos;
            lastPos = transform.position;
            anim.enabled = true;
            if (dis.magnitude > float.Epsilon)
            {
                dis = dis.normalized;
                if (lastDis == Vector3.zero || Vector3.Angle(dis, lastDis) > 5)
                {
                    if (dis.x > 0.5f)
                    {
                        anim.Play("player_move_e");
                        lastMoveDir = "e";
                    }
                    else if (dis.x < -0.5f)
                    {
                        anim.Play("player_move_w");
                        lastMoveDir = "w";
                    }
                    else
                    {
                        if (dis.y > 0.5f)
                        {
                            anim.Play("player_move_n");
                            lastMoveDir = "n";
                        }
                        else if (dis.y < -0.5f)
                        {
                            anim.Play("player_move_s");
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

    public void TraceTarget(GameObject target)
    {
        TracedTarget = target;
        agent.OnDestinationReached += target.GetComponent<GameEntity>().RaiseDialog;
    }

    public void StopTrace()
    {
        if(TracedTarget != null)
        {
            agent.Stop();
            TracedTarget.GetComponent<GameEntity>().beingTraced = false;
            agent.OnDestinationReached -= TracedTarget.GetComponent<GameEntity>().RaiseDialog;
            TracedTarget = null;
        }
    }

    public void StopMoving()
    {
        moveable = false;
        anim.enabled = false;
        Turn(lastMoveDir);
    }

    public void Turn(string dir)
    {
        switch (dir)
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
