
using UnityEngine;

public class Exit_VFX_Route : MonoBehaviour
{
    
    [SerializeField]
    private Transform[] controlpoints;

    private Vector3 gizmosPosition;

    private void OnDrawGizmos()
    {
        for(float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlpoints[0].position +
                   3 * Mathf.Pow(1 - t, 2) * t * controlpoints[1].position +
                   3 * (1 - t) * Mathf.Pow(t, 2) * controlpoints[2].position +
                   Mathf.Pow(t, 3) * controlpoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);

        }

        Gizmos.DrawLine(new Vector3(controlpoints[0].position.x, controlpoints[0].position.y, controlpoints[0].position.z),
            new Vector3(controlpoints[1].position.x, controlpoints[1].position.y, controlpoints[1].position.z));

        Gizmos.DrawLine(new Vector3(controlpoints[2].position.x, controlpoints[2].position.y, controlpoints[2].position.z),
            new Vector3(controlpoints[3].position.x, controlpoints[3].position.y, controlpoints[3].position.z));
    }
    
}
