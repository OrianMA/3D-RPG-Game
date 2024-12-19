using UnityEngine;

// Scriptable object to make every stats of weapon you want
public class Weapon : ScriptableObject
{
    [SerializeField] protected float _animationAttackSpeed = 1;
    [SerializeField] protected WeaponVisual _weaponVisual;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackRadius;
    [SerializeField] protected float _attackLenght;

    public float GetAttackLenght() => _attackLenght;

    // Gameobject visual
    public WeaponVisual WeaponVisualInstantiate;
    protected GameObject _weaponUser;
    public virtual void Init(Transform weaponVisualParent, GameObject weaponUser, Animator attackAnimator = null)
    {
        // if the weapon already instantiate
        if (WeaponVisualInstantiate)
            WeaponVisualInstantiate.transform.parent = weaponVisualParent;
        else
            WeaponVisualInstantiate = Instantiate(_weaponVisual, weaponVisualParent);

        _weaponUser = weaponUser;

        // Reset the transform component
        WeaponVisualInstantiate.transform.localPosition = Vector3.zero;
        WeaponVisualInstantiate.transform.localRotation = Quaternion.Euler(0,0,0);

        if (attackAnimator != null)
            attackAnimator.SetFloat("AttackSpeed", _animationAttackSpeed);
    }

    // Call in animation, all the attack sytem are here
    public virtual void OnAttack()
    {

    }
    public virtual void StopAttack()
    {
        WeaponVisualInstantiate.StopAttack();
    }

}
