using UnityEngine;

public class SphereRoller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        RollSphere(); // Appel initial pour démarrer le mouvement
    }

    private void Update()
    {
        // Si la magnitude de la vélocité de la sphère est très faible (presque immobile)
        if (rb.velocity.magnitude < 0.1f)
        {
            RollSphere(); // Appel pour démarrer un nouveau mouvement
        }
    }

    private void RollSphere()
    {
        // Générer une direction aléatoire dans le plan x-z
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        // Appliquer une force dans la direction aléatoire
        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }
}
