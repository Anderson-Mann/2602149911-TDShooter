using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioChase : MonoBehaviour
{
    // Chasing
    public GameObject Player;

    public GameObject Halter;

    public float Run;

    private float distance;

    private float haltDis;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        haltDis = Vector2.Distance(transform.position, Halter.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(haltDis < 5f)
        {
            Run = 0f;
        }
        else if(haltDis > 5f)
        {
            Run = 6f;
        }
        if(distance < 1000f)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Run * Time.deltaTime);
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
