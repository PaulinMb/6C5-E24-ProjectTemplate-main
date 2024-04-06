using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform target; // R�f�rence au transform du joueur � suivre
    public Vector3 offset; // Offset par rapport au joueur
    public float smoothSpeed = 0.125f; // Vitesse de suivi de la cam�ra

    void LateUpdate()
    {
        if (target == null)
            return;

        // Utiliser la position actuelle du joueur pour d�terminer la position de la cam�ra
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Bloquer les rotations sur les axes x et y
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
