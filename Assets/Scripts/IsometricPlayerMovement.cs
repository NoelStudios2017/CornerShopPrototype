using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1;
    //IsometricCharacterRenderer isoRender;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        //get isorenderer here too.

    }

    private void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        //capturing input from the input system
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //store into an ew vector 2 
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        //to prevent diagonal movement being faster than normal direction
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;

        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        //isoRendere.SetDirection(movement);
        rbody.MovePosition(newPos); 
    }
}
