using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/14/2023]
 * [MCW assault rifle script]
 */
public class MCW : Weapon
{
    ////optics
    //public GameObject std_ironsights;
    //public GameObject reddot;
    //public GameObject scope;
    ////lasers
    //public GameObject laser1;
    //public GameObject laser2;
    ////barrels
    //public GameObject std_barrel;
    //public GameObject longbarrel;
    //public GameObject shortbarrel;
    ////muzzles
    //public GameObject compensator;
    //public GameObject suppressor;
    ////grips
    //public GameObject angled;
    //public GameObject stubby;
    ////magazines
    //public GameObject std_magazine;
    //public GameObject extended;
    //public GameObject highcaliber;
    //public GameObject lightweight;
    ////rear grips
    //public GameObject std_reargrip;
    //public GameObject sticky;
    //public GameObject tactile;
    ////stocks
    //public GameObject std_stock;
    //public GameObject precision;
    //public GameObject none;

    private void Start()
    {
        //remove all attachments from the weapon
        for (int index = 0; index < weaponAttachments.Length; index++)
        {
            weaponAttachments[index] = null;
        }
    }

    private void Update()
    {
        //if the attachments are empty, put standard attachments on
        if (weaponAttachments[0] == null)
        {
            weaponAttachments[0] = optics[0];
            optics[0].SetActive(true);
        }
        else if (weaponAttachments[2] == null)
        {
            weaponAttachments[2] = barrels[0];
            barrels[0].SetActive(true);

            //set the muzzle location to the end of the current barrel
            muzzleLocation = weaponAttachments[2].gameObject.transform.GetChild(0).gameObject;
        }
        else if (weaponAttachments[5] == null)
        {
            weaponAttachments[5] = magazines[0];
            magazines[0].SetActive(true);
        }
        else if (weaponAttachments[6] == null)
        {
            weaponAttachments[6] = rearGrips[0];
            rearGrips[0].SetActive(true);
        }
        else if (weaponAttachments[7] == null)
        {
            weaponAttachments[7] = stocks[0];
            stocks[0].SetActive(true);
        }
    }

    ///// <summary>
    ///// adds all attachments to attachment type arrays
    ///// </summary>
    //private void InitializeAttachmentsArray()
    //{ 
    //    optics = new GameObject[3] { std_ironsights, reddot, scope };
    //    lasers = new GameObject[2] { laser1, laser2 };
    //    barrels = new GameObject[3] { std_barrel, longbarrel, shortbarrel };
    //    muzzles = new GameObject[2] { compensator, suppressor };
    //    grips = new GameObject[2] { angled, stubby };
    //    magazines = new GameObject[4] { std_magazine, extended, highcaliber, lightweight };
    //    rearGrips = new GameObject[3] { std_reargrip, sticky, tactile };
    //    stocks = new GameObject[3] { std_stock, precision, none };
    //}
}
