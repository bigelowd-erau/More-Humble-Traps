//using NUnit.Framework;
using UnityEngine.TestTools;
using NSubstitute;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;



public class TrapTests
{
    [Test]
    public void PlayerEntering_InstantDamageTrap_ReducesHealthByTen()
    {
        IHealthTrap trap = new InstantDamageTrap();
        IPlayer player = Substitute.For<IPlayer>();
        player.IsPlayer.Returns(true);
        player.Health = 100;
        trap.HandleCharacterEntered(player);
        Assert.AreEqual(90, player.Health);
    }
}
