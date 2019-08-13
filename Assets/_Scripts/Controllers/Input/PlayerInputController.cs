using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player input controller. Triggers OnPlayerInputEvent. Is meant to use for states only. 
/// </summary>
public class PlayerInputController : MonoBehaviour {
    private Button inputButton;

    public delegate void PlayerInput();
    /// <summary>
    /// DO NOT ADD CONTROLLER METHODS DIRECTLY TO THIS EVENT
    /// </summary>
    public static event PlayerInput OnPlayerInputEvent;

    private void Awake() {
        inputButton = GetComponent<Button>();
    }

    private void OnEnable() {
        inputButton.onClick.AddListener(TriggerPlayerInput);
    }

    private void OnDisable() {
        inputButton.onClick.RemoveAllListeners();
    }
    /// <summary>
    /// Triggers the player input. 
    /// </summary>
    public void TriggerPlayerInput() {
        try {
            if (OnPlayerInputEvent != null)
                OnPlayerInputEvent.Invoke();
            else
                EventExtension.ThrowMessage(nameof(OnPlayerInputEvent));
        }
        catch (Exception e) {
            EventExtension.PrintError(e);
        }
    }
}
