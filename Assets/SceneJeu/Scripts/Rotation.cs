using UnityEngine;

public class Rotation : MonoBehaviour
{
     public float speed;
     private float increment = 5f; 
     private float maxSpeed = 350f; 

    void FixedUpdate()
    {
        AdjustSpeed();
       
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime, Space.World);
    }

    // Augmenter/ diminuer ;a vitesse
    private void AdjustSpeed()
    {
        
        if (Input.GetKey("up"))
        {
            SetSpeed(+increment);
        }

        if (Input.GetKey("down"))
        {
            SetSpeed(-increment);
        }
    }

    private void SetSpeed(float increment)
    {
        speed += increment;

        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
    }
}
