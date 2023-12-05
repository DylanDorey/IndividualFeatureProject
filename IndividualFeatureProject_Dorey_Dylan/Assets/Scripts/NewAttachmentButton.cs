using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/16/2023]
 * [This will display the attachment type, name, description, pros, and cons when the attachment button is hovered over]
 */

public class NewAttachmentButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //the attachment in the attachment button
    public GameObject attachment;

    //attachment button properties
    public GameObject attachmentCheckMark;
    public GameObject attachmentImage;
    public TextMeshProUGUI attachmentName;
    public GameObject equippedText;

    public void OnPointerDown(PointerEventData eventData)
    {
        //set attachment slot attachmentInSlot and current weapons attachments
        //IF OPTIC IF LASER< IF BARREL, etc set 
        if (attachment.GetComponent<AttachmentData>().attachmentType == "optic")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[0].name).SetActive(false);
            GunsmithManager.Instance.opticSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[0] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "laser")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            if (GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[1] != null)
            {
                GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[1].name).SetActive(false);
            }
            GunsmithManager.Instance.laserSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[1] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "barrel")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[2].name).SetActive(false);
            GunsmithManager.Instance.barrelSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[2] = attachment;

            //set the muzzle location to the end of the new barrel
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().muzzleLocation.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[2].gameObject.transform.GetChild(0).gameObject.transform.position;

            //if there is a muzzle equipped
            if (GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[3] != null)
            {
                //move the muzzle back to its appropriate location 
                GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[3].transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().muzzleLocation.transform.position;
            }
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "muzzle")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            if (GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[3] != null)
            {
                GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[3].name).SetActive(false);
            }
            GunsmithManager.Instance.muzzleSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[3] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "grip")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            if (GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[4] != null)
            {
                GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[4].name).SetActive(false);
            }
            GunsmithManager.Instance.gripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[4] = attachment;
        }
        else if(attachment.GetComponent<AttachmentData>().attachmentType == "magazine")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[5].name).SetActive(false);
            GunsmithManager.Instance.magazineSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[5] = attachment;

            //change ammo amounts
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().magSize = attachment.GetComponent<AttachmentData>().ammoChange;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().reserveAmmoSize = attachment.GetComponent<AttachmentData>().ammoReserveChange;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "rearGrip")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[6].name).SetActive(false);
            GunsmithManager.Instance.rearGripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[6] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "stock")
        {
            //Remove previous attachment, set the attachment in the slot to the attachment that was clicked, and add the attachment to the weapons attachment array
            GameObject.Find(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[7].name).SetActive(false);
            GunsmithManager.Instance.stockSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[7] = attachment;
        }

        //apply the stat changes to the gunsmith stat bars
        ChangeWeaponStats();

        //equip the attachment to the attachment slot once the player clicks on the button
        GunsmithManager.Instance.EquipAttachment(attachment);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //display the attachment type, name, description, pros, and cons when the attachment button is hovered over
        UIManager.Instance.OnAttachmentButtonEnter(attachment);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //setactive on the attachment type, name, description, pros, and cons
        UIManager.Instance.OnAttachmentButtonExit(attachment);
    }

    /// <summary>
    /// changes the stats of the weapon given the attachment the player equips
    /// </summary>
    private void ChangeWeaponStats()
    {
        //set the weapons stat bars depending on the attachment that was selcted
        GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().damage += attachment.GetComponent<AttachmentData>().damageChange;
        GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().fireRate += attachment.GetComponent<AttachmentData>().fireRateChange;
        GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().range += attachment.GetComponent<AttachmentData>().rangeChange;
        GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().accuracy += attachment.GetComponent<AttachmentData>().accuracyChange;
        GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().recoilControl += attachment.GetComponent<AttachmentData>().recoilControlChange;
        GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().mobility += attachment.GetComponent<AttachmentData>().mobilityChange;
        GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().handling += attachment.GetComponent<AttachmentData>().handlingChange;
    }
}
