using UnityEngine;

public class SphereRoller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        RollSphere(); // Appel initial pour d�marrer le mouvement
    }

    private void Update()
    {
        // Si la magnitude de la v�locit� de la sph�re est tr�s faible (presque immobile)
        if (rb.velocity.magnitude < 0.1f)
        {
            RollSphere(); // Appel pour d�marrer un nouveau mouvement
        }
    }

    private void RollSphere()
    {
        // G�n�rer une direction al�atoire dans le plan x-z
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        // Appliquer une force dans la direction al�atoire
        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }
}