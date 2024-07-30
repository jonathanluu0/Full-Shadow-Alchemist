using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPotion : MonoBehaviour, ICollectible
{

    public void Collect()
    {
        Debug.Log("Picked up Fireball Potion");
        Destroy(gameObject);
        Debug.Log("Fireball potion destroyed");
    }
}
