using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/.............................../2023]
 * [Manages all player UI and gunsmith elements]
 */

//the state that the screen is in
public enum ScreenState
{
    playing,
    changeClass,
    gunsmith,
    attachmentSelection
}

public class UIManager : MonoBehaviour
{
    //singelton for GunsmithManager
    private UIManager _instance;
    private UIManager Instance { get { return _instance; } }

    //gunsmith screen UI text elements
    public TextMeshProUGUI weaponTypeNameText;
    public TextMeshProUGUI weaponNameText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI ammoReserveText;
    public TextMeshProUGUI modificationsText;

    //gunsmith screen UI button elements
    public GameObject opticButton;
    public GameObject laserButton;
    public GameObject barrelButton;
    public GameObject muzzleButton;
    public GameObject gripButton;
    public GameObject ammunitionButton;
    public GameObject magazineButton;
    public GameObject rearGripButton;

    //attachment selection screen UI text elements
    public TextMeshProUGUI attachmentNameText;
    public TextMeshProUGUI attachmentDescriptionText;
    public TextMeshProUGUI prosText;
    public TextMeshProUGUI consText;

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
    }

    /// <summary>
    /// changes the players UI screen
    /// </summary>
    private void CheckScreenState()
    {

    }

    /// <summary>
    /// Opens the gunsmith UI menu for the player
    /// </summary>
    public void OpenGunsmith()
    {

    }

    /// <summary>
    /// Closes the gunsmith UI menu for the player
    /// </summary>
    public void CloseGunsmith()
    {

    }

    /// <summary>
    /// Opens the gunsmith attachment UI menu for the player
    /// </summary>
    public void OpenAttachmentList()
    {

    }

    /// <summary>
    /// Closes the gunsmith attachment UI menu for the player
    /// </summary>
    public void CloseAttachmentList()
    {

    }

    /// <summary>
    /// populates the screen with attachments for the player to select from for their weapon
    /// </summary>
    /// <param name="weapon"> the weapon that the player is equiping attachments to </param>
    public void PopulateAttachmentList(GameObject weapon)
    {

    }

    /// <summary>
    /// Enlarges and changes the color of the attachment slot button
    /// </summary>
    public void OnAttachmentSlotHighlight()
    {

    }

    /// <summary>
    /// Applies the correct icon and name for the attachment in the attachment slot
    /// </summary>
    /// <param name="attachment"> the attachment the player equips </param>
    public void UpdateAttachmentUI(GameObject attachment)
    {

    }
}
