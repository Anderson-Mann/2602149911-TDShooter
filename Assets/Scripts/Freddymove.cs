using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Freddymove : MonoBehaviour
{
    // Chasing
    public GameObject Player;

    public float Walk = 3f;

    public float Run = 5.4f;

    public float seeDistance = 4f;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < seeDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Run * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward *angle);
        }
        else if(distance > seeDistance)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, Walk * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward *angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Ded();
        }
    }

    public void Ded()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
