using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsEquipWeapon;

    [SerializeField] private Weapon _weaponEquip;
    [SerializeField] private Transform _weaponTransformParent;

    public void Attack()
    {
        _weaponEquip.OnAttack();
    }

    public void Equip(Weapon weapon)
    {
        _weaponEquip = weapon;
        _weaponEquip.Init(_weaponTransformParent, 1);
        IsEquipWeapon = true;
    }

    public void BeforeAttack()
    {
        _weaponEquip.OnBeforeAttack();
    }
}
