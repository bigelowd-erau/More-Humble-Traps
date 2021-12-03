using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTrapBehavior : MonoBehaviour
{
    [SerializeField] private IHealthTrap trap;
    [SerializeField] private HealthTrapType healthTrapType;

    private void Awake()
    {
        switch (healthTrapType)
        {
            case (HealthTrapType.Instant):
                trap = new InstantDamageTrap();
                break;
            case (HealthTrapType.DoT):
                trap = new DoTDamageTrap();
                break;
            case (HealthTrapType.Injur):
                trap = new InjurTrap();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        trap.HandleCharacterEntered(player);
    }
}

public enum HealthTrapType { Instant, DoT, Injur }

