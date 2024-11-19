using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Name: Michael Farrar
/// Description: Activates a particle and checks for collisions with certain objects to determine behavior
/// Date: 11/18/24
/// </summary>
public class AttackParticle : MonoBehaviour
{
    
    UnityEvent PlayerDead = new UnityEvent();

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerDead.AddListener(player.GetComponent<PlayerController>().PlayerDeath);
    }

    // Update is called once per frame
    /// <summary>
    /// If a particle collides with something, determine what it collided with then act accordingly. Handles how attacks interact with enemies
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        var collisionEvents = new List<ParticleCollisionEvent>();

        var enemyComponent = other.GetComponent<Enemy>();

        var crateComponent = other.GetComponent<Crates>();

        print("Particle Collided and other is " + other);

        if (enemyComponent)
        {
            if (!enemyComponent.isShielded)
            {
                enemyComponent.EnemyDeath();
            }
            else
            {
                PlayerDead.Invoke();
                
            }
        }
        if(crateComponent)
        {
            crateComponent.CrateDestroy();
        }
        
    }

}
