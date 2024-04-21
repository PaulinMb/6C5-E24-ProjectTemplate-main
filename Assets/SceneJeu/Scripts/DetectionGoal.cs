using UnityEngine;
using UnityEngine.AI;

public class DetectionGoal : MonoBehaviour
{
    public float distanceSeuil = 5f; // Distance seuil pour considérer le personnage proche du goal
    public Transform[] goals; 
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
        playerController = GetComponent<PlayerControllerWithSpeed>();
        animatorWinningHash = Animator.StringToHash(WINNIG);
    }

    void Update()
    {
        bool estProche = false;

        foreach (Transform goal in goals)
        {
            // Calcul de la distance entre le personnage et l'objectif actuel
            float distanceXZ = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                                 new Vector3(goal.position.x, 0, goal.position.z));
            // Vérification si le personnage est proche du goal actuel
            if (distanceXZ <= distanceSeuil)
            {
                estProche = true;

                // Vérifier si la distance seuil est inférieure à 0.1
                if (distanceXZ < 0.1)
                {
                    animator.SetBool(animatorWinningHash, true);
                }
                else
                {
                    animator.SetBool(animatorWinningHash, false);
                }
                break;
            }
        }

        animator.SetBool(PROCHE, estProche);

        playerController.AjusterVitesseProche(estProche);
    }
}
