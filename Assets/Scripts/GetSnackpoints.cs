
using UnityEngine;

public class GetSnackpoints : MonoBehaviour
{
    public GameManagerScript gms;
    int numSnack = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snackpoint")
        {
            gms.snackpoints = gms.snackpoints +10;
            //FindObjectOfType<AudioManager>().Play("SnackSound");
            Destroy(other.gameObject);

            numSnack++;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("numSnacks", numSnack);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Collectables/SnakPoint Chromatic");
            if (numSnack == 10) numSnack = 1 ;
            
            
        }
    }

    
}
