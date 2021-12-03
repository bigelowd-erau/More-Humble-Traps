using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTrapBehavior : MonoBehaviour
{
    [SerializeField] private ICCTrap trap;
    [SerializeField] private CCTrapType ccTrapType;

    private void Awake()
    {
        switch(ccTrapType)
        {
            case (CCTrapType.Root):
                trap = new RootTrap();
                break;
            case (CCTrapType.Slow):
                trap = new SlowTrap();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IPlayerMover playerMover = other.GetComponent<IPlayerMover>();
        trap.HandleCharacterEntered(playerMover);
    }
}

public enum CCTrapType { Root, Slow}
