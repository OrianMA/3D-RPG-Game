using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyParent;

    [SerializeField] private float _delayToSpawn;
    [SerializeField] private int _numberEnemyToSpawn;
    [SerializeField] private List<GameObject> _enemyToSpawn;
    [SerializeField] private float _radiusOfSpawn;

    public void Start()
    {
        StartCoroutine(SpawnEnemyDelay());
    }

    private IEnumerator SpawnEnemyDelay()
    {
        while (true)
        {
            // If there are full of enemy in map, justt not spawn
            if (!EnemyManager.Instance.IsFullEnemy && EnemyManager.Instance.CanSpawnEnemy)
            {
                // Wait to spawn enemy
                yield return new WaitForSeconds(_delayToSpawn);

                // Spawn number of enemy wanted
                for (int i = 0; i < _numberEnemyToSpawn; i++)
                {
                    // Instantiate and place in random circle pose 
                    GameObject newEnemy = Instantiate(_enemyToSpawn[Random.Range(0, _enemyToSpawn.Count)], _enemyParent);
                    Vector2 randPos = Random.insideUnitCircle * _radiusOfSpawn;
                    newEnemy.transform.position = transform.position + new Vector3(randPos.x, 0, randPos.y);
                    
                    yield return new WaitForEndOfFrame();
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
