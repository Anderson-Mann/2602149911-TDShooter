using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Its called healing");
        }

        this.health -= amount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Bullet"))
        {
            Damage(20);
        }
    }
}
