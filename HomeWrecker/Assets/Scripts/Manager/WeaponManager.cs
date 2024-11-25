using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    #region Variables
    [Header("Config Variables")]
    public string currentWeapon;
    [SerializeField] int weaponDamage;
    [SerializeField] int weaponRange;
    [SerializeField] float weaponCooldown;

    [Header("Linked Variables")]
    [SerializeField] Transform cam;
    [SerializeField] WeaponSO[] weaponSO;
    [SerializeField] Transform weaponSpawnpoint;
    #endregion

    /// <summary>
    /// This function gives the player his standard weapon
    /// </summary>
    void Start()
    {
        currentWeapon = "WeaponType_BAT";

        GameObject currentWeaponObject = Instantiate(weaponSO[0].weaponToInstantiate, weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;

        weaponDamage = weaponSO[0].Damage;
        weaponRange = weaponSO[0].Range;
        weaponCooldown = weaponSO[0].WeaponCooldown;
    }

    /// <summary>
    /// This function checks if the player already has a weapon. If the player is holding a different weapon, the weapons will be switched when the corresponding button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void WeaponKey1(InputAction.CallbackContext context)
    {
        if(!context.performed || currentWeapon.Equals("WeaponType_BAT")) return;

        if(cam.childCount > 1)
        {
            Destroy(cam.GetChild(1).gameObject);
        }

        currentWeapon = "WeaponType_BAT";

        GameObject currentWeaponObject = Instantiate(weaponSO[0].weaponToInstantiate, weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;

        weaponDamage = weaponSO[0].Damage;
        weaponRange = weaponSO[0].Range;
        weaponCooldown = weaponSO[0].WeaponCooldown;
    }

    /// <summary>
    /// This function checks if the player already has a weapon. If the player is holding a different weapon, the weapons will be switched when the corresponding button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void WeaponKey2(InputAction.CallbackContext context)
    {
        if(!context.performed || currentWeapon.Equals("WeaponType_SPIKED_BAT")) return;

        if(cam.childCount > 1)
        {
            Destroy(cam.GetChild(1).gameObject);
        }

        currentWeapon = "WeaponType_SPIKED_BAT";

        GameObject currentWeaponObject = Instantiate(weaponSO[1].weaponToInstantiate, weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;

        weaponDamage = weaponSO[1].Damage;
        weaponRange = weaponSO[1].Range;
        weaponCooldown = weaponSO[1].WeaponCooldown;
    }

    /// <summary>
    /// This function checks if the player already has a weapon. If the player is holding a different weapon, the weapons will be switched when the corresponding button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void WeaponKey3(InputAction.CallbackContext context)
    {
        if(!context.performed || currentWeapon.Equals("WeaponType_KATANA")) return;

        if(cam.childCount > 1)
        {
            Destroy(cam.GetChild(1).gameObject);
        }

        currentWeapon = "WeaponType_KATANA";

        GameObject currentWeaponObject = Instantiate(weaponSO[2].weaponToInstantiate, weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;

        weaponDamage = weaponSO[2].Damage;
        weaponRange = weaponSO[2].Range;
        weaponCooldown = weaponSO[2].WeaponCooldown;
    }
}