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

    //bool to determine if the camera has been rotated at all
    private bool isRotatedLeft = false;
    private bool isRotatedRight = false;

    //base camera position to return to
    public Vector3 defaultCamPos = new Vector3(0.2f, 0f, -0.65f);

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
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().opticCamPos.position;
                gunsmithCam.transform.Rotate(0f, -45f, 0f);
                isRotatedLeft = true;
                break;
            case "laser":
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().laserCamPos.position;
                gunsmithCam.transform.Rotate(0f, 45f, 0f);
                isRotatedRight = true;
                break;
            case "barrel":
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().barrelCamPos.position;
                break;
            case "muzzle":
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().muzzleCamPos.position;
                gunsmithCam.transform.Rotate(0f, 45f, 0f);
                isRotatedRight = true;
                break;
            case "grip":
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().gripCamPos.position;
                break;
            case "magazine":
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().magazineCamPos.position;
                gunsmithCam.transform.Rotate(0f, 45f, 0f);
                isRotatedRight = true;
                break;
            case "rearGrip":
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().rearGripCamPos.position;
                break;
            case "stock":
                //move the cams position to the correct attachment location, rotate appropriately, and set isRotated to true or false
                gunsmithCam.transform.position = GunsmithManager.Instance.currentGSWeapon.GetComponent<Weapon>().stockCamPos.position;
                gunsmithCam.transform.Rotate(0f, 45f, 0f);
                isRotatedRight = true;
                break;
            default:
                //move the cam to its default location if it has no where to go
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

        //if the camera is rotated left or right
        if(isRotatedLeft)
        {
            //rotate it back to default rotation
            gunsmithCam.transform.Rotate(0f, 45f, 0f);
            isRotatedLeft = false;
        }
        else if (isRotatedRight)
        {
            //rotate it back to default rotation
            gunsmithCam.transform.Rotate(0f, -45f, 0f);
            isRotatedRight = false;
        }
    }
}
