using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionControl : MonoBehaviour
{
    [Range(0, 50)]
    public float rifleAmmoInMagazine = 25.0f;
    [Range(0, 200)]
    public float rifleTotalAmmoCount = 50.0f;

    [Range(0, 10)]
    public float pistolAmmoInMagazine = 5.0f;
    [Range(0, 50)]
    public float pistolTotalAmmoCount = 25.0f;

    [Range(0, 10)]
    public float heavyAmmoInMagazine = 5.0f;
    [Range(0, 50)]
    public float heavyTotalAmmoCount = 25.0f;

    [Range(0, 8)]
    public float sniperAmmoInMagazine = 4.0f;
    [Range(0, 60)]
    public float sniperTotalAmmoCount = 30.0f;
}
