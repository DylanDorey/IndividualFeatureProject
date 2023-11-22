using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Move the camera to the appropriate location
        CameraManager.Instance.MoveCamToPos(attachmentType);

        //Open the attachment list
        GunsmithManager.Instance.OpenAttachmentList(attachmentType);
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
}
