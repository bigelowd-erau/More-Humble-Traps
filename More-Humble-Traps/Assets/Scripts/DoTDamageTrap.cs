

using System.Threading.Tasks;
using UnityEngine;

public class DoTDamageTrap : IHealthTrap
{
    private int delay = 500; //0.5 seconds
    private int bleedCount = 4;
    private int totalBleeds = 0;
    public void HandleCharacterEntered(IPlayer player)
    {
        totalBleeds = 0;
        Bleed(player);
    }

    private void Bleed(IPlayer player)
    {
        if (totalBleeds < bleedCount)
        {
            var t = Task.Factory.StartNew(() =>
            {
                return Task.Factory.StartNew(() =>
                {
                    Task.Delay(delay).Wait();
                    player.Health -= 5;
                    totalBleeds++;
                    Bleed(player);
                });
            });
            t.Wait();
        }
    }
}
