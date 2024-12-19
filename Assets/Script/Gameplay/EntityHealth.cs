using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{
    public UnityEvent OnDieEvent; 
    [SerializeField] private int _lifePoint;

    private int _maxHealth;

    private void Start()
    {
        _maxHealth = _lifePoint;
    }
    public void TakeDamage(int damage)
    {
        _lifePoint -= damage;
        if (_lifePoint <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDieEvent.Invoke();
        //Destroy(gameObject);
    }
}
