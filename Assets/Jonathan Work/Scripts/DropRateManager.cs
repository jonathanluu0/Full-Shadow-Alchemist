using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]

    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }

    public List<Drops> drops;

    void OnDestroy()
    {
        if(!gameObject.scene.isLoaded) { return; } // ensures game objects spawn only when scene is loaded

        float rng = UnityEngine.Random.Range(0, 100f);
        List<Drops> possibleDrops = new List<Drops>();
        foreach (Drops rate in drops)
        {
            if(rng <= rate.dropRate)
            {
                possibleDrops.Add(rate);
            }
        }
        // Check for possible drops
        if(possibleDrops.Count > 0)
        {
            Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count)];
            Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);
        }
        
    }
}
