using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/14/2023]
 * [Manage everything weapon related in the gunsmith]
 */
public class GunsmithManager : MonoBehaviour
{
    //singelton for GunsmithManager
    private static GunsmithManager _instance;
    public static GunsmithManager Instance { get { return _instance; } }

    //the current weapon inside the gunsmith
    public GameObject currentGSWeapon;

    //the current attachment the player is editing
    public string currentEditingAttachment;

    //the amount of attachments in each attachment category
    public int amountOfAttachments;

    //the various attahments to choose from when an attachment type is picked
    public GameObject[] attachmentArray;

    //the amount of weapons available to use in the gunsmith
    private int numWeapons = 1;

    //references to weapons
    public GameObject MCW;

    //array of various weapons
    public GameObject[] weapons;

    //attachment slot references
    public GameObject opticSlot;
    public GameObject laserSlot;
    public GameObject barrelSlot;
    public GameObject muzzleSlot;
    public GameObject gripSlot;
    public GameObject magazineSlot;
    public GameObject rearGripSlot;
    public GameObject stockSlot;

    //list of attachment buttons
    public List<GameObject> attachmentListButtons = new List<GameObject>();

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

        //initialize weapons array
        weapons = new GameObject[numWeapons];
        weapons[0] = MCW;
    }

    private void Update()
    {

    }

    /// <summary>
    /// Opens the gunsmith attachment UI menu for the player
    /// </summary>
    public void OpenAttachmentList()
    {
        //set the screen state to the weapon selection screen and create all weapon buttons
        UIManager.Instance.screenState = ScreenState.attachmentSelection;
    }


    /// <summary>
    /// populates the screen with attachments for the player to select from for their weapon
    /// </summary>
    /// <param name="weapon"> the weapon that the player is equiping attachments to </param>
    public void PopulateAttachmentList()
    {
        OpenAttachmentList();

        //set the amount of attachments to populate depending on which slot the player selected
        if(currentEditingAttachment == "optic")
        {
            amountOfAttachments = 3;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().optics;
        }
        else if (currentEditingAttachment == "laser")
        {
            amountOfAttachments = 2;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().lasers;
        }
        else if (currentEditingAttachment == "barrel")
        {
            amountOfAttachments = 3;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().barrels;
        }
        else if (currentEditingAttachment == "muzzle")
        {
            amountOfAttachments = 2;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().muzzles;
        }
        else if (currentEditingAttachment == "grip")
        {
            amountOfAttachments = 2;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().grips;
        }
        else if (currentEditingAttachment == "magazine")
        {
            amountOfAttachments = 4;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().magazines;
        }
        else if (currentEditingAttachment == "rearGrip")
        {
            amountOfAttachments = 3;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().rearGrips;
        }
        else if (currentEditingAttachment == "stock")
        {
            amountOfAttachments = 3;
            attachmentArray = currentGSWeapon.GetComponent<Weapon>().stocks;
        }
        else
        {
            //default
            amountOfAttachments = 0;
            attachmentArray = null;
        }

        //spawn as many buttons as there are attachments for the attachment type
        for (int x = 0; x < amountOfAttachments; x++)
        {
            //spawn a new button at the appropriate spawn location and reference to the buttons attached script
            GameObject newButton = Instantiate(UIManager.Instance.newAttachmentButtonPrefab, UIManager.Instance.attachmentButtonSpawnLoc.transform.position, UIManager.Instance.attachmentButtonSpawnLoc.transform.rotation);
            NewAttachmentButton newButtonScript = newButton.GetComponent<NewAttachmentButton>();

            //add button to list
            attachmentListButtons.Add(newButton);

            //Set new buttons parent as the weapon select screen
            newButton.transform.SetParent(UIManager.Instance.attachmentSelectionScreen.transform);

            //WORK HERE, try to get all three things to show up on the buttons once they populate
            newButtonScript.attachment = attachmentArray[x].gameObject;
            newButtonScript.attachmentImage.GetComponent<Image>().sprite = attachmentArray[x].GetComponent<AttachmentData>().icon;
            newButtonScript.attachmentName.text = attachmentArray[x].GetComponent<AttachmentData>().attachmentName;

            //increase and move x spawn location for next button spawn
            UIManager.Instance.attachmentButtonSpawnLoc.transform.position = new Vector3(UIManager.Instance.attachmentButtonSpawnLoc.transform.position.x + 225f, UIManager.Instance.attachmentButtonSpawnLoc.transform.position.y, UIManager.Instance.attachmentButtonSpawnLoc.transform.position.z);
        }

        //reset the button spawn location to its original spot
        UIManager.Instance.attachmentButtonSpawnLoc.transform.position = UIManager.Instance._attachmentButtonSpawnLoc;
    }

    /// <summary>
    /// equips an attachment from the attachment list onto the players weapon
    /// </summary>
    /// <param name="attachment"> the attachment the player selects to equip onto their weapon </param>
    public void EquipAttachment(GameObject attachment)
    {
        //---------------------------------^ use this variable for the attachment/access the attachment items like attachment icon, name, AttachmentData script, etc (look at NewAttachmentButton script)
        //move camera back to original position
        CameraManager.Instance.MoveCamBack();

        //change screen state back to gunsmith
        UIManager.Instance.screenState = ScreenState.gunsmith;

        //set attachment in slot

        //spawn in the appropriate attachment for each given attachment type
        if (attachment.GetComponent<AttachmentData>().attachmentType == "optic")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            //GameObject.Find(currentGSWeapon.GetComponent<Weapon>().weaponAttachments[0].name).SetActive(true);
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().opticLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "laser")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().laserLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "barrel")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().barrelLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "muzzle")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().muzzleLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "grip")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().gripLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "magazine")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().magazineLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "rearGrip")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().rearGripLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }
        else if (attachment.GetComponent<AttachmentData>().attachmentType == "stock")
        {
            //spawn in the correct attachment at its corresponding attachment location, and set its active to true;
            Instantiate(attachment, currentGSWeapon.GetComponent<Weapon>().stockLocation.transform.position, Quaternion.identity);
            attachment.SetActive(true);
        }

        //change attachment slot color

        //change attachment slot image

        //change attachment slot item name

        //clear the attachment button list
        ResetAttachmentButtons();
    }

    /// <summary>
    /// removes an attachment from the attachment list onto the players weapon
    /// </summary>
    public void RemoveAttachment()
    {
        //check what attachment is currently being edited
        if (currentEditingAttachment == "optic")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[0] = null;
            opticSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            opticSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }
        else if (currentEditingAttachment == "laser")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[1] = null;
            laserSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            laserSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }
        else if (currentEditingAttachment == "barrel")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[2] = null;
            barrelSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            barrelSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }
        else if(currentEditingAttachment == "muzzle")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[3] = null;
            muzzleSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            muzzleSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }
        else if (currentEditingAttachment == "grip")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[4] = null;
            gripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            gripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }
        else if (currentEditingAttachment == "magazine")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[5] = null;
            magazineSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            magazineSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }
        else if (currentEditingAttachment == "rearGrip")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[6] = null;
            rearGripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            rearGripSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }
        else if (currentEditingAttachment == "stock")
        {
            //set the weapons attachment slot to null, remove the current attachment from the weapon, remove the attachment from the slot
            currentGSWeapon.GetComponent<Weapon>().weaponAttachments[7] = null;
            stockSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot.SetActive(false);
            stockSlot.GetComponent<NewAttachmentSlot>().attachmentInSlot = null;
        }

        //return to gunsmith screen
        UIManager.Instance.screenState = ScreenState.gunsmith;

        //if the gunsmith camera is not already at its default position
        if (CameraManager.Instance.gunsmithCam.transform.position != CameraManager.Instance.defaultCamPos)
        {
            //move it to its default position
            CameraManager.Instance.MoveCamBack();
        }
    }

    /// <summary>
    /// equips the weapon from the gunsmith and puts it in the players hands
    /// </summary>
    /// <param name="weapon"> the weapon that the player selected with all of their attachments </param>
    public void EquipCompletedWeapon(GameObject weapon)
    {
        //SAVE THE ATTACHMENTS IN THE WEAPON ATTACHMENTS ARRAY
    }

    public void ResetAttachmentButtons()
    {
        //loop through attachmentListButtons list
        foreach (GameObject button in attachmentListButtons)
        {
            //destroy the buttons that are present
            Destroy(button);
        }
        attachmentListButtons.Clear();
    }
}
