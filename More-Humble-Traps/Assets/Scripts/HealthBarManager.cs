using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] Player playerHealth;
    private int initialHealth;
    private void Start()
    {
        initialHealth = playerHealth.Health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3((float)playerHealth.Health / initialHealth, 1f, 1f);
    }
}
