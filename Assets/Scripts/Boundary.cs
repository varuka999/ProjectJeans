using UnityEngine;

// Create a boundary object for reference
public class Boundary : MonoBehaviour
{
    private float boundarySize = 100f; // Size of the square boundary (adjust as needed)

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(boundarySize, boundarySize, 0f)); // Draw the boundary box
    }
}
