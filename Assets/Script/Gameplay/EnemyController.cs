using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EntityHealth _entityHealth;
    private void Start()
    {
        EnemyManager.Instance.AddEnemy(this);
        _entityHealth.OnDieEvent.AddListener(OnEnemyDie);
    }

    private void OnEnemyDie()
    {
        EnemyManager.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }

}