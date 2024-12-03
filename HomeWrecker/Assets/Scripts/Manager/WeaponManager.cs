using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    #region Variables
    [Header("Linked Variables")]
    [SerializeField] Transform cam;
    [SerializeField] GameObject[] weaponPrefab;
    [SerializeField] Transform weaponSpawnpoint;
    public string currentWeapon;
    #endregion

    /// <summary>
    /// This function gives the player his standard weapon
    /// </summary>
    void Start()
    {
        currentWeapon = "WeaponType_BAT";

        GameObject currentWeaponObject = Instantiate(weaponPrefab[0], weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;
        
        WeaponDoDamage weaponDoDamage = weaponPrefab[0].GetComponent<WeaponDoDamage>();
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

        GameObject currentWeaponObject = Instantiate(weaponPrefab[0], weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;

        WeaponDoDamage weaponDoDamage = weaponPrefab[0].GetComponent<WeaponDoDamage>();
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

        GameObject currentWeaponObject = Instantiate(weaponPrefab[1], weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;

        WeaponDoDamage weaponDoDamage = weaponPrefab[1].GetComponent<WeaponDoDamage>();
        
        //weaponDoDamage.SetDamage(weaponPrefab[1].Damage);
    }
}