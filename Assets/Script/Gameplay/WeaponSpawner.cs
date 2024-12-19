using System.Collections;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _weaponVisualParent;
    [SerializeField] private ParticleSystem _PullWeaponParticles;

    private Weapon _weaponInstantiate;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        // Instantiate new weapon and assign it the the spawner
        _weaponInstantiate = Instantiate(_weapon);
        _weaponInstantiate.Init(_weaponVisualParent, gameObject);
    } 

    private void OnTriggerEnter(Collider other)
    {
        // Detect player an equip the weapon assign
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.GetComponent<PlayerController>().PlayerAttack.Equip(_weaponInstantiate);
            StartCoroutine(RespawnDelay());
            _PullWeaponParticles.Play();
        }
    }


    // Have a delay to respawn the weapon so the player can retake it
    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(5);
        Init();
    }
}
