using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EntityHealth _entityHealth;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private Rigidbody _enemyRb;
    [SerializeField] private float _rotSpeed;
    [SerializeField] private ParticleSystem _takeDamageParticles;
    [SerializeField] private ParticleSystem _dieParticles;
    private void Start()
    {
        // Add the enemy to the enemy list so the manager can controle the number of enemy
        EnemyManager.Instance.AddEnemy(this);

        // Subscribe to some event
        _entityHealth.OnDieEvent.AddListener(OnEnemyDie);
        _entityHealth.OnTakeDamageEvent.AddListener(OnEnemyTakeDamage);

        // Adn chase enemy to the infinite
        StartCoroutine(ChaseEnemy());
    }

    IEnumerator ChaseEnemy()
    {
        // While enemy alive
        while (true) {

            // Rotate enemy and run forward to player 
            Vector3 enemyLookDirection = (PlayerController.Instance.transform.position - transform.position).normalized;
            float angleWanted = Mathf.Atan2(enemyLookDirection.x, enemyLookDirection.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Lerp(
                                                        transform.rotation,
                                                        Quaternion.Euler(0, angleWanted, 0),
                                                         _rotSpeed * Time.fixedDeltaTime);
    
            _enemyRb.velocity = transform.forward * _enemySpeed * Time.fixedDeltaTime;
            yield return null;
        }
    } 

    private void OnEnemyDie()
    {
        // Play particle and remove enemy from list
        _dieParticles.transform.parent = null;
        _dieParticles.Play();
        EnemyManager.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }

    private void OnEnemyTakeDamage()
    {
        _takeDamageParticles.Play();
    }

}