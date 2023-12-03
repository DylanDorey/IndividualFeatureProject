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
