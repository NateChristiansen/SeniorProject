using UnityEngine;
using System.Collections;

public class CarSounds : MonoBehaviour
{

    public AudioSource audioSource;
    private float currentSpeed = 0;
    private float pitch = 0;

    // Use this for initialization
    void Start()
    {
        currentSpeed = transform.GetComponent<MoveCar>().Speed;
    }


    void Update()
    {
        AdjustPitch();
    }

    private void AdjustPitch()
    {
        currentSpeed = transform.GetComponent<MoveCar>().Speed;
        audioSource.pitch = currentSpeed + 1f;
    }
}
