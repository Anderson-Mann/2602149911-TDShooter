using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthMec : MonoBehaviour
{
    [SerializeField] private int health = 100;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Damage(10);
        }
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
            SceneManager.LoadSceneAsync(3);
        }
    }
}
