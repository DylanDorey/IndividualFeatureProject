using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //the current weapon inside the gunsmith normal rotation
    public Quaternion originalWeaponRotation;

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

    //when the player is previewing their weapon
    private bool isPreviewingWeapon;
    private float rotateSpeed = 9.0f;

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
        //if the screen state is disabled and isPreviewingWeapon is true
        if (UIManager.Instance.screenState == ScreenState.disabled && isPreviewingWeapon)
        {
            //allow mouse movement
            
        }
    }

    /// <summary>
    /// Opens the gunsmith attachment UI menu for the player
    /// </summary>
    public void OpenAttachmentList(string attachmentType)
    {
        //set the screen state to the weapon selection screen and create all weapon buttons
        UIManager.Instance.screenState = ScreenState.attachmentSelection;

        PopulateAttachmentList();
    }


    /// <summary>
    /// populates the screen with attachments for the player to select from for their weapon
    /// </summary>
    /// <param name="weapon"> the weapon that the player is equiping attachments to </param>
    public void PopulateAttachmentList(GameObject[] currentAttachmentType)
    {
        //spawn as many buttons as there are attachments for the attachment type
        for (int x = 0; x < currentAttachmentType.Length; x++)
        {
            //spawn a new button at the appropriate spawn location and reference to the buttons attached script
            GameObject newButton = Instantiate(UIManager.Instance.newAttachmentButtonPrefab, UIManager.Instance.attachmentButtonSpawnLoc.transform.position, UIManager.Instance.attachmentButtonSpawnLoc.transform.rotation);
            NewAttachmentButton newButtonScript = newButton.GetComponent<NewAttachmentButton>();

            //Set new buttons parent as the weapon select screen
            newButton.transform.SetParent(UIManager.Instance.attachmentSelectionScreen.transform);

            newButtonScript.attachment = currentGSWeapon.GetComponent<Weapon>().currentAttachmentType[x];
            newButtonScript.attachmentImage = currentGSWeapon.GetComponent<Weapon>().currentAttachmentType[x].GetComponent<AttachmentData>().icon;
            newButtonScript.attachmentName.text = currentGSWeapon.GetComponent<Weapon>().currentAttachmentType[x].GetComponent<AttachmentData>().name;

            //increase and move x spawn location for next button spawn
            UIManager.Instance.attachmentButtonSpawnLoc.transform.position = new Vector3(UIManager.Instance.attachmentButtonSpawnLoc.transform.position.x + 200f, UIManager.Instance.attachmentButtonSpawnLoc.transform.position.y, UIManager.Instance.attachmentButtonSpawnLoc.transform.position.z);
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
        //change attachment slot color

        //change attachment slot image

        //change attachment slot item name

        //
    }

    /// <summary>
    /// removes an attachment from the attachment list onto the players weapon
    /// </summary>
    /// <param name="attachment"> the attachment the player selects to remove from their weapon </param>
    public void RemoveAttachment(GameObject attachment)
    {
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
    /// Allosw the player to spin the weapon around and disables UI
    /// </summary>
    public void EnterPreviewWeapon()
    {
        //set the original rotation value
        originalWeaponRotation = currentGSWeapon.transform.rotation;

        //disable the UI and set isPreviewingWeapon to true
        UIManager.Instance.screenState = ScreenState.disabled;
        isPreviewingWeapon = true;

        //enable the mouse follow transform
    }

    /// <summary>
    /// Allosw the player to spin the weapon around and disables UI
    /// </summary>
    public void ExitPreviewWeapon()
    {
        //enable the UI
        UIManager.Instance.screenState = ScreenState.gunsmith;

        isPreviewingWeapon = false;

        //reset weapons rotation back to default
        currentGSWeapon.transform.rotation = originalWeaponRotation;
    }

    /// <summary>
    /// equips the weapon from the gunsmith and puts it in the players hands
    /// </summary>
    /// <param name="weapon"> the weapon that the player selected with all of their attachments </param>
    public void EquipCompletedWeapon(GameObject weapon)
    {
        //SAVE THE ATTACHMENTS IN THE WEAPON ATTACHMENTS ARRAY
    }
}
