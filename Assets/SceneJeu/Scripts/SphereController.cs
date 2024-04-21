using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject terrainBoundary; 
    public float speed = 2f; 

    private bool isGrounded = false;

    private void Start()
    {
        if (terrainBoundary == null)
        {
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
            // Si l'obstacle est en contact avec le sol, le faire rouler dans une direction al�atoire
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            transform.Translate(randomDirection * speed * Time.deltaTime);
        }

        // Si l'obstacle sort des limites du terrain, le d�truire
        if (!IsInsideTerrainBoundary())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // V�rifier si l'obstacle entre en collision avec le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private bool IsInsideTerrainBoundary()
    {
        // V�rifier si l'obstacle est � l'int�rieur des limites du terrain d�finies par terrainBoundary
        if (terrainBoundary != null)
        {
            // R�cup�rer les limites du terrain
            Bounds bounds = terrainBoundary.GetComponent<Renderer>().bounds;

            // V�rifier si la position de l'obstacle est � l'int�rieur des limites horizontales du terrain
            return bounds.Contains(transform.position);
        }

        // Si l'objet de limite de terrain n'est pas d�fini, consid�rer l'obstacle comme �tant toujours � l'int�rieur
        return true;
    }
}