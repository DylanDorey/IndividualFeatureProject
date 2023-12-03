using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/16/2023]
 * [This will make the attachment slots bigger and smaller on mouse enter/exit]
 */

public class NewAttachmentSlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //attachment the player selects to put in this slot
    public GameObject attachmentInSlot;

    //the attachment type to load appropriate attachment list when clicked on
    public string attachmentType;

    //the slots button that the player presses
    public GameObject slotImageRef;

    //the empty slot sprite
    public Sprite emptySlotImage;

    private void Update()
    {
        //if the player has not equipped an attachment
        if (slotImageRef.GetComponent<Image>().sprite == null)
        {
            //make the image inside of the button the empty slot sprite
            slotImageRef.GetComponent<Image>().sprite = emptySlotImage;
        }

        AttachmentSlotUpdate();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Move the camera to the appropriate location
        CameraManager.Instance.MoveCamToPos(attachmentType);

        GunsmithManager.Instance.currentEditingAttachment = attachmentType;

        //Open the attachment list
        GunsmithManager.Instance.PopulateAttachmentList();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //enlare slot size
        UIManager.Instance.OnAttachmentSlotEnter(this.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //reset slot size
        UIManager.Instance.OnAttachmentSlotExit(this.gameObject);
    }

    /// <summary>
    /// updates all of the attachment slot names and images depending on what attachments are equipped
    /// </summary>
    public void AttachmentSlotUpdate()
    {
        //variable for the weapons attachments array
        GameObject[] attachmentList = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().weaponAttachments;

        //loop through the attachments array and update all the images and names of the attachment slots
        for (int index = 0; index < attachmentList.Length; index++)
        {
            //if there is an attachment in the slot
            if (attachmentList[index] != null)
            {
                switch (index)
                {
                    //0 FOR OPTIC, 1 FOR LASER, 2 FOR BARREL, etc
                    //set the attachment slots image and name
                    case 0:
                        GunsmithManager.Instance.opticSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.opticSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                    case 1:
                        GunsmithManager.Instance.laserSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.laserSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                    case 2:
                        GunsmithManager.Instance.barrelSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.barrelSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                    case 3:
                        GunsmithManager.Instance.muzzleSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.muzzleSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                    case 4:
                        GunsmithManager.Instance.gripSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.gripSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                    case 5:
                        GunsmithManager.Instance.magazineSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.magazineSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                    case 6:
                        GunsmithManager.Instance.rearGripSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.rearGripSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                    case 7:
                        GunsmithManager.Instance.stockSlot.transform.GetChild(1).GetComponent<Image>().sprite = attachmentInSlot.GetComponent<AttachmentData>().icon;
                        GunsmithManager.Instance.stockSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = attachmentInSlot.GetComponent<AttachmentData>().attachmentName;
                        break;
                }
            }
            else
            {
                //set to default values
                transform.GetChild(1).GetComponent<Image>().sprite = emptySlotImage;
                transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "EMPTY";
            }
        }
    }
}
