using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; 
    bool isProvoked = false; // The enemy is provoked
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            // navMeshAgent.SetDestination(target.position);
        }
    }
    private void EngageTarget()
    {
        // FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        // GetComponent<Animator>().SetBool("attack", true);
        Debug.Log(name + " has attacked and detroying " + target.name);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
