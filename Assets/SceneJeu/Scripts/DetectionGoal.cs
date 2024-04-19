using UnityEngine;
using UnityEngine.AI;

public class DetectionGoal : MonoBehaviour
{
    public float distanceSeuil = 5f; // Distance seuil pour considérer le personnage proche du goal
    public Transform[] goals; // Tableau de références vers les objets "goal"
    private Animator animator;
    private const string PROCHE = "proche";
    private NavMeshAgent navMeshAgent;
    private PlayerControllerWithSpeed playerController;

    private int animatorWinningHash;
    private const string WINNIG = "winning";



    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerController = GetComponent<PlayerControllerWithSpeed>(); // Récupérer le composant PlayerControllerWithSpeed
        animatorWinningHash = Animator.StringToHash(WINNIG);
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

                // Vérifier si la distance seuil est inférieure à 0.1
                if (distanceXZ < 0.1)
                {
                    // Définir le paramètre booléen "winning" sur true dans l'animator
                    animator.SetBool(animatorWinningHash, true);
                }
                else
                {
                    // Définir le paramètre booléen "winning" sur false dans l'animator
                    animator.SetBool(animatorWinningHash, false);
                }
                // Sortir de la boucle car le personnage est déjà proche d'un objectif
                break;
            }
        }

        // Mettre à jour le paramètre booléen de l'Animator en fonction de la proximité
        animator.SetBool(PROCHE, estProche);

        // Appeler la méthode pour ajuster la vitesse dans PlayerControllerWithSpeed
        playerController.AjusterVitesseProche(estProche);
    }
}
