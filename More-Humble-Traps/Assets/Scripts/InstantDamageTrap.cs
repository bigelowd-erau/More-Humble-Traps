public class InstantDamageTrap : IHealthTrap
{
    public void HandleCharacterEntered(IPlayer player)
    {
        player.Health -= 10;
    }
}
