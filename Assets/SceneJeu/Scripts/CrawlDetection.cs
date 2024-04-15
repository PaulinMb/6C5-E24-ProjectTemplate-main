using UnityEngine;
using UnityEngine.AI;

public class CrawlDetection : MonoBehaviour
{
    public float distanceSeuil = 5f; // Distance seuil pour consid�rer le personnage proche du goal
    public Transform[] goals; // Tableau de r�f�rences vers les objets "goal"
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
        // V�rifier si le personnage est proche d'un objectif
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

        // D�finir le param�tre "crawl" de l'Animator en fonction de la proximit� du goal
        animator.SetBool(CRAWL, estProche);

        // Emp�cher le contourning si le personnage rampe
        if (estProche)
        {
            // D�sactiver la capacit� de l'agent � calculer des chemins autour des obstacles
            navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        }
        else
        {
            // R�tablir la capacit� de l'agent � calculer des chemins autour des obstacles
            navMeshAgent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        }
    }
}
