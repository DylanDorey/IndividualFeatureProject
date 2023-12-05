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

        //initialize the original weaponButtonSpawn and attachmentButtonSpawn location
        _weaponButtonSpawnLoc = weaponButtonSpawnLoc.transform.position;
        _attachmentButtonSpawnLoc = attachmentButtonSpawnLoc.transform.position;
    }

    private void Start()
    {
        //start by setting the screen state to playing
        screenState = ScreenState.playing;

        //set the base weapon stats on the weapon select screen
        SetBaseWeaponStats();
        
    }

    private void Update()
    {
        //constantly check for when the screen state has changed
        CheckScreenState();

        //if the gunsmith screen is open
        if(screenState == ScreenState.gunsmith)
        {
            //set the ammo amounts and all stat bars according to weapon's current stat values
            UpdateWeaponAmmo();
            UpdateGSStatBars();
        }
    }

    /// <summary>
    /// changes the players UI screen
    /// </summary>
    private void CheckScreenState()
    {
        //switch the screen UI to the appropriate screen depending on where the player navigates
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

        //open gunsmith with correct weapon
        //spawn the selected weapon at 0,-2,0
        Instantiate(weaponSelected, new Vector3(0, -2, 0), weaponSelected.transform.rotation);

        //change the name to weapons name to remove (Clone)
        weaponSelected.name = weaponSelected.GetComponent<Weapon>().weaponName;

        //change all text and values of gunsmith UI elements
        gsWeaponTypeNameText.text = weaponSelected.GetComponent<Weapon>().weaponType;
        gsWeaponNameText.text = weaponSelected.GetComponent<Weapon>().weaponName;
    }

    /// <summary>
    /// Closes the gunsmith attachment UI menu for the player
    /// </summary>
    public void CloseAttachmentList()
    {
        //set screen back to gunsmith screen
        screenState = ScreenState.gunsmith;
    }

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
            //display weapon
            weapon.SetActive(true);

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
        //dont display weapon
        weapon.SetActive(false);

        //disable stats
        wsWeaponInfoPanel.SetActive(false);
    }

    /// <summary>
    /// Enlarges and changes the color of the attachment slot button
    /// </summary>
    public void OnAttachmentSlotEnter(GameObject attachmentSlot)
    {
        //enlarge attachment slot
        attachmentSlot.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    /// <summary>
    /// Set the attachment slot size back to normal and changes the color of the attachment slot button back to normal
    /// </summary>
    public void OnAttachmentSlotExit(GameObject attachmentSlot)
    {
        //reset attachment slot size to default
        attachmentSlot.transform.localScale = new Vector3(1f, 1f, 1f);
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
    /// changes the weapons mag size and ammo reserve size depending on what mag is equipped
    /// </summary>
    private void UpdateWeaponAmmo()
    {
        //set the ammo text and ammo reserve text to the weapons current ammo attributes
        gsAmmoText.text = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().magSize.ToString();
        gsAmmoReserveText.text = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().reserveAmmoSize.ToString();
    }

    /// <summary>
    /// sets the weapons stat values to default with no attachments
    /// </summary>
    public void SetBaseWeaponStats()
    {
        //set stat bar values to weapons base values
        wsDamageBar.transform.localScale = new Vector3(0.5f, 1f, 1f);
        wsFireRateBar.transform.localScale = new Vector3(0.7f, 1f, 1f);
        wsRangeBar.transform.localScale = new Vector3(0.4f, 1f, 1f);
        wsAccuracyBar.transform.localScale = new Vector3(0.65f, 1f, 1f);
        wsRecoilControlBar.transform.localScale = new Vector3(0.4f, 1f, 1f);
        wsMobilityBar.transform.localScale = new Vector3(0.5f, 1f, 1f);
        wsHandlingBar.transform.localScale = new Vector3(0.55f, 1f, 1f);
    }

    /// <summary>
    /// Updates the gunsmith stat bars depending on the attachments equipped
    /// </summary>
    public void UpdateGSStatBars()
    {
        //set the current weapons stat values based upon the attachments they have equipped
        gsDamageBar.transform.localScale = new Vector3(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().damage, 1f, 1f);
        gsFireRateBar.transform.localScale = new Vector3(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().fireRate, 1f, 1f);
        gsRangeBar.transform.localScale = new Vector3(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().range, 1f, 1f);
        gsAccuracyBar.transform.localScale = new Vector3(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().accuracy, 1f, 1f);
        gsRecoilControlBar.transform.localScale = new Vector3(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().recoilControl, 1f, 1f);
        gsMobilityBar.transform.localScale = new Vector3(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().mobility, 1f, 1f);
        gsHandlingBar.transform.localScale = new Vector3(GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().handling, 1f, 1f);
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

        //reset the attachment buttons
        GunsmithManager.Instance.ResetAttachmentButtons();

        //Move camera back to default gunsmith camera position
        CameraManager.Instance.MoveCamBack();
    }
}
