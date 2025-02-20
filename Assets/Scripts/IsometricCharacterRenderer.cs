using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{
    //These are animations in the animator called the same thing for either standing facing a certain direction or moving in a certain direction.
    public static readonly string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public static readonly string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };

    //Animator animator;

    int lastDirection;

    private void Awake()
    {
        //getanimator here.
    }
    public void SetDirection(Vector2 direction)
    {
        string[] directionArray = null;
        if(direction.magnitude<0.1f)
        {
            //if we are basically standing still we will use static states.
            //we wont be able to calculate direction if the user isnt pressing one anyway.
            directionArray = staticDirections;
        }
        else
        {
            //we can calculate which direction we are going in 
            // use DirectionToIndex to get the index of the slice from the direction vector.
            //save the answer to lastDirection;
            directionArray = runDirections;
            lastDirection = DirectionToIndex(direction, 8);
        }
        //tell the animatior to play the request state
       // animator.Play(directionArray[lastDirection]);
    }
    //helper functions

    //this function converts a vector 2 direction to an index to a slice around a circle. this goes in a counter clockwide direction.
    public static int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        //get the normalised direction
        Vector2 normDir = dir.normalized;
        float step = 360f / sliceCount;
        //calculate how many degrees half a slice is
        //we need this to offset the pie so that the North UP slice is aligned with the centre
        float halfstep = step / 2;
        //get the angle from -180 to 180 of the direction vector relative to the up vector
        //this will return the angle between dir and North
        float angle =Vector2.SignedAngle(Vector2.up,normDir);

        angle+=halfstep; 
        //if angle is negative then lets make it positive by adding 360 to wrap it around.
        if(angle < 0)
        {
            angle += 360;
        }
        //calculate the amount of steps required to reach this angle;
        float stepCount = angle / step;
        //round it and we have the answer;
        return Mathf.FloorToInt(stepCount);
    }
}
