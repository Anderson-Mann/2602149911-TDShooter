using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnings : MonoBehaviour
{
    public float musicCharge = 30f;
    [SerializeField] float Duration;
    [SerializeField] float currentTime;
    public GameObject Player;
    public GameObject Marionette;
    public BoxCollider2D bx;
    private float distance;
    // Start is called before the first frame update
    
    void Start()
    {
        currentTime = Duration;
        StartCoroutine(TimeIEn());
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(bx.transform.position, Player.transform.position);

        if(distance <= 2f)
        {
            if(Input.GetKey("e"))
            {
                currentTime = currentTime + 0.005f;
            }
        }
    }

    IEnumerator TimeIEn()
    {

        while(currentTime >= 0)
        {
            musicCharge = Mathf.InverseLerp(0, Duration, currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        if(musicCharge < 1)
        {
            Instantiate(Marionette, transform.position, transform.rotation);
        }
    }
}
