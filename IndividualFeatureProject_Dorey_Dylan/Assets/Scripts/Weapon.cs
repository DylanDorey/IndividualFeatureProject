using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/18/2023]
 * [Contains all weapon properties and base behaviors]
 */

//the type of weapon the gun is
public enum FireMode
{
    semi,
    burst,
    auto
}

public class Weapon : MonoBehaviour
{
    //Locations where all of the attachments will attach to on the weapon
    public GameObject opticLocation, laserLocation, barrelLocation, muzzleLocation, gripLocation, magazineLocation, rearGripLocation, stockLocation;

    //all gunsmith attachment slot camera locations
    public Transform opticCamPos, laserCamPos, barrelCamPos, muzzleCamPos, gripCamPos, magazineCamPos, rearGripCamPos, stockCamPos;

    //various attachment arrays
    public GameObject[] optics;
    public GameObject[] lasers;
    public GameObject[] barrels;
    public GameObject[] muzzles;
    public GameObject[] grips;
    public GameObject[] magazines;
    public GameObject[] rearGrips;
    public GameObject[] stocks;

    //all weapon properties
    public string weaponType, weaponName, weaponDescription;
    public Sprite icon;
    public float damage, fireRate, range, accuracy, recoilControl, mobility, handling;

    //number of modifications the weapon currently has
    public int modifications;

    //ammo related properties
    public int magSize, reserveAmmoSize;

    //attachments currently on the weapon
    public GameObject[] weaponAttachments = new GameObject[8];
}
