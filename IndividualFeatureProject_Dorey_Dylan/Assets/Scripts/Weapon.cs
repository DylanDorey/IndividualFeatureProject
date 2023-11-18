using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/.............................../2023]
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

    //Location where the weapon will interpolate to when aiming down sights
    public GameObject adsLowLocation;
    public Vector3 adsHighLocation;

    //all gunsmith attachment slot camera locations
    public Transform opticCamPos;
    public Transform laserCamPos;
    public Transform barrelCamPos;
    public Transform muzzleCamPos;
    public Transform gripCamPos;
    public Transform magazineCamPos;
    public Transform rearGripCamPos;
    public Transform stockCamPos;

    //audio clips for weapon
    public AudioClip fireSound;

    //all weapon properties
    public string weaponType, weaponName, weaponDescription;
    public Sprite icon;
    public float damage, fireRate, range, accuracy, recoilControl, mobility, handling;

    //number of modifications the weapon currently has
    public int modifications;

    //ammo related properties
    public int magSize, reserveAmmoSize;
    public GameObject bulletType;

    //attachments currently on the weapon
    public GameObject[] weaponAttachments = new GameObject[9];

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
