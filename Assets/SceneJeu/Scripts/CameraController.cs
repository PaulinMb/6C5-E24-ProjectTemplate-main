using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // R�f�rence au transform du joueur � suivre
    public float cameraHeight = 2f; // Hauteur constante de la cam�ra
    private Vector3 offset; // Offset par rapport au joueur

    void Start()
    {
        // Calculer l'offset initial entre la cam�ra et le joueur
        offset = transform.position - player.position;
        // Fixer la hauteur de la cam�ra
        offset.y = cameraHeight;
    }

    void LateUpdate()
    {
        // Mettre � jour la position de la cam�ra en suivant le joueur
        transform.position = player.position + offset;

        // Faire en sorte que la cam�ra regarde dans la m�me direction que le joueur
        transform.rotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y, player.eulerAngles.z);
    }
}
