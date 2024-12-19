using System.Collections;
using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] TrailRenderer _trailRenderer;
    public void OnAttack()
    {
        _trailRenderer.enabled = true;
    }

    //Force stop attack
    public void StopAttack()
    {
        _trailRenderer.enabled = false;
    }
}
