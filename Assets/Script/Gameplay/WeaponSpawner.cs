using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _weaponVisualParent;
    [SerializeField] private float newScale;

    private void Start()
    {
        _weapon.Init(_weaponVisualParent, gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect player an equip the weapon assign
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.GetComponent<PlayerController>().PlayerAttack.Equip(_weapon);
        }
    }
}
