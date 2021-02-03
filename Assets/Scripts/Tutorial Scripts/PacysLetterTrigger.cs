using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacysLetterTrigger : MonoBehaviour
{
    public GameObject Letter;
    public Letter_to_Pacsy LTP;

    private void OnTriggerEnter(Collider other)
    {
        Letter.SetActive(true);
        LTP.Switch = false;
    }
}
