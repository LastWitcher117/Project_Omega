using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeapon : MonoBehaviour
{

    public GameObject WeaponStone1;

    public GameObject WeaponStone2;

    public GameObject WeaponCanvas;

    public GameObject GotWeapon;

    public MeshRenderer Stone1;
    public MeshRenderer Stone2;

    public GameObject ThisObject;
    public GameObject PowerStonesGround;

    public AnimationController AC;

    public bool inWeaponGetter = false;

    public GameObject PlayerGotWeapon;

    public GameManagerScript gms;

    void Start()
    {
        WeaponStone1.SetActive(false);
        WeaponStone2.SetActive(false);

        GotWeapon.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        

        GotWeapon.SetActive(true);

        Stone1.enabled = false;
        Stone2.enabled = false;

        PowerStonesGround.SetActive(false);

        WeaponCanvas.SetActive(true);

        AC.inTutorial = true;

        inWeaponGetter = true;
        PlayerGotWeapon.SetActive(true);

        gms.TutorialWeapon = false;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inWeaponGetter == true)
        {
            WeaponCanvas.SetActive(false);
            GotWeapon.SetActive(false);
            AC.inTutorial = false;

            WeaponStone1.SetActive(true);
            WeaponStone2.SetActive(true);

            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ThisObject.SetActive(false);
    }

}
