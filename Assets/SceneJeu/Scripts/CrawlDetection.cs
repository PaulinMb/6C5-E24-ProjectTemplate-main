using UnityEngine;
using UnityEngine.AI;

public class CrawlDetection : MonoBehaviour
{
    public float distanceSeuil = 5f; // Distance seuil pour considérer le personnage proche du goal
    public Transform[] goals; // Tableau de références vers les objets "goal"
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private const string CRAWL = "crawl";

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Vérifier si le personnage est proche d'un objectif
        bool estProche = false;
        foreach (Transform goal in goals)
        {
            float distance = Vector3.Distance(transform.position, goal.position);
            if (distance <= distanceSeuil)
            {
                estProche = true;
                break;
            }
        }

        // Définir le paramètre "crawl" de l'Animator en fonction de la proximité du goal
        animator.SetBool(CRAWL, estProche);

        // Empêcher le contourning si le personnage rampe
        if (estProche)
        {
            // Désactiver la capacité de l'agent à calculer des chemins autour des obstacles
            navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        }
        else
        {
            // Rétablir la capacité de l'agent à calculer des chemins autour des obstacles
            navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        }
    }
}
