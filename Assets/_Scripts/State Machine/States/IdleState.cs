using System;
using UnityEngine;

namespace _Scripts.State_Machine.States {
    public class IdleState : IState {
        public delegate void EnterIdle();

        public static event EnterIdle OnEnterIdleEvent;

        public void OnEnter() {
            Debug.Log(GetType().Name + ".OnEnter");
            try {
                if (OnEnterIdleEvent != null)
                    OnEnterIdleEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnEnterIdleEvent));
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