using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerWithSpeed : PlayerController
{
    // Param�tres de vitesse suppl�mentaires
    public float acceleration = 1f;
    public float deceleration = 3f;
    public float vitesseMax = 3f;
    public float vitesseMin = 1.5f; // Nouvelle vitesse minimale lorsque proche
    private float vitesse = 0f;

    private Animator animator;
    private const string SPEED = "speed";

    protected override void Start()
    {
        base.Start(); // Appeler la m�thode Start de la classe de base
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update(); // Appeler la m�thode Update de la classe de base

        // Mise � jour de la vitesse en fonction de la distance restante
        float distanceToTarget = player.remainingDistance;
        if (distanceToTarget > player.stoppingDistance)
        {
            // Acc�l�ration
            if (vitesse < vitesseMax)
            {
                vitesse += Time.deltaTime * acceleration;
            }
        }
        else
        {
            // D�c�l�ration
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

        // Mettre � jour le param�tre "speed" de l'AnimatorController
        animator.SetFloat(SPEED, vitesse);
    }

    // M�thode pour ajuster la vitesse si le personnage est proche
    public void AjusterVitesseProche(bool estProche)
    {
        if (estProche)
        {
            // Diminution progressive de la vitesse jusqu'� vitesseMin
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
