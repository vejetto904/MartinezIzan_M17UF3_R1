using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
using GameInputs;

public class FirstPerson : MonoBehaviour
{
    public CinemachineVirtualCamera thirdPersonCamera;
    public CinemachineVirtualCamera firstPersonCamera;

    private bool isFirstPerson = false;

    void Start()
    {
        // Asegúrate de desactivar la cámara de primera persona al inicio
        firstPersonCamera.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        InputController.CamChange += ToggleCamera;
    }

    void OnDisable()
    {
        InputController.CamChange -= ToggleCamera;
    }

    void ToggleCamera()
    {
        isFirstPerson = !isFirstPerson;
        Debug.Log("" + isFirstPerson);
        if (isFirstPerson)
        {
            EnableFirstPerson();
        }
        else
        {
            EnableThirdPerson();
        }
    }

    void EnableFirstPerson()
    {
        // Activar la cámara de primera persona y desactivar la de tercera persona
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
    }

    void EnableThirdPerson()
    {
        // Activar la cámara de tercera persona y desactivar la de primera persona
        thirdPersonCamera.gameObject.SetActive(true);
        firstPersonCamera.gameObject.SetActive(false);
    }
}
