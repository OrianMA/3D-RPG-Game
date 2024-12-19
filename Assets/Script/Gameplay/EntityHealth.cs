using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



// Manager the health of any entity (Player - Enemy - Boss - Png ? Pet ? What you want with a life)
public class EntityHealth : MonoBehaviour
{
    public UnityEvent OnDieEvent; 
    public UnityEvent OnTakeDamageEvent; 
    [SerializeField] private int _lifePoint;

    private int _maxHealth; // Use for regeneration (in the future)

    private void Start()
    {
        _maxHealth = _lifePoint;
    }
    public void TakeDamage(int damage)
    {
        _lifePoint -= damage;
        OnTakeDamageEvent.Invoke();
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
