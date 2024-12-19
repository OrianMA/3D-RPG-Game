using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObjects/Weapon/Sword", order = 1)]
public class Sword : Weapon
{

    public override void OnAttack()
    {
        base.OnAttack();

        // The position of the capsuleCast
        Vector3 p1 = _weaponUser.transform.position;
        Vector3 p2 = _weaponUser.transform.position + _weaponUser.transform.forward * _attackLenght;


        // Cast the attack base on attack range
        foreach (RaycastHit targetHit in Physics.CapsuleCastAll(p1, p2, _attackRadius, _weaponUser.transform.forward, _attackLenght, enemyLayer))
        {
            EntityHealth entityHealth = targetHit.collider.GetComponent<EntityHealth>();
            entityHealth.TakeDamage(_damage);
        }
    }
}
