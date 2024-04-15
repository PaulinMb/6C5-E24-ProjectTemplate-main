using UnityEngine;
using UnityEngine.AI;

public class DetectionGoal : MonoBehaviour
{
    public float distanceSeuil = 5f; // Distance seuil pour consid�rer le personnage proche du goal
    public Transform[] goals; // Tableau de r�f�rences vers les objets "goal"
    private Animator animator;
    private const string PROCHE = "proche";
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Variable pour garder trace si le personnage est proche d'au moins un objectif
        bool estProche = false;

        // Parcours de tous les objectifs
        foreach (Transform goal in goals)
        {
            // Calcul de la distance entre le personnage et l'objectif actuel
            float distanceXZ = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                                 new Vector3(goal.position.x, 0, goal.position.z));
            // V�rification si le personnage est proche du goal actuel
            if (distanceXZ <= distanceSeuil)
            {
                // Si proche d'un objectif, le personnage est consid�r� comme proche
                estProche = true;
                // Sortir de la boucle car le personnage est d�j� proche d'un objectif
                break;
            }
        }

        // Mettre � jour le param�tre bool�en de l'Animator en fonction de la proximit�
        animator.SetBool(PROCHE, estProche);
    }
}
