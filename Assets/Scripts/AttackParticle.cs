using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    private void OnParticleCollision(GameObject other)
    {
        var collisionEvents = new List<ParticleCollisionEvent>();

        var enemyComponent = other.GetComponent<Enemy>();

        var crateComponent = other.GetComponent<Crates>();

        print("Particle Collided and other is " + other);

        if(!enemyComponent.isShielded)
        {
            enemyComponent.EnemyDeath();
        }
        else
        {
            PlayerDead.Invoke();
        }
        if(crateComponent)
        {
            crateComponent.CrateDestroy();
        }
        
    }

}
