using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void Update()
    {
        // Si l'objet n'est plus en contact avec le sol, le détruire
        if (!IsOnGround())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOnGround()
    {
        // Vérifier si l'objet est en collision avec le sol en utilisant un raycast vers le bas
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit);
    }
}
