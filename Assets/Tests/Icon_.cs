﻿//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Icon_.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

/// <summary>Test the icon class</summary>
public class Icon_
{
    /// <summary>Tests to load icon of resources.</summary>
    /// <returns>Return none</returns>
    [UnityTest]
    public IEnumerator Test_To_Load_Icon_Of_Resources()
    {
        SceneManager.LoadScene("House");

        yield return null;

        Icon[] icons = GameObject.FindObjectsOfType<Icon>();
        foreach (Icon icon in icons)
        {
            Assert.IsNotNull(icon.Sprite, "Icon of " + icon.gameObject.name + " is null.");
            Assert.AreEqual(icon.Sprite.name, icon.Name);
        }
    }
}
