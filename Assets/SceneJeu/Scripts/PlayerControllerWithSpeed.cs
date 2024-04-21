using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerWithSpeed : PlayerController
{

    public float acceleration = 1f;
    public float deceleration = 3f;
    public float vitesseMax = 3f;
    public float vitesseMin = 1.5f; // vitesse minimale limite lorsque proche
    private float vitesse = 0f;

    private Animator animator;
    private const string SPEED = "speed";

    protected override void Start()
    {
        base.Start(); 
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update(); 

        // maj de la vitesse en fonction de la distance restante
        float distanceToTarget = player.remainingDistance;
        if (distanceToTarget > player.stoppingDistance)
        {
            // Accélération
            if (vitesse < vitesseMax)
            {
                vitesse += Time.deltaTime * acceleration;
            }
        }
        else
        {
            // Décélération
            if (vitesse > 0)
            {
                vitesse -= Time.deltaTime * deceleration;
                if (vitesse < 0.1f)
                {
                    vitesse = 0;
                }
            }
        }

        // Ajuster la vitesse du NavMeshAgent
        player.speed = vitesse;

        // Mettre à jour le paramètre "speed" de l'AnimatorController
        animator.SetFloat(SPEED, vitesse);
    }

    // Méthode pour ajuster la vitesse si le personnage est proche
    public void AjusterVitesseProche(bool estProche)
    {
        if (estProche)
        {
            // Diminution progressive de la vitesse jusqu'à vitesseMin
            if (vitesse > vitesseMin)
            {
                vitesse -= Time.deltaTime * deceleration;
                if (vitesse < vitesseMin)
                {
                    vitesse = vitesseMin;
                }
            }
        }
    }
}
