using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIChase : MonoBehaviour
{
    // Patrol
    public Transform[] patrolPoints;
    public int TargetPoint;
    // Chasing
    public GameObject Player;

    public float Walk = 3f;

    public float Run = 5.4f;

    public float seeDistance = 4f;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        TargetPoint = 0;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        Vector2 Pdirection = patrolPoints[TargetPoint].position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float angle2 = Mathf.Atan2(Pdirection.y, Pdirection.x) * Mathf.Rad2Deg;

        if(distance < seeDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Run * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward *angle);
        }
        else if(distance > seeDistance)
        {
            if(transform.position == patrolPoints[TargetPoint].position)
            {
                increaseTargetInt();
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[TargetPoint].position, Walk * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward *angle2);
        }
    }

    void increaseTargetInt()
    {
        TargetPoint++;
        if(TargetPoint >= patrolPoints.Length)
        {
            TargetPoint = 0;
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
