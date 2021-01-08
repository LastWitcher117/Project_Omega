 
using UnityEngine;

public class GetSnackpoints : MonoBehaviour
{

    public GameManagerScript gms;
    int numSnack = 0;


   /* private void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Collectables/SnakPoint Chromatic");
    }*/
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snackpoint")
        {
            gms.snackpoints = gms.snackpoints +10;
            //FindObjectOfType<AudioManager>().Play("SnackSound");
            Destroy(other.gameObject);

            numSnack++;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("numSnacks", numSnack);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Collectables/SnakPoint Chromatic", gameObject);

            if (numSnack == 10)
            {
                //FMODUnity.RuntimeManager.PlayOneShot("event:/Collectables/Score");
                numSnack = 0;
            }
            
            
        }
    }

    
}
