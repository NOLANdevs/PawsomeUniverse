using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerParticleCollision : MonoBehaviour
{
    public CleanBar cleanBar;
    public Item showerItem;

    private ParticleSystem showerParticleSystem;
    private ParticleSystem.EmissionModule em;

    private void Start()
    {
        showerParticleSystem = GetComponent<ParticleSystem>();
        em = showerParticleSystem.emission;

    }

    private void OnParticleCollision(GameObject other)
    {
        // Check if the particle collided with the player
        if (other.CompareTag("Player"))
        {
            // Increase cleanliness
            if (cleanBar != null)
            {
                cleanBar.CleanAnimal(showerItem.statsIncreaseAmount);
            }
        }
    }
}
