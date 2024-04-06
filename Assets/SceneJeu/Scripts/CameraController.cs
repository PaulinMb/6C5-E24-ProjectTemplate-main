using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur à suivre
    public float cameraHeight = 2f; // Hauteur constante de la caméra
    private Vector3 offset; // Offset par rapport au joueur

    void Start()
    {
        // Calculer l'offset initial entre la caméra et le joueur
        offset = transform.position - player.position;
        // Fixer la hauteur de la caméra
        offset.y = cameraHeight;
    }

    void LateUpdate()
    {
        // Mettre à jour la position de la caméra en suivant le joueur
        transform.position = player.position + offset;

        // Faire en sorte que la caméra regarde dans la même direction que le joueur
        transform.rotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y, player.eulerAngles.z);
    }
}
