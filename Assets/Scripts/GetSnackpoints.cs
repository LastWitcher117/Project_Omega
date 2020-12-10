
using UnityEngine;

public class GetSnackpoints : MonoBehaviour
{
    public GameManagerScript gms;   

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snackpoint")
        {
            gms.snackpoints = gms.snackpoints +10;
            FindObjectOfType<AudioManager>().Play("SnackSound");
            Destroy(other.gameObject);
        }
    }
}
