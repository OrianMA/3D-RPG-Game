using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsEquipWeapon;
    public bool IsAttack;

    [SerializeField] private Weapon _weaponEquip;
    [SerializeField] private Transform _weaponTransformParent;
    [SerializeField] private Animator _playerAttackAnimator;

    private WeaponVisual _weaponVisual;
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
        _weaponEquip.Init(_weaponTransformParent, transform.parent.gameObject, _playerAttackAnimator);
        _weaponVisual = _weaponEquip.WeaponVisualInstantiate;
        IsEquipWeapon = true;
    }

    public void EnableWeaponVisual()
    {
        _weaponVisual.OnAttack();
    }
    public void DisableWeaponVisual()
    {
        if (_weaponVisual)
            _weaponVisual.StopAttack();
    }

}
