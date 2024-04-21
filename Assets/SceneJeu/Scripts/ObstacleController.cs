using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject limitObject; 
    public float speed = 2f;

    private float minX; 
    private float maxX; 
    private int direction = 1;

    void Start()
    {
        // R�cup�rer les limites horizontales de l'objet r�f�renc�
        if (limitObject != null)
        {
            Bounds bounds = limitObject.GetComponent<Renderer>().bounds;
            minX = bounds.min.x;
            maxX = bounds.max.x;
        }
        else
        {
            minX = -5f; 
            maxX = 5f;
        }

        // Initialiser la direction du d�placement al�atoirement
        direction = Random.Range(0, 2) * 2 - 1; // -1 ou 1
    }

    void Update()
    {
        // Calculer le d�placement horizontal en fonction de la vitesse et de la direction
        float horizontalMovement = direction * speed * Time.deltaTime;

        float newXPosition = transform.position.x + horizontalMovement;

        // Limiter la nouvelle position horizontale dans les limites r�cup�r�es de l'objet r�f�renc�
        newXPosition = Mathf.Clamp(newXPosition, minX, maxX);

        // Mettre � jour la position de l'objet avec la nouvelle position horizontale
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        // Inverser la direction si l'objet atteint l'une des limites horizontales de d�placement
        if (newXPosition == minX || newXPosition == maxX)
        {
            direction *= -1;
        }
    }
}
