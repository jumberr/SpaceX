using UnityEngine;

public class Test : MonoBehaviour
{
    private Ship ship;

    private void Start()
    {
        ship = new Ship(0, 100, 5,3);
        ship.TakeDamage(220);
    }
}
