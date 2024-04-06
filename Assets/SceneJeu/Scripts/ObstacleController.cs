using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject limitObject; // Référence à l'objet qui détermine les limites horizontales
    public float speed = 2f; // Vitesse du mouvement

    private float minX; // Limite horizontale gauche de déplacement
    private float maxX; // Limite horizontale droite de déplacement
    private int direction = 1; // Direction du déplacement (1 pour droite, -1 pour gauche)

    void Start()
    {
        // Récupérer les limites horizontales de l'objet référencé
        if (limitObject != null)
        {
            Bounds bounds = limitObject.GetComponent<Renderer>().bounds;
            minX = bounds.min.x;
            maxX = bounds.max.x;
        }
        else
        {
            Debug.LogWarning("Limit object reference is missing.");
            minX = -5f; // Définir une valeur par défaut pour minX
            maxX = 5f; // Définir une valeur par défaut pour maxX
        }

        // Initialiser la direction du déplacement aléatoirement
        direction = Random.Range(0, 2) * 2 - 1; // -1 ou 1
    }

    void Update()
    {
        // Calculer le déplacement horizontal en fonction de la vitesse et de la direction
        float horizontalMovement = direction * speed * Time.deltaTime;

        // Calculer la nouvelle position horizontale
        float newXPosition = transform.position.x + horizontalMovement;

        // Limiter la nouvelle position horizontale dans les limites récupérées de l'objet référencé
        newXPosition = Mathf.Clamp(newXPosition, minX, maxX);

        // Mettre à jour la position de l'objet avec la nouvelle position horizontale
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        // Inverser la direction si l'objet atteint l'une des limites horizontales de déplacement
        if (newXPosition == minX || newXPosition == maxX)
        {
            direction *= -1;
        }
    }
}
