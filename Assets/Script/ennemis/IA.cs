using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    private GameObject targetedPlayer;
    private NavMeshAgent agentEnnemi;

    private void Awake()
    {
       agentEnnemi = GetComponent<NavMeshAgent>();
       targetedPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        
    }

    void Update()
    {
        agentEnnemi.SetDestination(targetedPlayer.transform.position);
    }
}
