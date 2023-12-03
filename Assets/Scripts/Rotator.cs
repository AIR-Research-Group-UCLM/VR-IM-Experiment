using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private bool isRotating = true;

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}
