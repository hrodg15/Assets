using UnityEngine;

public class SphereCommands : MonoBehaviour
{
    Vector3 originalPosition;

    // Use this for initialization
    void Start()
    { 

        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        //Follows the same logic as OnMove, just with gesture instead of voice.
        OnMove();
    }


    // Called by SpeechManager when the user says the "Reset world" command
    void OnReset()
    {
        // If the sphere has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            DestroyImmediate(rigidbody);
        }

        // Put the sphere back into its original local position.
        this.transform.localPosition = originalPosition;
    }

    // Called by SpeechManager when the user says the "Move Robot" command
    void OnMove()
    {


        //May be changed depending on velocity, wheel radius, and time
        float ballradius = 1;
        float time = 2;
        float speed = 5;
        float distance = speed * time;
        float rotationinradians = distance / ballradius;
        float rotationindegrees = rotationinradians * Mathf.Rad2Deg;

        if (!this.GetComponent<Rigidbody>())
        {
            //Makes the ball interactible 

            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
             
            //Translates ball without intermediate view.
            //rigidbody.AddForce(2f, 0f, 0f, ForceMode.VelocityChange); 
        
            //Adds angular velocity to the ball. 
            rigidbody.transform.Rotate(rotationindegrees, 0f, 5f);
        }
    }
}
