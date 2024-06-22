using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] Image musicCharge;
    [SerializeField] float Duration;
    [SerializeField] float currentTime;
    public GameObject Player;
    public BoxCollider2D bx;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Duration;
        StartCoroutine(TimeIEn());
    }

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
            musicCharge.fillAmount = Mathf.InverseLerp(0, Duration, currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
    }

    }
