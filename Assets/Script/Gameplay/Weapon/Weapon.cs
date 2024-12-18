using UnityEngine;

// Scriptable object to make every stats of weapon you want
public class Weapon : ScriptableObject
{
    [SerializeField] protected float _animationAttackSpeed = 1;
    [SerializeField] protected WeaponVisual _weaponVisual;

    // Gameobject visual
    private WeaponVisual _weaponVisualInstantiate;

    public virtual void Init(Transform weaponParent, float newScale)
    {
        // if the weapon already instantiate
        if (_weaponVisualInstantiate)
            _weaponVisualInstantiate.transform.parent = weaponParent;
        else
            _weaponVisualInstantiate = Instantiate(_weaponVisual, weaponParent);


        // Reset the transform component
        _weaponVisualInstantiate.transform.localScale = Vector3.one * newScale;
        _weaponVisualInstantiate.transform.localPosition = Vector3.zero;
        _weaponVisualInstantiate.transform.localRotation = Quaternion.Euler(0,0,0);
    }

    // Call in animation, all the attack sytem are here
    public virtual void OnAttack()
    {
        _weaponVisualInstantiate.OnAttack();
    }
    public virtual void StopAttack()
    {
        _weaponVisualInstantiate.StopAttack();
    }

    public virtual void OnBeforeAttack()
    {
        _weaponVisualInstantiate.OnBeforeAttack();
    }
}
