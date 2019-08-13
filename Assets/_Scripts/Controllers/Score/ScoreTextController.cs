using _Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _Scripts.Controllers.Score {
    public class ScoreTextController : MonoBehaviour {
        private TextMeshProUGUI m_textScore;

        private void Awake() {
            m_textScore = GetComponent<TextMeshProUGUI>();
            m_textScore.text = GameManager.GetScore().ToString();
        }

        private void Update() {
            m_textScore.text = GameManager.GetScore().ToString();
        }
    }
}
