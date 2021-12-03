using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public int Health { get; set; } = 100;
    [SerializeField] private bool isPlayer;
    public bool IsPlayer => isPlayer;
}
