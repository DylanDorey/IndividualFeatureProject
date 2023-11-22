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
    //optics
    public GameObject std_ironsights;
    public GameObject reddot;
    public GameObject scope;

    //lasers
    public GameObject laser1;
    public GameObject laser2;

    //barrels
    public GameObject std_barrel;
    public GameObject longbarrel;
    public GameObject shortbarrel;

    //muzzles
    public GameObject compensator;
    public GameObject suppressor;

    //grips
    public GameObject angled;
    public GameObject stubby;

    //magazines
    public GameObject std_magazine;
    public GameObject extended;
    public GameObject highcaliber;
    public GameObject lightweight;

    //rear grips
    public GameObject std_reargrip;
    public GameObject sticky;
    public GameObject tactile;

    //stocks
    public GameObject std_stock;
    public GameObject precision;
    public GameObject none;

    private void Start()
    {
        //add attachments to their appropriate arrays
        InitializeAttachmentsArray();

        for (int index = 0; index < weaponAttachments.Length; index++)
        {
            weaponAttachments[index] = null;
        }
    }

    /// <summary>
    /// adds all attachments to attachment type arrays
    /// </summary>
    private void InitializeAttachmentsArray()
    {
        optics = new GameObject[3] { std_ironsights, reddot, scope };
        lasers = new GameObject[2] { laser1, laser2 };
        barrels = new GameObject[3] { std_barrel, longbarrel, shortbarrel };
        muzzles = new GameObject[2] { compensator, suppressor };
        grips = new GameObject[2] { angled, stubby };
        magazines = new GameObject[4] { std_magazine, extended, highcaliber, lightweight };
        rearGrips = new GameObject[3] { std_reargrip, sticky, tactile };
        stocks = new GameObject[3] { std_stock, precision, none };
    }
}
