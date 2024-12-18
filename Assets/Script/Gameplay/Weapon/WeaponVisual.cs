using System.Collections;
using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] TrailRenderer _trailRenderer;
    [SerializeField] float _animationDuration;
    public void OnAttack()
    {
        
    }

    //Force stop attack
    public void StopAttack()
    {
        StopAllCoroutines();
        _trailRenderer.enabled = false;
    }
    public void OnBeforeAttack()
    {
        StopAllCoroutines();
        StartCoroutine(EnableVisualAttack());
    }

    // Enable visual attack (trail)
    IEnumerator EnableVisualAttack()
    {
        yield return new WaitForSeconds(.4f);
        _trailRenderer.enabled = true;
        yield return new WaitForSeconds(_animationDuration);
        _trailRenderer.enabled = false;

    }
}
