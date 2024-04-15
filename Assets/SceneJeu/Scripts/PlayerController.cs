using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    protected NavMeshAgent player;
    public Transform[] goals;
    private List<int> visitedGoals = new List<int>();

    protected virtual void Start()
    {
        player = GetComponent<NavMeshAgent>();
        SetRandomGoal();
    }

    protected virtual void Update()
    {
        if (player.remainingDistance <= player.stoppingDistance)
        {
            SetRandomGoal();
        }
    }

    void SetRandomGoal()
    {
        // Si tous les buts ont été visités, réinitialiser la liste des buts visités
        if (visitedGoals.Count == goals.Length)
        {
            visitedGoals.Clear();
        }

        // Choisir un nouvel index de but aléatoire parmi les buts non visités
        int newGoalIndex;
        do
        {
            newGoalIndex = Random.Range(0, goals.Length);
        } while (visitedGoals.Contains(newGoalIndex));

        // Mettre à jour la liste des buts visités
        visitedGoals.Add(newGoalIndex);

        // Définir la destination du personnage vers le nouveau but
        player.SetDestination(goals[newGoalIndex].position);
    }
}
