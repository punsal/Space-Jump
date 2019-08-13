using System;
using UnityEngine;

namespace _Scripts.State_Machine.States {
    public class PlayState : IState {
        public delegate void EnterPlayState();

        public delegate void ExecutePlayState();

        public delegate void ExitPlayState();

        public static event EnterPlayState OnEnterPlayStateEvent;
        public static event ExecutePlayState OnExecutePlayStateEvent;
        public static event ExitPlayState OnExitPlayStateEvent;

        public void OnEnter() {
            Debug.Log(GetType().Name + ".OnEnter");
            try {
                if (OnEnterPlayStateEvent != null)
                    OnEnterPlayStateEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnEnterPlayStateEvent));
            }
            catch (Exception e) {
                EventExtension.PrintError(e);
            }
        }

        public void OnExecute() {
            Debug.Log(GetType().Name + ".OnExecute");
            try {
                if (OnExecutePlayStateEvent != null)
                    OnExecutePlayStateEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnExecutePlayStateEvent));
            }
            catch (Exception e) {
                EventExtension.PrintError(e);
            }
        }

        public void OnExit() {
            Debug.Log(GetType().Name + ".OnExit");
            try {
                if (OnExitPlayStateEvent != null)
                    OnExitPlayStateEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnExitPlayStateEvent));
            }
            catch (Exception e) {
                EventExtension.PrintError(e);
            }
        }
    }
}