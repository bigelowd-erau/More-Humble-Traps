using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using UnityEngine.TestTools;
using UnityEditor;

public class TestSuite
{/*
    // A Test behaves as an ordinary method
    [Test]
    public void TestSuiteSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestSuiteWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    */
    [UnityTest]
    public IEnumerator PlayerEntering_RootCC_PreventsMovement()
    {
        ICCTrap trap = new RootTrap();
        IPlayerMover playerMover;
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("../../Prefabs/Player"));
        yield return new WaitForSeconds(3f);
        playerMover = player.GetComponent<IPlayerMover>();
        float delay = 1.5f;
        float speed = playerMover.speed;

        trap.HandleCharacterEntered(playerMover);

        Assert.AreEqual(0, playerMover.speed);
        float startTime = Time.timeSinceLevelLoad;

        yield return new WaitForSeconds(delay);
        Assert.AreEqual(speed, playerMover.speed);
    }

    [UnityTest]
    public IEnumerator PlayerEntering_SlowCC_SlowsMovement()
    {
        ICCTrap trap = new SlowTrap();
        IPlayerMover playerMover;
        GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
        playerMover = player.GetComponent<IPlayerMover>();
        float delay = 1.5f;
        float initialSpeed = playerMover.speed;

        trap.HandleCharacterEntered(playerMover);

        Assert.AreEqual(2.5f, playerMover.speed);
        float startTime = Time.timeSinceLevelLoad;

        yield return new WaitForSeconds(delay);
        Assert.AreEqual(10f, playerMover.speed);
    }
    [UnityTest]
    public IEnumerator PlayerEntering_DoTDamageTrap_ReducesHealthByTen()
    {
        IHealthTrap trap = new DoTDamageTrap();
        IPlayer player = Substitute.For<IPlayer>();
        player.Health = 100;

        trap.HandleCharacterEntered(player);
        Assert.AreEqual(100, player.Health);
        yield return new WaitForSeconds(0.7f);
        Assert.AreEqual(95, player.Health);
        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual(90, player.Health);
        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual(85, player.Health);
        yield return new WaitForSeconds(0.5f);
        Assert.AreEqual(80, player.Health);
    }
}
