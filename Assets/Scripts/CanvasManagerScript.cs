
using UnityEngine;
using UnityEngine.UI;

public class CanvasManagerScript : MonoBehaviour
{
    public GameObject BlueScoreLine;
    public GameManagerScript gm;

    // Update is called once per frame
    void Update()
    {
        BlueScoreLine.GetComponent<Text>().text = gm.snackpoints.ToString();
    }
}
