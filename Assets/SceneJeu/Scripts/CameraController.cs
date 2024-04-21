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
        // Fixer la hauteur de la caméra
        offset.y = cameraHeight;

        // desactiver la caméra du joueur au démarrage
        cameraPlayer.enabled = false;
    }

    void LateUpdate()
    {
        // maj la position de la caméra en suivant le joueur
        transform.position = player.position + offset;

        // caméra regarde dans la même direction que le joueur
        transform.rotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y, player.eulerAngles.z);

        // Si la touche C enfoncée
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Changer l'état d'activité des caméras
            cameraPlayer.enabled = !cameraPlayer.enabled;
            cameraMain.enabled = !cameraMain.enabled;
        }
    }
}
