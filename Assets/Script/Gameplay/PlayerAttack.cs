using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsEquipWeapon;
    public bool IsAttack;

    [SerializeField] private Weapon _weaponEquip;
    [SerializeField] private Transform _weaponTransformParent;
    [SerializeField] private Animator _playerAttackAnimator;
    [SerializeField] private LineRenderer _playerLineAttackRenderer;

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
        DisableWeaponVisual();
    }

    // Equip weapon, use on spawner
    public void Equip(Weapon weapon)
    {
        // Is player already have weapon, so destroy it
        if (IsEquipWeapon) {
            _weaponEquip.StopAttack();
            _playerLineAttackRenderer.enabled = false;
            Destroy(_weaponVisual.gameObject);
        }

        // Init and equip the new weapon
        _weaponEquip = weapon;
        _weaponEquip.Init(_weaponTransformParent, transform.parent.gameObject, _playerAttackAnimator);
        _weaponVisual = _weaponEquip.WeaponVisualInstantiate;


        // Set the attack lenght visual
        _playerLineAttackRenderer.SetPosition(1, _playerLineAttackRenderer.GetPosition(0) +Vector3.forward * _weaponEquip.GetAttackLenght());
        IsEquipWeapon = true;

        // Use for start game, if the player dont take weapon, enemy dont spawn
        EnemyManager.Instance.CanSpawnEnemy = true;
    }

    // Enable visual on player attack
    public void EnableWeaponVisual()
    {
        _weaponVisual.OnAttack();
        _playerLineAttackRenderer.enabled = true;
    }

    // Disable the weapon visual attack
    public void DisableWeaponVisual()
    {
        if (!_weaponVisual)
            return;

        _playerLineAttackRenderer.enabled = false;
    }

}
