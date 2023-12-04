using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/16/2023]
 * [This will contain all properties for an attachment]
 */

public class AttachmentData : MonoBehaviour
{
    //attachment attributes
    public Sprite icon;
    public string attachmentType;
    public string attachmentName;
    public string description;

    [TextArea]
    public string pros;
    [TextArea]
    public string cons;

    public float damageChange;
    public float fireRateChange;
    public float rangeChange;
    public float accuracyChange;
    public float recoilControlChange;
    public float mobilityChange;
    public float handlingChange;

    public int ammoChange;
    public int ammoReserveChange;
}
