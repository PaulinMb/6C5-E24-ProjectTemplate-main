using UnityEngine;
using UnityEngine.AI;

public class DetectionGoal : MonoBehaviour
{
    public float distanceSeuil = 5f; // Distance seuil pour consid�rer le personnage proche du goal
    public Transform[] goals; // Tableau de r�f�rences vers les objets "goal"
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
        playerController = GetComponent<PlayerControllerWithSpeed>(); // R�cup�rer le composant PlayerControllerWithSpeed
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
            // V�rification si le personnage est proche du goal actuel
            if (distanceXZ <= distanceSeuil)
            {
                // Si proche d'un objectif, le personnage est consid�r� comme proche
                estProche = true;

                // V�rifier si la distance seuil est inf�rieure � 0.1
                if (distanceXZ < 0.1)
                {
                    // D�finir le param�tre bool�en "winning" sur true dans l'animator
                    animator.SetBool(animatorWinningHash, true);
                }
                else
                {
                    // D�finir le param�tre bool�en "winning" sur false dans l'animator
                    animator.SetBool(animatorWinningHash, false);
                }
                // Sortir de la boucle car le personnage est d�j� proche d'un objectif
                break;
            }
        }

        // Mettre � jour le param�tre bool�en de l'Animator en fonction de la proximit�
        animator.SetBool(PROCHE, estProche);

        // Appeler la m�thode pour ajuster la vitesse dans PlayerControllerWithSpeed
        playerController.AjusterVitesseProche(estProche);
    }
}
