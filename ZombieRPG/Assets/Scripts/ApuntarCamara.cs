using UnityEngine;
using Cinemachine;

public class CinemachineTransition : MonoBehaviour
{
    public float transitionDuration = 1.0f;
    public float targetFOV = 6.0f;

    private CinemachineVirtualCamera virtualCamera;
    private float originalFOV;

    private bool isTransitioning = false;
    private float transitionStartTime = 0.0f;
    private bool isAiming = false;

    public void Awake()
    {
        InputController.Instance ??= FindObjectOfType<InputController>();
        InputController.Aim += OnAimChange;
    }

    private void OnDestroy()
    {
        InputController.Aim -= OnAimChange;
    }

    private void OnAimChange()
    {
        isAiming = !isAiming; // Invertir el estado de isAiming
        if (isAiming)
        {
            StartTransition();
        }
        else
        {
            ResetTransition();
        }
    }

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        originalFOV = virtualCamera.m_Lens.FieldOfView;
    }

    void Update()
    {
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
        isTransitioning = false;
        virtualCamera.m_Lens.FieldOfView = originalFOV;
    }
}
