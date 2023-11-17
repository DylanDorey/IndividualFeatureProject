using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/14/2023]
 * [Button properties for the weapon selection buttons]
 */

public class NewWeaponButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject weapon;
    public TextMeshProUGUI buttonWeaponTypeText;
    public Image buttonWeaponImage;
    public TextMeshProUGUI buttonWeaponNameText;

    public void OnPointerDown(PointerEventData eventData)
    {
        //switch player to the gunsmith screen
        UIManager.Instance.OpenGunsmith(weapon);

        //initialize the current weapon in the gunsmith to this weapon
        GunsmithManager.Instance.currentGSWeapon = weapon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //display all weapon info/stats in weapon selection menu
        UIManager.Instance.OnWeaponButtonEnter(weapon);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //disable all weapon info/stats in weapon selection menu
        UIManager.Instance.OnWeaponButtonExit(weapon);
    }
}
