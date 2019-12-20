﻿//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Player.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;

/// <summary>Manage the player of the game.</summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    /// <summary>The open</summary>
    private const string Open = "Open";

    /// <summary>The run</summary>
    private const string Run = "Run";

    /// <summary>The attack</summary>
    private const string Attack = "Attack";

    /// <summary>The skill</summary>
    private const string Skill = "Roll";

    /// <summary>The vertical</summary>
    private const string Vertical = "Vertical";

    /// <summary>The horizontal</summary>
    private const string Horizontal = "Horizontal";

    /// <summary>The position</summary>
    private Vector2 position = Vector2.zero;

    /// <summary>The direction</summary>
    private Vector2 direction = Vector2.zero;

    /// <summary>The speed move</summary>
    private int speedMove = 3;

    /// <summary>The time to close bar</summary>
    private float timeToCloseBar = 10f;

    /// <summary>The time reset</summary>
    private float timeReset = 10f;

    /// <summary>The joystick</summary>
    private Joystick joystick = null;

    /// <summary>The health</summary>
    private Health health = null;

    /// <summary>The wallet</summary>
    private Wallet wallet = null;

    /// <summary>The inventory</summary>
    private Inventory inventory = null;

    /// <summary>The pet</summary>
    private Pet pet = null;

    /// <summary>The animator</summary>
    private Animator animator = null;

    /// <summary>The UI animator</summary>
    private Animator uiAnimator = null;

    /// <summary>The rigid body</summary>
    private Rigidbody2D rigbody2D = null;

    /// <summary>Awakes this instance.</summary>
    public void Awake()
    {
        Game.LoadSettings();
        Game.LoadStats();
        Language.Translate();
    }

    /// <summary>Starts this instance.</summary>
    public void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.uiAnimator = this.transform.Find("Interface/Bar").GetComponent<Animator>();
        this.rigbody2D = this.GetComponent<Rigidbody2D>();
        this.health = this.GetComponent<Health>();
        this.wallet = this.GetComponent<Wallet>();
        this.inventory = this.GetComponent<Inventory>();
    }

    /// <summary>Updates this instance.</summary>
    public void Update()
    {
        if (Input.anyKey || Input.touchCount > 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
            {
                this.position = this.rigbody2D.position;

                this.direction.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                this.direction.Normalize();

                this.animator.SetFloat(Horizontal, this.direction.x);
                this.animator.SetFloat(Vertical, this.direction.y);

                this.animator.SetBool(Run, true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    this.StartCoroutine("StartRoll");
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    this.StartCoroutine("StartAttack");
                }
            }

            this.uiAnimator.SetBool(Open, true);
            this.timeToCloseBar = this.timeReset;
        }
        else
        {
            this.animator.SetBool(Run, false);

            this.timeToCloseBar -= Time.deltaTime;
            if (this.timeToCloseBar <= 0) 
            {
                this.timeToCloseBar = this.timeReset;
                this.uiAnimator.SetBool(Open, false);
            }
        }
    }

    /// <summary>Update every frame.</summary>
    public void FixedUpdate()
    {
        this.rigbody2D.MovePosition(this.position + (this.direction * (this.speedMove * Time.deltaTime)));
    }

    /// <summary>Starts the roll.</summary>
    /// <returns>Return none</returns>
    public IEnumerator StartRoll()
    {
        this.gameObject.layer = 14;
        this.animator.SetBool(Skill, true);
        yield return new WaitForSeconds(this.animator.GetCurrentAnimatorStateInfo(0).length / 2);
        this.animator.SetBool(Skill, false);
        this.gameObject.layer = 0;
    }

    /// <summary>Starts the attack.</summary>
    /// <returns>Return none</returns>
    public IEnumerator StartAttack()
    {
        this.animator.SetBool(Attack, true);
        yield return new WaitForSeconds(this.animator.GetCurrentAnimatorStateInfo(0).length / 2);
        this.animator.SetBool(Attack, false);
    }

    /// <summary>Called when [trigger enter2 d].</summary>
    /// <param name="obj">The object.</param>
    public void OnTriggerEnter2D(Collider2D obj)
    {
        switch (obj.tag)
        {
            case "Coin":
                this.wallet.TakeCoin();
                MonoBehaviour.Destroy(obj.gameObject);
                break;

            case "Heart":
                this.health.Treat();
                MonoBehaviour.Destroy(obj.gameObject);
                break;

            case "Key":
                MonoBehaviour.Destroy(obj.gameObject);
                break;

            case "Pet":
                if (this.pet)
                {
                    this.pet.LeaveOwner();
                    this.pet = null;
                }
                else
                {
                    this.pet = obj.GetComponent<Pet>();
                    this.pet.SetOwner(this.gameObject);
                }

                break;
            case "PotionRed":
                if (this.inventory.HasSpace())
                {
                    this.inventory.AddItem(obj.tag, obj.GetComponent<Icon>().GetIcon());
                    MonoBehaviour.Destroy(obj.gameObject);
                }

                break;
            case "PotionBlue":
                if (this.inventory.HasSpace())
                {
                    this.inventory.AddItem(obj.tag, obj.GetComponent<Icon>().GetIcon());
                    MonoBehaviour.Destroy(obj.gameObject);
                }

                break;
            case "PotionPurple":
                if (this.inventory.HasSpace())
                {
                    this.inventory.AddItem(obj.tag, obj.GetComponent<Icon>().GetIcon());
                    MonoBehaviour.Destroy(obj.gameObject);
                }

                break;
            case "PotionYellow":
                if (this.inventory.HasSpace())
                {
                    this.inventory.AddItem(obj.tag, obj.GetComponent<Icon>().GetIcon());
                    MonoBehaviour.Destroy(obj.gameObject);
                }

                break;
        }
    }

    /// <summary>Sets the position.</summary>
    public void SetPosition() 
    {
        this.position = new Vector2(250, 250);
        this.position.Set(250, 250);
    }
}