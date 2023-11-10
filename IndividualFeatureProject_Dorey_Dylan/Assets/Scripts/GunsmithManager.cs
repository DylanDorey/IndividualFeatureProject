using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/...................../2023]
 * [Manage everything weapon related in the gunsmith]
 */
public class GunsmithManager : MonoBehaviour
{
    //singelton for GunsmithManager
    private GunsmithManager _instance;
    private GunsmithManager Instance { get { return _instance; } }

    private void Awake()
    {
        //if _instance contains something and it isn't this
        if (_instance != null && _instance != this)
        {
            //Destroy it
            Destroy(this.gameObject);
        }
        else
        {
            //otherwise set this to _instance
            _instance = this;
        }
    }

    /// <summary>
    /// allows the player to select a weapon from a list of weapons
    /// </summary>
    /// <param name="weaponChoice"> the weapon the player selects </param>
    /// <returns></returns>
    public GameObject ChooseWeapon(GameObject weaponChoice)
    {

        return weaponChoice;
    }

    /// <summary>
    /// equips an attachment from the attachment list onto the players weapon
    /// </summary>
    /// <param name="attachment"> the attachment the player selects to equip onto their weapon </param>
    public void EquipAttachment(GameObject attachment)
    {
        
        //change attachment slot color
    }

    /// <summary>
    /// removes an attachment from the attachment list onto the players weapon
    /// </summary>
    /// <param name="attachment"> the attachment the player selects to remove from their weapon </param>
    public void RemoveAttachment(GameObject attachment)
    {

    }

    /// <summary>
    /// equips the weapon from the gunsmith and puts it in the players hands
    /// </summary>
    /// <param name="weapon"> the weapon that the player selected with all of their attachments </param>
    public void EquipCompletedWeapon(GameObject weapon)
    {

    }
}
