using UnityEngine;

public class PlayerAttackZone : MonoBehaviour
{
    [Header("Attack characteristics")]
    [SerializeField] private float playerAttackRange;
    [SerializeField] private float playerAttackDamage = 0.5f;

    private bool IsEnemyInRange = false;

    private void Start()
    {
        IsEnemyInRange = false;
        transform.localScale = new Vector3(playerAttackRange, transform.localScale.y, transform.localScale.z);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHitbox"))
        {
            Debug.Log("Enemy in attack range");
            IsEnemyInRange = true;
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1") && IsEnemyInRange == true)
        {
            Debug.Log("Attack");
        }
    }

    private void Update()
    {
        Attack();
    }
}
