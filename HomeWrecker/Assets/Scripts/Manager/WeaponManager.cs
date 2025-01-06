using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
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
            for (int i = 0; i < cam.childCount; i++)
            {
                if(i != 0)
                {
                    Destroy(cam.GetChild(i).gameObject);
                }
            }
        }

        currentWeapon = "WeaponType_BAT";

        GameObject currentWeaponObject = Instantiate(weaponPrefab[0], weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;
    }

    /// <summary>
    /// This function checks if the player already has a weapon. If the player is holding a different weapon, the weapons will be switched when the corresponding button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void WeaponKey2(InputAction.CallbackContext context)
    {
        if(!context.performed || currentWeapon.Equals("WeaponType_AXE")) return;

        if(cam.childCount > 1)
        {
            for (int i = 0; i < cam.childCount; i++)
            {
                if(i != 0)
                {
                    Destroy(cam.GetChild(i).gameObject);
                }
            }
        }

        currentWeapon = "WeaponType_AXE";

        GameObject currentWeaponObject = Instantiate(weaponPrefab[1], weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;
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
            for (int i = 0; i < cam.childCount; i++)
            {
                if(i != 0)
                {
                    Destroy(cam.GetChild(i).gameObject);
                }
            }

        }

        currentWeapon = "WeaponType_KATANA";

        GameObject currentWeaponObject = Instantiate(weaponPrefab[2], weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;
    }

        /// <summary>
    /// This function checks if the player already has a weapon. If the player is holding a different weapon, the weapons will be switched when the corresponding button is pressed
    /// </summary>
    /// <param name="context"></param>
    public void WeaponKey4(InputAction.CallbackContext context)
    {
        if(!context.performed || currentWeapon.Equals("WeaponType_SLEDGE")) return;

        if(cam.childCount > 1)
        {
            for (int i = 0; i < cam.childCount; i++)
            {
                if(i != 0)
                {
                    Destroy(cam.GetChild(i).gameObject);
                }
            }
        }

        currentWeapon = "WeaponType_SLEDGE";

        GameObject currentWeaponObject = Instantiate(weaponPrefab[3], weaponSpawnpoint.position, weaponSpawnpoint.rotation);
        currentWeaponObject.transform.parent = cam;
    }
}