using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/14/2023]
 * [Manages all player UI and gunsmith elements]
 */

//the state that the screen is in
public enum ScreenState
{
    disabled,
    playing,
    selectWeapon,
    gunsmith,
    attachmentSelection
}

public class UIManager : MonoBehaviour
{
    //singelton for GunsmithManager
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    //referenc to ScreenState
    public ScreenState screenState;

    //various UI screens for the player
    public GameObject gameScreen;
    public GameObject weaponSelectScreen;
    public GameObject gunsmithScreen;
    public GameObject attachmentSelectionScreen;

    //weapon select screen UI elements
    public GameObject newWeaponButtonPrefab;
    public GameObject weaponButtonSpawnLoc;
    private Vector3 _weaponButtonSpawnLoc;
    public GameObject wsWeaponInfoPanel;
    public TextMeshProUGUI wsWeaponTypeNameText;
    public TextMeshProUGUI wsWeaponNameText;
    public TextMeshProUGUI wsWeaponDescriptionText;
    public GameObject wsDamageBar;
    public GameObject wsFireRateBar;
    public GameObject wsRangeBar;
    public GameObject wsAccuracyBar;
    public GameObject wsRecoilControlBar;
    public GameObject wsMobilityBar;
    public GameObject wsHandlingBar;
    public TextMeshProUGUI wsAmmoText;
    public TextMeshProUGUI wsAmmoReserveText;

    //gunsmith screen UI text elements
    public TextMeshProUGUI gsWeaponTypeNameText;
    public TextMeshProUGUI gsWeaponNameText;
    public TextMeshProUGUI gsAmmoText;
    public TextMeshProUGUI gsAmmoReserveText;
    public TextMeshProUGUI gsModificationsText;
    public GameObject gsDamageBar;
    public GameObject gsFireRateBar;
    public GameObject gsRangeBar;
    public GameObject gsAccuracyBar;
    public GameObject gsRecoilControlBar;
    public GameObject gsMobilityBar;
    public GameObject gsHandlingBar;

    //gunsmith screen UI button elements
    public GameObject opticButton;
    public GameObject laserButton;
    public GameObject barrelButton;
    public GameObject muzzleButton;
    public GameObject gripButton;
    public GameObject magazineButton;
    public GameObject rearGripButton;
    public GameObject stockButton;

    //attachment selection screen UI text elements
    public GameObject newAttachmentButtonPrefab;
    public GameObject attachmentButtonSpawnLoc;
    public Vector3 _attachmentButtonSpawnLoc;
    public TextMeshProUGUI attachmentTypeText;
    public TextMeshProUGUI attachmentNameText;
    public TextMeshProUGUI attachmentDescriptionText;
    public TextMeshProUGUI prosText;
    public TextMeshProUGUI consText;
    public GameObject attachmentInfoPanel;

    //attachment selection screen UI button elements
    public GameObject attachmentButtonPrefab;

    //bool to determine if the attachment slot already has an attachment in it
    private bool alreadyHasAttachment = false;

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

        //initialize the original weaponButtonSpawn location
        _weaponButtonSpawnLoc = weaponButtonSpawnLoc.transform.position;
    }

    private void Start()
    {
        screenState = ScreenState.playing;
    }

    private void Update()
    {
        CheckScreenState();
    }

    /// <summary>
    /// changes the players UI screen
    /// </summary>
    private void CheckScreenState()
    {
        switch (screenState)
        {
            case ScreenState.disabled:
                gameScreen.SetActive(false);
                weaponSelectScreen.SetActive(false);
                gunsmithScreen.SetActive(false);
                attachmentSelectionScreen.SetActive(false);
                break;

            case ScreenState.playing:
                gameScreen.SetActive(true);
                weaponSelectScreen.SetActive(false);
                gunsmithScreen.SetActive(false);
                attachmentSelectionScreen.SetActive(false);
                break;

            case ScreenState.selectWeapon:
                gameScreen.SetActive(false);
                weaponSelectScreen.SetActive(true);
                gunsmithScreen.SetActive(false);
                attachmentSelectionScreen.SetActive(false);
                break;

            case ScreenState.gunsmith:
                gameScreen.SetActive(false);
                weaponSelectScreen.SetActive(false);
                gunsmithScreen.SetActive(true);
                attachmentSelectionScreen.SetActive(false);
                break;

            case ScreenState.attachmentSelection:
                attachmentSelectionScreen.SetActive(true);
                gameScreen.SetActive(false);
                weaponSelectScreen.SetActive(false);
                gunsmithScreen.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// opens the weapon selection menu
    /// </summary>
    public void OpenWeaponSelection()
    {
        //set the screen state to the weapon selection screen and create all weapon buttons
        screenState = ScreenState.selectWeapon;
        PopulateWeaponSelectButtons();
    }

    /// <summary>
    /// Opens the gunsmith with the appropriate weapon for the player
    /// </summary>
    public void OpenGunsmith(GameObject weaponSelected)
    {
        //switch player screen to the gunsmith screen
        screenState = ScreenState.gunsmith;

        //get weapon selected

        //open gunsmith with correct weapon
        //spawn the selected weapon at 0,0,0
        Instantiate(weaponSelected, Vector3.zero, weaponSelected.transform.rotation);

        //change the name to weapons name to remove (Clone)
        weaponSelected.name = weaponSelected.GetComponent<Weapon>().weaponName;

        //change all text and values of gunsmith UI elements
        gsWeaponTypeNameText.text = weaponSelected.GetComponent<Weapon>().weaponType;
        gsWeaponNameText.text = weaponSelected.GetComponent<Weapon>().weaponName;
        gsAmmoText.text = weaponSelected.GetComponent<Weapon>().magSize.ToString();
        gsAmmoReserveText.text = weaponSelected.GetComponent<Weapon>().reserveAmmoSize.ToString();
    }

    /// <summary>
    /// Closes the gunsmith UI menu for the player
    /// </summary>
    public void CloseGunsmith()
    {

    }

    ///// <summary>
    ///// Opens the gunsmith attachment UI menu for the player
    ///// </summary>
    //public void OpenAttachmentList(string attachmentType)
    //{
    //    //set the screen state to the weapon selection screen and create all weapon buttons
    //    screenState = ScreenState.attachmentSelection;

    //    GunsmithManager.Instance.PopulateAttachmentList(attachmentType);
    //}

    /// <summary>
    /// Closes the gunsmith attachment UI menu for the player
    /// </summary>
    public void CloseAttachmentList()
    {
        //set screen back to gunsmith screen
        screenState = ScreenState.gunsmith;
    }

    ///// <summary>
    ///// populates the screen with attachments for the player to select from for their weapon
    ///// </summary>
    ///// <param name="weapon"> the weapon that the player is equiping attachments to </param>
    //public void PopulateAttachmentList(GameObject weapon)
    //{
    //    //spawn as many buttons as there are attachments for the attachment type
    //    //for (int x = 0; x < ; x++)
    //    {
    //        //spawn a new button at the appropriate spawn location and reference to the buttons attached script
    //        GameObject newButton = Instantiate(newAttachmentButtonPrefab, attachmentButtonSpawnLoc.transform.position, attachmentButtonSpawnLoc.transform.rotation);
    //        NewAttachmentButton newButtonScript = newButton.GetComponent<NewAttachmentButton>();

    //        //Set new buttons parent as the weapon select screen
    //        newButton.transform.SetParent(attachmentSelectionScreen.transform);

    //        //set all button values
    //        //newButtonScript.attachment = 
    //        //newButtonScript.attachmentImage.sprite = 
    //        //newButtonScript.attachmentName = 

    //        //increase and move x spawn location for next button spawn
    //        attachmentButtonSpawnLoc.transform.position = new Vector3(attachmentButtonSpawnLoc.transform.position.x + 200f, attachmentButtonSpawnLoc.transform.position.y, attachmentButtonSpawnLoc.transform.position.z);
    //    }

    //    //reset the button spawn location to its original spot
    //    attachmentButtonSpawnLoc.transform.position = _attachmentButtonSpawnLoc;
    //}

    /// <summary>
    /// populates the weapon select screen with appropriate amount of weapons to choose from
    /// </summary>
    public void PopulateWeaponSelectButtons()
    {
        //spawn as many buttons as there are weapons
        for (int x = 0; x < GunsmithManager.Instance.weapons.Length; x++)
        {
            //spawn a new button at the appropriate spawn location and reference to the buttons attached script
            GameObject newButton = Instantiate(newWeaponButtonPrefab, weaponButtonSpawnLoc.transform.position, weaponButtonSpawnLoc.transform.rotation);
            NewWeaponButton newButtonScript = newButton.GetComponent<NewWeaponButton>();

            //Set new buttons parent as the weapon select screen
            newButton.transform.SetParent(weaponSelectScreen.transform);

            //set all button values
            newButtonScript.weapon = GunsmithManager.Instance.weapons[x].gameObject;
            newButtonScript.buttonWeaponTypeText.text = GunsmithManager.Instance.weapons[x].GetComponent<Weapon>().weaponType;
            //ADD MODIFICATIONS WITH SWITCH ON THE WEAPONS MODIFICATIONS INT VALUE (SET ACTIVE)
            newButtonScript.buttonWeaponImage.sprite = GunsmithManager.Instance.weapons[x].GetComponent<Weapon>().icon;
            newButtonScript.buttonWeaponNameText.text = GunsmithManager.Instance.weapons[x].GetComponent<Weapon>().weaponName;

            //increase and move x spawn location for next button spawn
            weaponButtonSpawnLoc.transform.position = new Vector3(weaponButtonSpawnLoc.transform.position.x + 300f, weaponButtonSpawnLoc.transform.position.y, weaponButtonSpawnLoc.transform.position.z);
        }

        //reset the button spawn location to its original spot
        weaponButtonSpawnLoc.transform.position = _weaponButtonSpawnLoc;
    }

    /// <summary>
    /// changes background of scene to weapon hovered on and displays all weapon info on weapon selectionscreen
    /// </summary>
    public void OnWeaponButtonEnter(GameObject weapon)
    {
        //if the player is in the select weapon menu
        if (screenState == ScreenState.selectWeapon)
        {
            //Change background
            //weaponSelectScreen.GetComponent<Image>().sprite =

            //Display all weapon info/stats
            wsWeaponInfoPanel.SetActive(true);

            wsWeaponTypeNameText.text = weapon.GetComponent<Weapon>().weaponType;
            wsWeaponNameText.text = weapon.GetComponent<Weapon>().weaponName;
            wsWeaponDescriptionText.text = weapon.GetComponent<Weapon>().weaponDescription;

            wsAmmoText.text = weapon.GetComponent<Weapon>().magSize.ToString();
            wsAmmoReserveText.text = weapon.GetComponent<Weapon>().reserveAmmoSize.ToString();
        }
    }

    /// <summary>
    /// removes all weapon info from weapon selection screen
    /// </summary>
    public void OnWeaponButtonExit(GameObject weapon)
    {
        //Change background
        //weaponSelectScreen.GetComponent<Image>().sprite =

        //Clear all weapon info/stats
        //wsWeaponTypeNameText.text = "";
        //wsWeaponNameText.text = "";
        //wsWeaponDescriptionText.text = "";

        //wsAmmoText.text = "";
        //wsAmmoReserveText.text = "";

        wsWeaponInfoPanel.SetActive(false);
    }

    /// <summary>
    /// Enlarges and changes the color of the attachment slot button
    /// </summary>
    public void OnAttachmentSlotEnter(GameObject attachmentSlot)
    {

    }

    /// <summary>
    /// Set the attachment slot size back to normal and changes the color of the attachment slot button back to normal
    /// </summary>
    public void OnAttachmentSlotExit(GameObject attachmentSlot)
    {

    }

    /// <summary>
    /// display the attachment type, name, description, pros, and cons when the attachment button is hovered over
    /// </summary>
    public void OnAttachmentButtonEnter(GameObject attachment)
    {
        //enable the attachment info panel when hovering over an attachment selection
        attachmentInfoPanel.SetActive(true);

        //display the attachment type, name, description, pros, and cons
        attachmentTypeText.text = attachment.GetComponent<AttachmentData>().attachmentType;
        attachmentNameText.text = attachment.GetComponent<AttachmentData>().attachmentName;
        attachmentDescriptionText.text = attachment.GetComponent<AttachmentData>().description;
        prosText.text = attachment.GetComponent<AttachmentData>().pros;
        consText.text = attachment.GetComponent<AttachmentData>().cons;

        //adjust stat bars given attachment attributes

    }

    /// <summary>
    /// hide the attachment type, name, description, pros, and cons when the attachment button is hovered over
    /// </summary>
    public void OnAttachmentButtonExit(GameObject attachment)
    {
        //disable the attachment info panel when not hovering over an attachment selection
        attachmentInfoPanel.SetActive(false);
    }

    /// <summary>
    /// Applies the correct icon and name for the attachment in the attachment slot
    /// </summary>
    /// <param name="attachment"> the attachment the player equips </param>
    public void UpdateAttachmentUI(GameObject attachment)
    {

    }

    /// <summary>
    /// returns the player back to the game screen/game
    /// </summary>
    public void BackToGame()
    {
        //set the screen state back to playing
        screenState = ScreenState.playing;
    }

    /// <summary>
    /// returns the player back to the weapon selection screen
    /// </summary>
    public void BackToWeaponSelection()
    {
        //set the screen state back to weapon selection
        screenState = ScreenState.selectWeapon;
    }

    /// <summary>
    /// returns the player back to the gunsmith screen
    /// </summary>
    public void BackToGunsmith()
    {
        //set the screen state back to gunsmith
        screenState = ScreenState.gunsmith;

        //Move camera back to default gunsmith camera position
        CameraManager.Instance.MoveCamBack();
    }
}
