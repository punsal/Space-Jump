using UnityEngine;

namespace _Scripts.State_Machine.States {
    public class GameOverState : IState {
        public void OnEnter() {
            Debug.Log(GetType().Name + ".OnEnter");
        }

        public void OnExecute() {
            Debug.Log(GetType().Name + ".OnExecute");
        }

        public void OnExit() {
            Debug.Log(GetType().Name + ".OnExit");
        }
    }
}