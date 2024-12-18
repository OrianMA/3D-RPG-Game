using System.Collections;
using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] TrailRenderer _trailRenderer;
    [SerializeField] float _animationDuration;
    public void OnAttack()
    {
        //StartCoroutine(EnableVisualAttack());
    }
    public void OnBeforeAttack()
    {
        StartCoroutine(EnableVisualAttack());
    }

    IEnumerator EnableVisualAttack()
    {
        yield return new WaitForSeconds(.1f);
        _trailRenderer.enabled = true;
        yield return new WaitForSeconds(_animationDuration);
        _trailRenderer.enabled = false;

    }
}
