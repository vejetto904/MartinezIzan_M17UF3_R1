using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInputs;
using System;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    protected Inputs _inputs;
    public static Action Caminar = delegate { };
    public static Action Correr = delegate { };

    private void Awake()
    {
        _inputs = new Inputs();

        _inputs.Controles.Movimiento.performed += ctx =>
        {
            Caminar.Invoke();
        };
        _inputs.Controles.Run.performed += ctx =>
        {
            Correr.Invoke();
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
