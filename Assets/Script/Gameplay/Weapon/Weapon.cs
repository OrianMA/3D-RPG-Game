using UnityEngine;

public class Weapon : ScriptableObject
{
    [SerializeField] protected float _animationAttackSpeed = 1;
    [SerializeField] protected WeaponVisual _weaponVisual;

    private WeaponVisual _weaponVisualInstantiate;

    public virtual void Init(Transform weaponParent, float newScale)
    {
        if (_weaponVisualInstantiate)
            _weaponVisualInstantiate.transform.parent = weaponParent;
        else
            _weaponVisualInstantiate = Instantiate(_weaponVisual, weaponParent);

        _weaponVisualInstantiate.transform.localScale = Vector3.one * newScale;
        _weaponVisualInstantiate.transform.localPosition = Vector3.zero;
        _weaponVisualInstantiate.transform.localRotation = Quaternion.Euler(0,0,0);
    }

    public virtual void OnAttack()
    {
        _weaponVisualInstantiate.OnAttack();

        Debug.Log("Attack");
    }

    public virtual void OnBeforeAttack()
    {
        _weaponVisualInstantiate.OnBeforeAttack();
    }
}
