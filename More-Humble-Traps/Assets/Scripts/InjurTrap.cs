using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InjurTrap : ICCTrap, IHealthTrap
{
    RootTrap rootTrap;
    SlowTrap slowTrap;
    InstantDamageTrap instantDamageTrap;
    DoTDamageTrap dotDamageTrap;
 

    // Start is called before the first frame update
    public InjurTrap()
    {
        rootTrap = new RootTrap();
        slowTrap = new SlowTrap();
        instantDamageTrap = new InstantDamageTrap();
        dotDamageTrap = new DoTDamageTrap();
    }
    public void HandleCharacterEntered(IPlayerMover playerMover)
    {
        rootTrap.HandleCharacterEntered(playerMover);
        var r = Task.Factory.StartNew(() =>
        {
            return Task.Factory.StartNew(() =>
            {
                Task.Delay(1500).Wait();
                slowTrap.HandleCharacterEntered(playerMover);
            });
        });
        r.Wait();
    }

    public void HandleCharacterEntered(IPlayer player)
    {
        instantDamageTrap.HandleCharacterEntered(player);
        var r = Task.Factory.StartNew(() =>
        {
            return Task.Factory.StartNew(() =>
            {
                Task.Delay(1500).Wait();
                dotDamageTrap.HandleCharacterEntered(player);
            });
        });
        r.Wait();
    }



}
