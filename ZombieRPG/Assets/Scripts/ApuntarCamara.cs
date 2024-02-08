using UnityEngine;
using Cinemachine;

public class CinemachineTransition : MonoBehaviour
{
    public float transitionDuration = 1.0f;
    public float targetFOV = 6.0f;

    private CinemachineVirtualCamera virtualCamera;
    private float originalFOV;


    private bool isTransitioning = false;
    private float transitionStartTime;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        originalFOV = virtualCamera.m_Lens.FieldOfView;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartTransition();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ResetTransition();
        }

        if (isTransitioning)
        {
            float progress = (Time.time - transitionStartTime) / transitionDuration;
            float currentFOV = Mathf.Lerp(originalFOV, targetFOV, progress);

            virtualCamera.m_Lens.FieldOfView = currentFOV;

            if (progress >= 1.0f)
            {
                isTransitioning = false;
            }
        }
    }

    void StartTransition()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            transitionStartTime = Time.time;
        }
    }

    void ResetTransition()
    {
        if (isTransitioning)
        {
            isTransitioning = false;
        }

        virtualCamera.m_Lens.FieldOfView = originalFOV;
    }
}