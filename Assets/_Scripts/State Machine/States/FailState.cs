using System;
using UnityEngine;

namespace _Scripts.State_Machine.States {
    public class FailState : IState {
        public delegate void EnterFailState();

        public static event EnterFailState OnEnterFailStateEvent;

        public void OnEnter() {
            Debug.Log(GetType().Name + ".OnEnter");
            try {
                if (OnEnterFailStateEvent != null)
                    OnEnterFailStateEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnEnterFailStateEvent));
            }
            catch (Exception e) {
                EventExtension.PrintError(e);
            }
        }

        public void OnExecute() {
            Debug.Log(GetType().Name + ".OnExecute");
        }

        public void OnExit() {
            Debug.Log(GetType().Name + ".OnExit");
        }
    }
}