using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponController> weaponsUnlocked;
    public WeaponController[] totalWeapons;
    [HideInInspector]
    public WeaponController currentWeapon;

    public GameObject meleeDamagePoint;

    private int currentWeaponIndex;
    private TypeControlAttack currentTypeControl;
    private PlayerArmController[] armControllers;
    private PlayerAnimations playerAnim;
    private bool isShooting;

    void Awake()
    {
        playerAnim = GetComponent<PlayerAnimations>();
        LoadActiveWeapons();
        currentWeaponIndex = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        armControllers = GetComponentsInChildren<PlayerArmController>();
        ChangeWeapon(weaponsUnlocked[1]);   // set the first weapon to be the pistol
        playerAnim.SwitchWeaponAnimation(
            (int)weaponsUnlocked[currentWeaponIndex].defaultConfig.typeWeapon);
    }

    void LoadActiveWeapons()
    {
        weaponsUnlocked.Add(totalWeapons[0]);

        for (int i = 1; i < totalWeapons.Length; i++)
        {
            weaponsUnlocked.Add(totalWeapons[i]);
        }
    }

    public void SwitchWeapon()
    {
        currentWeaponIndex++;
        currentWeaponIndex =
            (currentWeaponIndex >= weaponsUnlocked.Count) ? 0 : currentWeaponIndex;
        playerAnim.SwitchWeaponAnimation(
            (int)weaponsUnlocked[currentWeaponIndex].defaultConfig.typeWeapon);
        ChangeWeapon(weaponsUnlocked[currentWeaponIndex]);
    }

    void ChangeWeapon(WeaponController newWeapon)
    {
        if (currentWeapon)
            currentWeapon.gameObject.SetActive(false);

        currentWeapon = newWeapon;
        currentTypeControl = newWeapon.defaultConfig.typeControl;
        newWeapon.gameObject.SetActive(true);

        if (newWeapon.defaultConfig.typeWeapon == TypeWeapon.TwoHand)
        {
            for (int i = 0; i < armControllers.Length; i++)
                armControllers[i].ChangeToTwoHand();
        }
        else
        {
            for (int i = 0; i < armControllers.Length; i++)
                armControllers[i].ChangeToOneHand();
        }
    }

    public void Attack()
    {
        if (currentTypeControl == TypeControlAttack.Hold)
        {
            currentWeapon.CallAttack();
        }
        else if (currentTypeControl == TypeControlAttack.Click)
        {
            if (!isShooting)
            {
                currentWeapon.CallAttack();
                isShooting = true;
            }
        }
    }

    public void ResetAttack()
    {
        isShooting = false;
    }

    public void AllowCollisionDetection()
    {
        meleeDamagePoint.SetActive(true);
    }

    public void DenyCollisionDetection()
    {
        meleeDamagePoint.SetActive(false);
    }
}
