
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int snackpoints = 0;
    public bool tenScore = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (snackpoints == 10 && tenScore == false)
        {

            float angle = -90f;
            transform.rotation *= Quaternion.AngleAxis(angle, Vector3.right);    //Für richitge Positionierung der VFX von YAY 10

            tenScore = true;
            Debug.Log("10 Punkte YAY");

        }
    }
}
