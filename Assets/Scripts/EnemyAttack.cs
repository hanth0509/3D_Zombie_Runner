using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;

    [SerializeField]
    float damage = 40f;

    void Start()
    {
        target = FindFirstObjectByType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null)
            return;
        target.TakeDamage(damage);
        Debug.Log("Bang bang");
    }
}
