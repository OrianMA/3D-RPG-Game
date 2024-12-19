using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObjects/Weapon/Sword", order = 1)]
public class Sword : Weapon
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackLenght;
    public override void OnAttack()
    {
        base.OnAttack();

        RaycastHit hit;
        Vector3 p1 = _weaponUser.transform.position + Vector3.up * .5f;
        Vector3 p2 = p1 + Vector3.forward * _attackLenght;

        // Cast character controller shape 10 meters forward to see if it is about to hit anything.
        if (Physics.CapsuleCast(p1, p2, _attackRadius, _weaponUser.transform.forward, out hit, 10, enemyLayer))
        {
            Debug.Log(hit.collider.name);
            
            EntityHealth entityHealth = hit.collider.GetComponent<EntityHealth>();
            entityHealth.TakeDamage(_damage);
        }
    }
}
