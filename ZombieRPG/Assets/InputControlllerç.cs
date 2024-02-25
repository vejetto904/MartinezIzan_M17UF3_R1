using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInputs;
using System;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    protected Inputs _inputs;
    public static Action<bool> Caminar = delegate { };
    public static Action Correr = delegate { };
    public static Action Jump = delegate { };
    public static Action Crouch = delegate { };

    private void Awake()
    {
        _inputs = new Inputs();

        _inputs.Controles.Movimiento.performed += ctx =>
        {
            Caminar.Invoke(ctx.ReadValue<Vector2>().magnitude > 0);
        };
        _inputs.Controles.Run.performed += ctx =>
        {
            Correr.Invoke();
        };
        _inputs.Controles.Jump.performed += ctx =>
        {
            Jump.Invoke();
        };
        _inputs.Controles.Crouch.performed += ctx =>
        {
            Crouch.Invoke();
        };

    }
    private void OnEnable()
    {
        _inputs.Controles.Enable();
    }

    private void OnDisable()
    {
        _inputs.Controles.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
