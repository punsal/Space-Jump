using System;
using UnityEngine;

namespace _Scripts.State_Machine.States {
    public class SuccessState : IState {
        public delegate void EnterSuccessState();

        public delegate void ExitSuccessState();

        public static event EnterSuccessState OnEnterSuccessStateEvent;
        public static event ExitSuccessState OnExitSuccessStateEvent;

        public void OnEnter() {
            Debug.Log(GetType().Name + ".OnEnter");
            try {
                if (OnEnterSuccessStateEvent != null)
                    OnEnterSuccessStateEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnEnterSuccessStateEvent));
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
            try {
                if (OnExitSuccessStateEvent != null)
                    OnExitSuccessStateEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnExitSuccessStateEvent));
            }
            catch (Exception e) {
                EventExtension.PrintError(e);
            }
        }
    }
}