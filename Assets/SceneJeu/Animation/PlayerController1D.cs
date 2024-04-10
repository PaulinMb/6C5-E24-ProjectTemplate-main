using System.Collections;


using UnityEngine;

public class PlayerController1D : MonoBehaviour
{
    public float acceleration = 1f;
    public float deceleration = 3f;

   
    public float vitesseMax = 3f;
    public float vitesseRotation = 75.0f;

    //Un parametre qui contient la vitesse de course de notre personnage
    private float vitesse = 0f;

    //La reference vers notre composant Animator
    private Animator animator;


    //la constant qui contient le nom deu parametre pour communiquer avec l'Animator
    private const string SPEED = "speed";

    //HashCode vers les variables de l'Animator (permet de communiquer avec lui)
    private int animatorVitesseHash;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorVitesseHash = Animator.StringToHash(SPEED);

    }

    // Update is called once per frame
    void Update()
    {

        //Cette partie gere l'input de l'utilisateur
        float avance= 0f;
        avance = Input.GetAxis("Vertical");


        //Cette partie gere le d�placement du player
        //Tant qu'on appuie sur avance, la vitesse augmente (lavitesse est fonction de la vitesse � la frame pr�c�dente
        if (avance != 0 & vitesse < vitesseMax)
        {
            vitesse += Time.deltaTime * acceleration;

        }
        if (avance == 0 && vitesse > 0)
        {
            vitesse -= Time.deltaTime * deceleration;
            if (vitesse < 0.1f)
            {
                vitesse = 0;
            }
        }

        if (vitesse != 0)
        {
            float translation = vitesse * Time.deltaTime;
            float rotation = Input.GetAxis("Horizontal") * vitesseRotation * Time.deltaTime;

            transform.Translate(Vector3.forward * translation);
            transform.Rotate(0, rotation, 0);

        }


        //Cette partie transmet l'�tat du personnage � l'Animator pour piloter l'Animation
        animator.SetFloat(animatorVitesseHash, vitesse);

    }
}

