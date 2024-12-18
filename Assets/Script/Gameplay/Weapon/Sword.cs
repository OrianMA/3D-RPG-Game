using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObjects/Weapon/Sword", order = 1)]
public class Sword : Weapon
{
    public override void OnAttack()
    {
        base.OnAttack();
    }
}
