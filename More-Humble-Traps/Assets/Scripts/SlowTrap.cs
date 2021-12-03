using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SlowTrap : ICCTrap
{
    int duration = 1500; //milliseconds//1.5 seconds
    float slow = 5; //how many times slower
    public void HandleCharacterEntered(IPlayerMover playerMover)
    {
        playerMover.speed /= slow;
        Debug.Log("set player speed to " + playerMover.speed);
        var t = Task.Factory.StartNew(() =>
        {
            return Task.Factory.StartNew(() =>
            {
                Task.Delay(duration).Wait();
                playerMover.speed *= slow;
                Debug.Log("restored player speed to " + playerMover.speed);
            });
        });
        t.Wait();
    }
}
