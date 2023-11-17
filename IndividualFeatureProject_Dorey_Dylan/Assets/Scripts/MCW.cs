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
        for (int index = 0; index < weaponAttachments.Length; index++)
        {
            weaponAttachments[index] = null;
        }
    }
}
