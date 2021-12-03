using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RootTrap : ICCTrap
{
    int duration = 1500; //milliseconds//1.5 seconds
    float speed;
    public void HandleCharacterEntered(IPlayerMover playerMover)
    {
        speed = playerMover.speed;
        playerMover.speed = 0;
        Debug.Log("set player speed to " + playerMover.speed);
        Debug.Log("saved speed is " + speed);
        var t = Task.Factory.StartNew(() =>
        {
            return Task.Factory.StartNew(() =>
            {
                Task.Delay(duration).Wait();
                playerMover.speed = speed;
                Debug.Log("restored player speed to " + playerMover.speed);
            });
        });
        t.Wait();
    }
}
