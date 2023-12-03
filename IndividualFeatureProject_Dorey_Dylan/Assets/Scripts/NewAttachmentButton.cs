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

    private void Start()
    {
        //initialize button image and name
        //attachmentName.text = attachment.GetComponent<AttachmentData>().attachmentName;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //equip the attachment to the attachment slot once the player clicks on the button
        GunsmithManager.Instance.EquipAttachment(attachment);

        //set attachment slot attachmentInSlot and current weapons attachments
        //IF OPTIC IF LASER< IF BARREL, etc set 
        if (attachment.GetComponent<AttachmentData>().attachmentType == "optic")
        {
            GunsmithManager.Instance.opticSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[0] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "laser")
        {
            GunsmithManager.Instance.laserSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[1] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "barrel")
        {
            GunsmithManager.Instance.barrelSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[2] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "muzzle")
        {
            GunsmithManager.Instance.muzzleSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[3] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "grip")
        {
            GunsmithManager.Instance.gripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[4] = attachment;
        }
        else if(attachment.GetComponent<AttachmentData>().attachmentType == "magazine")
        {
            GunsmithManager.Instance.magazineSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[5] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "rearGrip")
        {
            GunsmithManager.Instance.rearGripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[6] = attachment;
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "stock")
        {
            GunsmithManager.Instance.stockSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = attachment;
            GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments[7] = attachment;
        }


        //set the check mark and equipped text to active
        //attachmentCheckMark.SetActive(true);
        //equippedText.SetActive(true);
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
}
