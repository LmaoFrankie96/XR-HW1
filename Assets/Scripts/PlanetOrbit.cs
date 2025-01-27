using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public GameObject planet; // Public reference to the planet object
    public float rotationSpeed = 10f; // Speed of the rotation in degrees per second

    private void Update()
    {
        if (planet != null)
        {
            // Rotate the specified planet around its local Y-axis
            planet.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
