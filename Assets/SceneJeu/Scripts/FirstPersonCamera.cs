using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform target; // Référence au transform du joueur à suivre
    public Vector3 offset; // Offset par rapport au joueur
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la caméra

    void LateUpdate()
    {
        if (target == null)
            return;

        // Utiliser la position actuelle du joueur pour déterminer la position de la caméra
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Bloquer les rotations sur les axes x et y
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
