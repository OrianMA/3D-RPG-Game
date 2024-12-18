using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _lifePoint;
    [SerializeField] private int _damage;


    private void Start()
    {
        EnemyManager.Instance.AddEnemy(this);
    }
    public void TakeDamage(int damage)
    {
        _lifePoint -= damage;
        if (_lifePoint <= 0 )
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}