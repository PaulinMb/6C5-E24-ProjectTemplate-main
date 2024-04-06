using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject limitObject; // R�f�rence � l'objet qui d�termine les limites horizontales
    public float speed = 2f; // Vitesse du mouvement

    private float minX; // Limite horizontale gauche de d�placement
    private float maxX; // Limite horizontale droite de d�placement
    private int direction = 1; // Direction du d�placement (1 pour droite, -1 pour gauche)

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
            Debug.LogWarning("Limit object reference is missing.");
            minX = -5f; // D�finir une valeur par d�faut pour minX
            maxX = 5f; // D�finir une valeur par d�faut pour maxX
        }

        // Initialiser la direction du d�placement al�atoirement
        direction = Random.Range(0, 2) * 2 - 1; // -1 ou 1
    }

    void Update()
    {
        // Calculer le d�placement horizontal en fonction de la vitesse et de la direction
        float horizontalMovement = direction * speed * Time.deltaTime;

        // Calculer la nouvelle position horizontale
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
