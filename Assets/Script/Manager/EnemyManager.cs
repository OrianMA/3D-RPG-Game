using BaseTemplate.Behaviours;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [SerializeField] private List<EnemyController> enemyInMap = new();


    public void AddEnemy(EnemyController enemy)
    {
        enemyInMap.Add(enemy);
    }

    public void RemoveEnemy(EnemyController enemy)
    {
        enemyInMap.Remove(enemy);
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
