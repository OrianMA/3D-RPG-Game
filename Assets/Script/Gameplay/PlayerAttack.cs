using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsEquipWeapon;
    public bool IsAttack;

    [SerializeField] private Weapon _weaponEquip;
    [SerializeField] private Transform _weaponTransformParent;

    // Call in attack animation
    public void Attack()
    {
        IsAttack = true;
        _weaponEquip.OnAttack();
    }

    // Force stop attack on player move
    public void StopAttack()
    {
        IsAttack = false;
        _weaponEquip.StopAttack();
    }

    // Equip weapon, use on spawner
    public void Equip(Weapon weapon)
    {
        _weaponEquip = weapon;
        _weaponEquip.Init(_weaponTransformParent, 1);
        IsEquipWeapon = true;
    }

    // Call first frame of attack animation
    public void BeforeAttack()
    {
        _weaponEquip.OnBeforeAttack();
    }
}
