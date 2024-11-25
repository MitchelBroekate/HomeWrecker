using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/class WeaponSO", order = 1)]
public class WeaponSO : ScriptableObject
{
    #region Variables
    [Header("Config Variables")]
    [SerializeField] int _damage;
    [SerializeField] int _range;
    [SerializeField] float _weaponCooldown;

    [Header("Linked Variables")]
    public GameObject weaponToInstantiate;
    #endregion

    public int Damage
    {
        get { return _damage; }
    }

    public int Range
    {
        get { return _range; }
    }

    public float WeaponCooldown
    {
        get { return _weaponCooldown;}
    }
}
