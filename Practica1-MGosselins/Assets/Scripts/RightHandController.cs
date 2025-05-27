using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandController : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _XRRayInteractor_Grab;
    [SerializeField] private XRRayInteractor _XRRayInteractor_Teleport;

    [SerializeField] private InputActionReference _JoyStick_North_Sector;

    private void Awake()
    {
        _XRRayInteractor_Teleport.enabled = false;
    }
    private void OnEnable()
    {
        _JoyStick_North_Sector.action.performed += PalancaArribaPresionada;
        _JoyStick_North_Sector.action.canceled += PalancaArribaLiberada;

    }
    private void OnDisable()
    {
        _JoyStick_North_Sector.action.performed -= PalancaArribaPresionada;
        _JoyStick_North_Sector.action.canceled -= PalancaArribaLiberada;
    }

    private void PalancaArribaPresionada(InputAction.CallbackContext context)
    {
        print("");
        _XRRayInteractor_Grab.enabled = false;
        _XRRayInteractor_Teleport.enabled = true;
    }
    private void PalancaArribaLiberada(InputAction.CallbackContext context) => Invoke("PalancaArribaLiberada_Invoke", 0.01f);

    private void PalancaArribaLiberada_Invoke()
    {
        print("");
        _XRRayInteractor_Grab.enabled = true;
        _XRRayInteractor_Teleport.enabled = false;
    }
}
