﻿//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Inventory.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Manage the inventory of the player.</summary>
public class Inventory : MonoBehaviour
{
    /// <summary>The open</summary>
    private const string Open = "Open";

    /// <summary>The inventory</summary>
    private List<Image> inventory;

    /// <summary>The press effects</summary>
    private List<PressEffect> pressEffects;

    /// <summary>The UI animator</summary>
    private Animator uiAnimator = null;

    /// <summary>The audio source</summary>
    private AudioSource audioSource = null;

    /// <summary>The take item</summary>
    [SerializeField]
    private AudioClip takeItem = null;

    /// <summary>The use item</summary>
    [SerializeField] 
    private AudioClip useItem = null;

    /// <summary>Awakes this instance.</summary>
    public void Awake()
    {
        Game.LoadStats();
    }

    /// <summary>Starts this instance.</summary>
    public void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.uiAnimator = this.transform.Find("Interface/Inventory").GetComponent<Animator>();

        this.pressEffects = new List<PressEffect>
        {
            this.transform.Find("Interface/Inventory/Slot1/Image").GetComponent<PressEffect>(),
            this.transform.Find("Interface/Inventory/Slot2/Image").GetComponent<PressEffect>(),
            this.transform.Find("Interface/Inventory/Slot3/Image").GetComponent<PressEffect>()
        };

        this.inventory = new List<Image>
        {
            this.transform.Find("Interface/Inventory/Slot1/Item").GetComponent<Image>(),
            this.transform.Find("Interface/Inventory/Slot2/Item").GetComponent<Image>(),
            this.transform.Find("Interface/Inventory/Slot3/Item").GetComponent<Image>()
        };

        this.inventory[0].gameObject.SetActive(false);
        this.inventory[1].gameObject.SetActive(false);
        this.inventory[2].gameObject.SetActive(false);

        this.LoadInventory();
        this.CheckSlots();
    }

    /// <summary>Updates this instance.</summary>
    public void Update()
    {
        if (Input.anyKey) 
        {
            if (Input.GetKeyDown(KeyCode.I)) 
            {
                if (this.uiAnimator.GetBool(Open))
                {
                    this.uiAnimator.SetBool(Open, false);
                    this.transform.Find("Interface/InventoryButton").GetComponent<PressEffect>().StartEffect();
                    return;
                }
                else 
                {
                    this.uiAnimator.SetBool(Open, true);
                    this.transform.Find("Interface/InventoryButton").GetComponent<PressEffect>().StopEffect();
                    this.CheckSlots();
                    return;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                this.UseItem(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                this.UseItem(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                this.UseItem(2);
            }
        }
    }

    /// <summary>Adds the item.</summary>
    /// <param name="tag">The tag.</param>
    /// <param name="item">The item.</param>
    public void AddItem(string tag, Sprite item) 
    {
        foreach (Image slot in this.inventory) 
        {
            if (slot.sprite == null) 
            {
                slot.gameObject.SetActive(true);
                slot.sprite = item;
                slot.tag = tag;

                this.CheckSlots();
                this.PlayClip(this.takeItem);
                this.SaveInventory();
                break;
            }
        }
    }

    /// <summary>Determines whether this instance has space.</summary>
    /// <returns>
    /// <c>true</c> if this instance has space; otherwise, <c>false</c>.</returns>
    public bool HasSpace()
    {
        foreach (Image slot in this.inventory)
        {
            if (slot.sprite == null)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>Checks the slots.</summary>
    private void CheckSlots() 
    {
        for (int i = 0; i < 3; i++) 
        {
            if (this.inventory[i].sprite == null)
            {
                this.pressEffects[i].StopEffect();
            }
            else 
            {
                this.pressEffects[i].StartEffect();
            }
        }
    }

    /// <summary>Uses the item.</summary>
    /// <param name="position">The position.</param>
    private void UseItem(int position)
    {
        if (this.inventory[position] != null)
        {
            switch (this.inventory[position].tag)
            {
                case "PotionRed":
                    this.GetComponent<Health>().FullHealth();
                    break;

                case "PotionBlue":
                    this.GetComponent<Health>().FullShield();
                    break;

                case "PotionPurple":
                    break;

                case "PotionYellow":
                    break;
            }

            this.inventory[position].sprite = null;
            this.inventory[position].tag = "Untagged";
            this.inventory[position].gameObject.SetActive(false);

            this.CheckSlots();
            this.PlayClip(this.useItem);
            this.SaveInventory();
        }
    }

    /// <summary>Loads the inventory.</summary>
    private void LoadInventory() 
    {
        for (int i = 0; i < this.inventory.Count; i++) 
        {
            if (Stats.Current.SpriteItem[i] != null) 
            {
                this.inventory[i].gameObject.SetActive(true);
                this.inventory[i].sprite = Stats.Current.SpriteItem[i];
                this.inventory[i].tag = Stats.Current.TagItem[i];
            }
        }
    }

    /// <summary>Saves the inventory.</summary>
    private void SaveInventory() 
    {
        for (int i = 0; i < this.inventory.Count; i++)
        {
            Stats.Current.SpriteItem[i] = this.inventory[i].sprite;
            Stats.Current.TagItem[i] = this.inventory[i].tag;
        }

        Game.SaveStats();
    }

    /// <summary>Plays the clip.</summary>
    /// <param name="clip">The clip.</param>
    private void PlayClip(AudioClip clip)
    {
        this.audioSource.clip = clip;
        this.audioSource.Play();
    }
}