using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject terrainBoundary; // Référence à l'objet qui marque les limites du terrain
    public float speed = 2f; // Vitesse de déplacement de l'obstacle

    private bool isGrounded = false; // Indique si l'obstacle est en contact avec le sol

    private void Start()
    {
        // Si l'objet de limite de terrain n'est pas défini, afficher un avertissement
        if (terrainBoundary == null)
        {
            Debug.LogWarning("Terrain boundary reference is missing.");
        }
    }

    private void Update()
    {
        if (!isGrounded)
        {
            // Si l'obstacle n'est pas en contact avec le sol, le faire descendre
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            // Si l'obstacle est en contact avec le sol, le faire rouler dans une direction aléatoire
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            transform.Translate(randomDirection * speed * Time.deltaTime);
        }

        // Si l'obstacle sort des limites du terrain, le détruire
        if (!IsInsideTerrainBoundary())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifier si l'obstacle entre en collision avec le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private bool IsInsideTerrainBoundary()
    {
        // Vérifier si l'obstacle est à l'intérieur des limites du terrain définies par terrainBoundary
        if (terrainBoundary != null)
        {
            // Récupérer les limites du terrain
            Bounds bounds = terrainBoundary.GetComponent<Renderer>().bounds;

            // Vérifier si la position de l'obstacle est à l'intérieur des limites horizontales du terrain
            return bounds.Contains(transform.position);
        }

        // Si l'objet de limite de terrain n'est pas défini, considérer l'obstacle comme étant toujours à l'intérieur
        return true;
    }
}