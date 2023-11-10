using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/.............................../2023]
 * [Contains all weapon properties and base behaviors]
 */

//the type of weapon the gun is
public enum WeaponType
{
    assaultRifle,
    subMachineGun
}

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
    public Vector3 opticLocation, laserLocation, barrelLocation, muzzleLocation, gripLocation, magazineLocation, rearGripLocation;

    //Location where the weapon will interpolate to when aiming down sights
    public Vector3 adsLowLocation;
    public Vector3 adsHighLocation;

    //audio clips for weapon
    public AudioClip fireSound;

    //all weapon properties
    public string weaponName;
    public Sprite icon;
    public float damage, fireRate, range, accuracy, recoilControl, mobility, handling;

    //number of modifications the weapon currently has
    public int modifications;

    //ammo related properties
    public int magSize, reserveAmmoSize;
    public GameObject bulletType;

    //attachments currently on the weapon
    public GameObject[] weaponAttachments = new GameObject[8];

    /// <summary>
    /// Adds recoil to the weapon when shot based upon various attachment/weapon properties
    /// </summary>
    public void AddRecoil()
    {

    }

    /// <summary>
    /// Affects the accuracy of the weapon when it is shot
    /// </summary>
    public void AffectAccuracy()
    {

    }
}
