using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyTests
    {
        
        [Test]
        public void EnemyTests_TakeDamage_ShouldTake10fDamage()
        {
            Enemy enemy = new Enemy();
            enemy.Health = 100f;

            enemy.TakeDamage(10f);

            Assert.AreEqual(90f, enemy.Health);
        }
        
        [Test]
        public void EnemyTests_TakeDamage_ShouldTake20fDamage()
        {
            Enemy enemy = new Enemy();
            enemy.Health = 100f;

            enemy.TakeDamage(20f);

            Assert.AreEqual(80f, enemy.Health);
        }
        
        [Test]
        public void EnemyTests_TakeDamage_ShouldNotTakeNegativeDamage()
        {
            Enemy enemy = new Enemy();
            enemy.Health = 100f;

            enemy.TakeDamage(-20f);

            Assert.AreEqual(100f, enemy.Health);
        }
        
    }
}
