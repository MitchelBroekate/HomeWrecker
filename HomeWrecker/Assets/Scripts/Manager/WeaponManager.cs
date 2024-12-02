using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    #region Variables
    [Header("Linked Variables")]
    public string currentWeapon;

    int weaponDamage;
    int weaponRange;
    float weaponCooldown;

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
        
        WeaponDoDamage weaponDoDamage = weaponSO[0].weaponToInstantiate.GetComponent<WeaponDoDamage>();

        weaponDamage = weaponSO[0].Damage;
        weaponCooldown = weaponSO[0].WeaponCooldown;
        
        weaponDoDamage.SetDamage(weaponDamage);
        weaponDoDamage.SetCooldown(weaponCooldown);
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

        WeaponDoDamage weaponDoDamage = weaponSO[0].weaponToInstantiate.GetComponent<WeaponDoDamage>();

        weaponDamage = weaponSO[0].Damage;
        weaponCooldown = weaponSO[0].WeaponCooldown;
        
        weaponDoDamage.SetDamage(weaponDamage);
        weaponDoDamage.SetCooldown(weaponCooldown);
    }

    /// <summary>
    /// This function checks if the player already has a weapon. If the player is holding a different weapon, the weapons will be switched when the corresponding button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void WeaponKey2(InputAction.CallbackContext context)
    {
        if(!context.performed || currentWeapon.Equals("WeaponType_KATANA")) return;

        if(cam.childCount > 1)
        {
            Destroy(cam.GetChild(1).gameObject);
        }

        currentWeapon = "WeaponType_KATANA";

        GameObject currentWeaponObject = Instantiate(weaponSO[1].weaponToInstantiate, weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;

        WeaponDoDamage weaponDoDamage = weaponSO[1].weaponToInstantiate.GetComponent<WeaponDoDamage>();

        weaponDamage = weaponSO[1].Damage;
        weaponCooldown = weaponSO[1].WeaponCooldown;
        
        weaponDoDamage.SetDamage(weaponDamage);
        weaponDoDamage.SetCooldown(weaponCooldown);
    }
}