using BaseTemplate.Behaviours;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    public bool IsFullEnemy;
    public bool CanSpawnEnemy;
    [SerializeField] private List<EnemyController> enemyInMap = new();
    [SerializeField] private int _maxEnemyInMap;


    public void AddEnemy(EnemyController enemy)
    {
        // The list are use to know who is the nearest to player and controle the mass (quatity of enemy)
        enemyInMap.Add(enemy);
        if (enemyInMap.Count >= _maxEnemyInMap)
        {
            IsFullEnemy = true;
        }
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        enemyInMap.Remove(enemy);
        IsFullEnemy = false;
    }

    public EnemyController GetNearestEnemy(Vector3 pos)
    {
        if (enemyInMap.Count <= 0) 
            return null;


        // Create list of Enemy and his distance to pos
        List<KeyValuePair<EnemyController, float>> distance = new();

        // Add the enemy and calcule distance to pos
        foreach (var hookPoint in enemyInMap)
        {
            distance.Add(new KeyValuePair<EnemyController, float>(hookPoint, Vector3.Distance(pos, hookPoint.transform.position)));
        }

        // Sort the list to have the nearest pos in first
        distance.Sort((a, b) => a.Value.CompareTo(b.Value));

        // Return the first so the nearest
        return distance[0].Key;
    }
}
