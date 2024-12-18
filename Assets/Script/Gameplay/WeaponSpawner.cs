using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _weaponVisualParent;
    [SerializeField] private float newScale;

    private void Start()
    {
        _weapon.Init(_weaponVisualParent, newScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.GetComponent<PlayerController>().PlayerAttack.Equip(_weapon);
        }
    }
}