using UnityEngine;

public class player_detection : MonoBehaviour
{
    public enemy_control ec;

    void OnTriggerEnter2D(Collider2D col)
    {
        //ec.HandleAttack();
        //Also make a layer detect, that does not collide with default, to avoid any doublehits.
    }
}
