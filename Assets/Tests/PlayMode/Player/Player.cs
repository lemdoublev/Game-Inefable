﻿//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Player.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>Test player script in play mode</summary>
namespace Tests
{
    public class Player
    {
        [Test]
        public void Simple_Passes()
        {
            Assert.That(true.Equals(true));
        }

        [UnityTest]
        public IEnumerator With_Enumerator_Passes()
        {
            yield return null;
            Assert.That(true.Equals(true));
        }
    }
}
