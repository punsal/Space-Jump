using System;
using _Scripts.State_Machine.Machines;
using _Scripts.State_Machine.States;
using Doozy.Engine;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace _Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private StateMachine stateMachine;

        #region GameEventMessage Names

        [Header("List of GameEvent")] public string playMessage = "START_GAME";
        public string gameOverMessage = "GAME_OVER";

        #endregion

        #region Score

        private static int score = -1;

        public static void AddScore()
        {
            ++score;
        }

        public static int GetScore()
        {
            return score;
        }

        #endregion

        private void OnEnable()
        {
            Message.AddListener<GameEventMessage>(ListenUIEvents);
        }

        private void OnDisable()
        {
            Message.RemoveListener<GameEventMessage>(ListenUIEvents);
        }

        private void Start()
        {
            stateMachine = new StateMachine(new IdleState());
        }

        private void Update()
        {
            stateMachine.Run();
        }

        #region Doozy Events

        private void ListenUIEvents(GameEventMessage message)
        {
            if (message.EventName == playMessage)
                PlayGame();
            else if (message.EventName == gameOverMessage)
                GameOver();
            else
                throw new Exception("Incoming message : \"" + message.EventName +
                                    "\" has no mean for GameManager.");
        }

        private static void PlayGame()
        {
            StateMachine.TriggerNextState(new SpawnState());
        }

        private static void GameOver()
        {
            StateMachine.TriggerNextState(new GameOverState());
        }

        #endregion
    }
}