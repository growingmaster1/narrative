using Articy.Unity;
using Articy.Unity.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IInit,IWithEntity
{
    public static Player instance;
    public bool moveable = true;
    public FixedJoystick joystick;

    private SpriteRenderer spRenderer;
    private Animator anim;
    private string lastMoveDir = "s";

    public Sprite idle_s;
    public Sprite idle_w;
    public Sprite idle_e;
    public Sprite idle_n;

    public ArticyRef givenEntity;
    public IArticyObject entity { get; set; }
    public string entityName { get; set; }
    public bool atDialog { get; set; }

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
    }

    // Update is called once per frame
    void FixedUpdate()
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

        }
    }
}
