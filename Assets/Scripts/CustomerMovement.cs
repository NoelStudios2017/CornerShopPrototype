using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public GameObject[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitime;
    public bool isServed = false;
    public bool beenServed = false;
    public bool isMoving = false;

    private void Start()
    {
       randomSpot=Random.Range(0,moveSpots.Length);
       waitTime = startWaitime;
       moveSpots = GameObject.FindGameObjectsWithTag("Positions"); 
       isMoving = true;
       rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }
        
            //rb.bodyType = RigidbodyType2D.Dynamic;
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[randomSpot].transform.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                    //rb.bodyType = RigidbodyType2D.Kinematic;
                }
            }
        

    }

}
