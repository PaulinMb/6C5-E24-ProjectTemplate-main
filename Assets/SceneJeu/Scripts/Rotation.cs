using UnityEngine;

public class Rotation : MonoBehaviour
{
     public float speed; // Vitesse de rotation
     private float increment = 5f; // Incrément de vitesse
     private float maxSpeed = 350f; // Vitesse maximale

    void FixedUpdate()
    {
        AdjustSpeed();
        // Appliquer la rotation en fonction de la vitesse
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime, Space.World);
    }

    private void AdjustSpeed()
    {
        // Augmenter la vitesse si la touche "haut" est enfoncée
        if (Input.GetKey("up"))
        {
            SetSpeed(+increment);
        }

        // Diminuer la vitesse si la touche "bas" est enfoncée
        if (Input.GetKey("down"))
        {
            SetSpeed(-increment);
        }
    }

    private void SetSpeed(float increment)
    {
        // Ajouter l'incrément à la vitesse actuelle
        speed += increment;

        // Limiter la vitesse entre -maxSpeed et +maxSpeed
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
    }
}
