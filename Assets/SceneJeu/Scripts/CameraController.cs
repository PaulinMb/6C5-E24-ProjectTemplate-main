using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float cameraHeight = 2f;
    private Vector3 offset; // Offset par rapport au joueur

    public Camera cameraPlayer;
    public Camera cameraMain;

    void Start()
    {
        offset = transform.position - player.position;
        // Fixer la hauteur de la cam�ra
        offset.y = cameraHeight;

        // desactiver la cam�ra du joueur au d�marrage
        cameraPlayer.enabled = false;
    }

    void LateUpdate()
    {
        // maj la position de la cam�ra en suivant le joueur
        transform.position = player.position + offset;

        // cam�ra regarde dans la m�me direction que le joueur
        transform.rotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y, player.eulerAngles.z);

        // Si la touche C enfonc�e
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Changer l'�tat d'activit� des cam�ras
            cameraPlayer.enabled = !cameraPlayer.enabled;
            cameraMain.enabled = !cameraMain.enabled;
        }
    }
}
