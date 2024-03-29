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
    public static Action Aim = delegate { };
    public static Action CamChange = delegate { };
    public static Action Inv = delegate { };

    public Vector2 movimientoActual;

    private void Awake()
    {
        _inputs = new Inputs();

        _inputs.Controles.Movimiento.performed += ctx =>
        {
            movimientoActual = ctx.ReadValue<Vector2>();
            Caminar.Invoke(movimientoActual.magnitude > 0);
        };
        _inputs.Controles.Run.performed += ctx =>
        {
            Correr.Invoke();
        };
        _inputs.Controles.CamAim.performed += ctx =>
        {
            Aim.Invoke();
        };
        _inputs.Controles.Jump.performed += ctx =>
        {
            Jump.Invoke();
        };
        _inputs.Controles.Crouch.performed += ctx =>
        {
            Crouch.Invoke();
        };
        _inputs.Controles.CamChange.performed += ctx =>
        {
            CamChange.Invoke();
        };
        _inputs.Controles.OpInv.performed += ctx =>
        {
            Inv.Invoke();
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
}
