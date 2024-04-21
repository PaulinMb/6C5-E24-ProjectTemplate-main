using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs; // Liste des prefabs d'obstacles � instancier
    public float spawnInterval = 2f; // Intervalle de spawn des obstacles

    private float timer; // Timer pour suivre le temps �coul� depuis le dernier spawn

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        // Mettre � jour le timer
        timer += Time.deltaTime;

        // Si le timer d�passe l'intervalle de spawn
        if (timer >= spawnInterval)
        {
            
            // R�initialiser le timer
            timer = 0f;

            // Choisir un prefab d'obstacle al�atoire parmi la liste
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            // Calculer une position al�atoire � l'int�rieur du spawnArea
            Vector3 spawnPosition = new Vector3(Random.Range(transform.position.x - 5f, transform.position.x + 5f), transform.position.y, Random.Range(transform.position.z - 5f, transform.position.z + 5f));

            // Instancier un nouvel obstacle � la position al�atoire avec une rotation al�atoire
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            //CalculComplexCPU();

        }
    }

    //Consomation du CPU

    /*
    private void CalculComplexCPU()
    {
        // Simulation d'une charge de travail importante sur le CPU
        for (int i = 0; i < 1000; i++) // Boucle principale
        {
            for (int j = 0; j < 1000; j++) // Boucle imbriqu�e
            {
                // multiplication de matrices
                MatrixMultiplication();
            }
        }
    }

    private void MatrixMultiplication()
    {
        // Simulation d'une op�ration de multiplication de matrices
        float[,] matrixA = new float[10, 10];
        float[,] matrixB = new float[10, 10];
        float[,] result = new float[10, 10];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }
    }

    */
}
