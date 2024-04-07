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

        // Si l'objet n'est plus en contact avec le sol, le détruire
        if (!IsOnGround())
        {
            Destroy(gameObject);
        }
    }

    private void RollSphere()
    {
        // Générer une direction aléatoire dans le plan x-z
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;

        // Appliquer une force dans la direction aléatoire
        rb.AddForce(randomDirection * speed, ForceMode.Impulse);
    }


    private bool IsOnGround()
    {
        // Vérifier si l'objet est en collision avec le sol en utilisant un raycast vers le bas
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit);
    }

}
