using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private GameObject animatronic;

    [SerializeField] private float interval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(interval, animatronic));
    }

    private IEnumerator SpawnEnemy(float Interval, GameObject Enemy)
    {
        yield return new WaitForSeconds(Interval);
        GameObject newEnemy = Instantiate(Enemy, new Vector3(Random.Range(-34f, 28f), Random.Range(-1f, 39f), 0), Quaternion.identity);
        StartCoroutine(SpawnEnemy(Interval, Enemy));
    }
}