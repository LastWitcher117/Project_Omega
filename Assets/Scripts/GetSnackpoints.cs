
using UnityEngine;

public class GetSnackpoints : MonoBehaviour
{
    public GameManagerScript gms;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snackpoint")
        {
            gms.snackpoints++;
            Destroy(other.gameObject);
        }
    }
}
