using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur à suivre
    public float cameraHeight = 2f; // Hauteur constante de la caméra
    private Vector3 offset; // Offset par rapport au joueur

    public Camera cameraPlayer;
    public Camera cameraMain;

    void Start()
    {
        // Calculer l'offset initial entre la caméra et le joueur
        offset = transform.position - player.position;
        // Fixer la hauteur de la caméra
        offset.y = cameraHeight;

        // Assurer que la caméra du joueur est désactivée au démarrage
        cameraPlayer.enabled = false;
    }

    void LateUpdate()
    {
        // Mettre à jour la position de la caméra en suivant le joueur
        transform.position = player.position + offset;

        // Faire en sorte que la caméra regarde dans la même direction que le joueur
        transform.rotation = Quaternion.Euler(player.eulerAngles.x, player.eulerAngles.y, player.eulerAngles.z);

        // Si la touche C est enfoncée
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Changer l'état d'activité des caméras
            cameraPlayer.enabled = !cameraPlayer.enabled;
            cameraMain.enabled = !cameraMain.enabled;
        }
    }
}
