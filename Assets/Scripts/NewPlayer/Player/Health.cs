﻿//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Health.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Manage the health of the player.</summary>
public class Health : MonoBehaviour
{
    /// <summary>The time of effect</summary>
    private const float TimeOfEffect = 0.25f;

    /// <summary>The health</summary>
    private int health = 100;

    /// <summary>The sprite renderer</summary>
    private SpriteRenderer spriteRenderer = null;

    /// <summary>The health marker</summary>
    private Text marker = null;

    /// <summary>The health bar</summary>
    private Scrollbar bar = null;

    /// <summary>The treat clip</summary>
    [SerializeField]
    private AudioClip treatClip = null;

    /// <summary>The take clip</summary>
    [SerializeField]
    private AudioClip takeClip = null;

    /// <summary>The audio source</summary>
    private AudioSource audioSource = null;

    /// <summary>Gets a value indicating whether this instance is alive.</summary>
    /// <value>
    /// <c>true</c> if this instance is alive; otherwise, <c>false</c>.</value>
    public bool IsAlive => (health > 0) ? true : false;

    /// <summary>Treat the specified amount.</summary>
    /// <param name="amount">The amount.</param>
    public void Treat(int amount)
    {
        health = ((health + amount) > 100) ? 100 : health + amount;
        bar.size = (float)health / 100;
        marker.text = health.ToString();

        Sound.Play(treatClip, audioSource);
        Game.SaveVar(health).InFolder("Player").WithName("Health");
    }

    /// <summary>Treat full.</summary>
    public void TreatFull()
    {
        health = 100;
        bar.size = (float)health / 100;
        marker.text = health.ToString();

        Sound.Play(treatClip, audioSource);
        Game.SaveVar(health).InFolder("Player").WithName("Health");
    }

    /// <summary>Takes the specified amount.</summary>
    /// <param name="amount">The amount.</param>
    public void Take(int amount)
    {
        health = ((health - amount) <= 0) ? 0 : health - amount;
        bar.size = (float)health / 100;
        marker.text = health.ToString();

        StartCoroutine(TakeAHitEffect(TimeOfEffect));

        Sound.Play(takeClip, audioSource);
        Game.SaveVar(health).InFolder("Player").WithName("Health");
    }

    /// <summary>Awakes this instance.</summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        health = Game.LoadVar("Health").OfFolder("Player").Int;
        health = (health == 0) ? 100 : health;

        bar = transform.Find("Interface/Bar/Health").GetComponent<Scrollbar>();
        bar.size = (float)health / 100;

        marker = transform.Find("Interface/Bar/Health/Text").GetComponent<Text>();
        marker.text = health.ToString();
    }

    /// <summary>Takes a hit effect.</summary>
    /// <param name="time">The time.</param>
    /// <returns>Return none</returns>
    private IEnumerator TakeAHitEffect(float time)
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(time);
        spriteRenderer.color = Color.white;
    }
}