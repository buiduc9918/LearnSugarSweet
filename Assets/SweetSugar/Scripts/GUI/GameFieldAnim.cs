using SweetSugar.Scripts.Core;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    public class GameFieldAnim : MonoBehaviour
    {
        void EndAnimGamField()
        {
            LevelManager.THIS.gameStatus = GameState.Playing;
        }
    }
}
