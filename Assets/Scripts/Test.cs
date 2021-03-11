using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Ship ship;

    private void Start()
    {
        ship = new Ship(100, 0, 100);
        ship.TakeDamage(100);
        
    }
}
