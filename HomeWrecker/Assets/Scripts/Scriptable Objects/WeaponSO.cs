using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/class WeaponSO", order = 1)]
public class WeaponSO : ScriptableObject
{
    #region Variables
    [Header("Config Variables")]
    [SerializeField] int damage;

    [Header("Linked Variables")]
    public GameObject weaponToInstantiate;
    #endregion

    public int Damage
    {
        get { return damage; }
    }
}
