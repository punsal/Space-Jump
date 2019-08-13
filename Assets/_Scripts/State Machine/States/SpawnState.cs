using System;
using UnityEngine;

namespace _Scripts.State_Machine.States {
    public class SpawnState : IState {
        public delegate void EnterSpawn();

        public static event EnterSpawn OnEnterSpawnEvent;

        public void OnEnter() {
            Debug.Log(GetType().Name + ".OnEnter");
            try {
                if (OnEnterSpawnEvent != null)
                    OnEnterSpawnEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnEnterSpawnEvent));
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