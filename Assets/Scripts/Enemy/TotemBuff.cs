﻿//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TotemBuff.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;

/// <summary>Control a TotemBuff</summary>
public class TotemBuff : MonoBehaviour, IEnemy
{
    /// <summary>The restart</summary>
    private const string Restart = "Restart";

    /// <summary>The eXIT</summary>
    private const string Exit = "Exit";

    /// <summary>The Dead</summary>
    private const string Dead = "Dead";

    /// <summary>The attack</summary>
    private const string Attack = "Attack";

    /// <summary>The vertical</summary>
    private const string Vertical = "Vertical";

    /// <summary>The horizontal</summary>
    private const string Horizontal = "Horizontal";

    /// <summary>The vision radio</summary>
    private const float VisionRange = 5f;

    /// <summary>The attack range</summary>
    private const float AttackRange = 2f;

    /// <summary>The frequency to attack</summary>
    private const float FrequencyToAttack = 1.5f;

    /// <summary>The target</summary>
    private Transform target = null;

    /// <summary>The bullet</summary>
    [SerializeField]
    private GameObject bullet = null;

    /// <summary>The health</summary>
    private int health = 100;

    /// <summary>The direction</summary>
    private Vector3 direction = Vector3.zero;

    /// <summary>The sprite renderer</summary>
    private SpriteRenderer spriteRenderer = null;

    /// <summary>The animator</summary>
    private Animator animator = null;

    /// <summary>The audio source</summary>
    private AudioSource audioSource = null;

    /// <summary>The hit clip</summary>
    [SerializeField]
    private AudioClip hitClip = null;

    /// <summary>The attacking</summary>
    private bool attacking = false;

    /// <summary>The dead</summary>
    private bool deading = false;

    /// <summary>Takes the damage.</summary>
    /// <param name="damage">The damage.</param>
    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0 && !this.deading)
        {
            this.StartCoroutine(this.Die());
            return;
        }

        this.StartCoroutine(this.Hit());
    }

    /// <summary>Starts this instance.</summary>
    public void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.animator = this.GetComponent<Animator>();
        this.audioSource = this.GetComponent<AudioSource>();

        this.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    /// <summary>Called when [enable].</summary>
    public void OnEnable()
    {
        this.GetComponent<Animator>().SetTrigger(Restart);
    }

    /// <summary>Updates this instance.</summary>
    public void Update()
    {
        if (this.health > 0)
        {
            if (this.DistanceToTarget() <= VisionRange)
            {
                if (!this.attacking)
                {
                    this.FollowTarget();
                }

                if (this.DistanceToTarget() <= AttackRange && !this.attacking)
                {
                    this.StartCoroutine(this.AttackToTheTarget());
                }
            }
        }
    }

    /// <summary>Hits this instance.</summary>
    /// <returns>Return none</returns>
    public IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.1f);
        this.spriteRenderer.color = Color.red;
        this.PlayClip(this.hitClip);
        yield return new WaitForSeconds(0.1f);
        this.spriteRenderer.color = Color.white;
    }

    /// <summary>Dies this instance.</summary>
    /// <returns>Return none</returns>
    public IEnumerator Die()
    {
        this.animator.SetBool(Exit, true);
        this.animator.SetTrigger(Dead);
        this.deading = true;
        this.spriteRenderer.color = Color.white;

        MonoBehaviour.Destroy(this.GetComponent<Occlusion>());
        MonoBehaviour.Destroy(this.GetComponent<BoxCollider2D>());
        MonoBehaviour.Destroy(this.GetComponent<AudioSource>());

        yield return new WaitForSeconds(3f);

        MonoBehaviour.Destroy(this.GetComponent<Animator>());
        MonoBehaviour.Destroy(this.GetComponent<TotemBuff>());
    }

    /// <summary>Distances to target.</summary>
    /// <returns>Return the distance</returns>
    public float DistanceToTarget()
    {
        return Vector2.Distance(this.transform.position, this.target.position);
    }

    /// <summary>Follows the target.</summary>
    private void FollowTarget()
    {
        this.direction = this.target.position - this.transform.position;
        this.direction.Normalize();

        this.animator.SetFloat(Horizontal, this.direction.x);
        this.animator.SetFloat(Vertical, this.direction.y);
    }

    /// <summary>Attacks to the target.</summary>
    /// <returns>Return none</returns>
    private IEnumerator AttackToTheTarget()
    {
        this.attacking = true;
        this.direction = Vector3.zero;

        yield return new WaitForSeconds(FrequencyToAttack / 2);
        this.animator.SetTrigger(Attack);

        var bulletSpawned = Instantiate(this.bullet, this.transform.position, Quaternion.identity);
        bulletSpawned.GetComponent<Bullet>().SetTarget(this.target.position);

        yield return new WaitForSeconds(FrequencyToAttack / 2);

        this.attacking = false;
    }

    /// <summary>Plays the clip.</summary>
    /// <param name="clip">The clip.</param>
    private void PlayClip(AudioClip clip)
    {
        this.audioSource.clip = clip;
        this.audioSource.Play();
    }

    /// <summary>Called when [draw gizmos selected].</summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, VisionRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, AttackRange);
    }
}