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
        {
            Debug.Log("Player is already dead");
            return;
        }
        target.TakeDamage(damage);
        // Debug.Log("Bang bang");
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
