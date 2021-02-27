using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class IA : MonoBehaviour
{
    private Transform cible;
    

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;


    private void Awake()
    {
        cible = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, cible.position) > agent.stoppingDistance)
        {
            animator.SetBool("Court", true);
            animator.SetBool("Attaquer", false);
            agent.SetDestination(cible.transform.position);
        }
        else
        {
            animator.SetBool("Court", false);
            animator.SetBool("Attaquer", true);
        }
    }
}
