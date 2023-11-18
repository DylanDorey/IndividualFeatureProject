using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [11/16/2023]
 * [Moves the camera in the gunsmith to the appropriate spot given the particular weapon]
 */

public class CameraManager : MonoBehaviour
{
    //singelton for GunsmithManager
    private static CameraManager _instance;
    public static CameraManager Instance { get { return _instance; } }

    //reference to gunsmith camera
    public Camera gunsmithCam;

    //easing amount for camera movement
    public float cameraEasingMultiplier = 0.5f;

    //base camera position to return to
    public Vector3 defaultCamPos = new Vector3(0f, 0f, -0.65f);

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
    /// Interpolates the gunsmith camera to the appropriate attachment camera position
    /// </summary>
    public void MoveCamToPos(string attachmentType)
    {
        //switch on the attachment slot type
        switch (attachmentType)
        {
            case "optic":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().opticCamPos.position, cameraEasingMultiplier);
                gunsmithCam.transform.Rotate(0f, -45f, 0f);
                break;
            case "laser":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().laserCamPos.position, cameraEasingMultiplier);
                break;
            case "barrel":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().barrelCamPos.position, cameraEasingMultiplier);
                break;
            case "muzzle":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().muzzleCamPos.position, cameraEasingMultiplier);
                break;
            case "grip":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().gripCamPos.position, cameraEasingMultiplier);
                break;
            case "magazine":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().magazineCamPos.position, cameraEasingMultiplier);
                break;
            case "rearGrip":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().rearGripCamPos.position, cameraEasingMultiplier);
                break;
            case "stock":
                gunsmithCam.transform.position = Vector3.Lerp(gunsmithCam.transform.position, GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().stockCamPos.position, cameraEasingMultiplier);
                break;
            default:
                gunsmithCam.transform.position = defaultCamPos;
                break;
        }
    }

    /// <summary>
    /// Interpolates the gunsmith camera back to the default camera position in the gunsmith
    /// </summary>
    public void MoveCamBack()
    {
        //move the gunsmith camera back to the default camera position
        gunsmithCam.transform.position = defaultCamPos;
        gunsmithCam.transform.Rotate(0f, 45f, 0f);
    }
}
