using UnityEngine;
using UnityEngine.AI;

public class DetectionGoal : MonoBehaviour
{
    public float distanceSeuil = 5f; // Distance seuil pour considérer le personnage proche du goal
    public Transform[] goals; // Tableau de références vers les objets "goal"
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
            // Vérification si le personnage est proche du goal actuel
            if (distanceXZ <= distanceSeuil)
            {
                // Si proche d'un objectif, le personnage est considéré comme proche
                estProche = true;
                // Sortir de la boucle car le personnage est déjà proche d'un objectif
                break;
            }
        }

        // Mettre à jour le paramètre booléen de l'Animator en fonction de la proximité
        animator.SetBool(PROCHE, estProche);
    }
}
