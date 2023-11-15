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
        UIManager.Instance.OpenGunsmith(weapon);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.OnWeaponButtonEnter(weapon);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.OnWeaponButtonExit(weapon);
    }
}
