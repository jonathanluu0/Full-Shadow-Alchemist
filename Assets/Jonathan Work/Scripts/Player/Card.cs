using UnityEngine;
using System.Collections;

namespace ClearSky
{
    public class Card : MonoBehaviour
    {
        public enum CardType { Damage, Health, Speed }
        public CardType cardType;
        public int value = 10;

        public void ApplyCardEffect(GameObject player)
        {
            switch (cardType)
            {
                case CardType.Damage:
                    var projectile = player.GetComponentInChildren<ProjectileDamage>();
                    if (projectile != null)
                    {
                        projectile.IncreaseDamage(value);
                    }
                    break;
                case CardType.Health:
                    var health = player.GetComponent<PlayerHealth>();
                    if (health != null)
                    {
                        health.IncreaseHealth(value);
                    }
                    break;
                case CardType.Speed:
                    var movement = player.GetComponent<PlayerController>();
                    if (movement != null)
                    {
                        movement.IncreaseSpeed(value);
                    }
                    break;
            }
        }
    }
}
