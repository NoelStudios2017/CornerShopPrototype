using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    
    Rigidbody2D custBody;
    [SerializeField] float moveSpeed;
    GameObject currentStartPoint;
    [SerializeField] GameObject shoppingPointA;
    [SerializeField] GameObject shoppingPointB;
    [SerializeField] GameObject shoppingPointC;
    [SerializeField] GameObject shoppingPointGettingServed;
    [SerializeField] GameObject shopEntrance;
    public bool isMoving;
    public bool isServed;
    int walkDirection;
    public float walkTime;
    float walkCounter;
    public float waitTime;
    float waitCounter;
    private void Start()
    {
        custBody=GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        Move();
        currentStartPoint.transform.position = shopEntrance.transform.position;
        //SetAnimator play idle or something?)
    }

    private void Update()
    {
        //Vector2 point =currentStartPoint.transform.position-t
        if(isMoving)
        {
            walkCounter -= Time.deltaTime;
            
            switch (walkDirection)
            {
                case 0:
                    Vector2.MoveTowards(shopEntrance.transform.position, shoppingPointA.transform.position, moveSpeed);

                    //custBody.linearVelocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    //custBody.linearVelocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    custBody.linearVelocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    custBody.linearVelocity = new Vector2(-moveSpeed, 0);
                    break;
            }
            if (walkCounter < 0)
            {
                isMoving = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            custBody.linearVelocity = Vector2.zero;
            if(waitCounter < 0)
            {
                Move();
            }
        }
    }
    public void Move()
    {
        //walkDirection = Random.Range(0, 4);
        isMoving = true;
        walkCounter=walkTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GettingServed"))
        {
            isMoving = false;
            isServed = true;
        }
    }
}
