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
        // Si tous les buts ont �t� visit�s, r�initialiser la liste des buts visit�s
        if (visitedGoals.Count == goals.Length)
        {
            visitedGoals.Clear();
        }

        // Choisir un nouvel index de but al�atoire parmi les buts non visit�s
        int newGoalIndex;
        do
        {
            newGoalIndex = Random.Range(0, goals.Length);
        } while (visitedGoals.Contains(newGoalIndex));

        // Mettre � jour la liste des buts visit�s
        visitedGoals.Add(newGoalIndex);

        // D�finir la destination du personnage vers le nouveau but
        player.SetDestination(goals[newGoalIndex].position);
    }
}
