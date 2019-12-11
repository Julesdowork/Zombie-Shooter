using UnityEngine;

public enum TypeControlAttack { Click, Hold }
public enum TypeWeapon { Melee, OneHand, TwoHand }
[System.Serializable]
public struct DefaultConfig
{
    public TypeControlAttack typeControl;
    public TypeWeapon typeWeapon;

    [Range(0, 100)]
    public int damage;
    [Range(0, 100)]
    public int criticalDamage;
    [Range(0.01f, 1)]
    public float fireRate;
    [Range(0, 100)]
    public int criticalRate;
}
