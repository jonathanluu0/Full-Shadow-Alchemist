using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D collider)
   {
    //Check if other game objects has Icollectible interface
    if(collider.gameObject.TryGetComponent(out ICollectible collectible))
    {
        //collects the Game Object
        collectible.Collect();
    }
   }
}
