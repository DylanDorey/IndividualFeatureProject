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
    private void Start()
    {
        //remove all attachments from the weapons attachment array
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
}
