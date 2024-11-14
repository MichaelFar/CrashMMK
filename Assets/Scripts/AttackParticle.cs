using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerDeathEvent : UnityEvent<int>
{
}
public class AttackParticle : MonoBehaviour
{
    private PlayerDeathEvent PlayerDead;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        var collisionEvents = new List<ParticleCollisionEvent>();

        var enemyComponent = other.GetComponent<Enemy>();

        var crateComponent = other.GetComponent<Crates>();

        print("Particle Collided and other is " + other);

        if(enemyComponent.isTurtle)
        {
            enemyComponent.EnemyDeath();
        }
        if(crateComponent)
        {
            crateComponent.CrateDestroy();
        }
        
    }

}
