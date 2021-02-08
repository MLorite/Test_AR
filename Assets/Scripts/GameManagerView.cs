using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    private string GetResultText()
    {
        switch (_currentResult)
        {
            case Result.BlueWin:
                return "Ha ganado el equipo Azul";
            case Result.RedWin:
                return "Ha ganado el equipo Rojo";
            default: //case Result.Draw
                return "La partida ha quedado en empate";
        }
    }


   private void UpdateScoreView()
    {
        _redResultadoText.text = _redScore.ToString();
        _blueResultadoText.text = _blueScore.ToString();
    }
    [SerializeField]
    private Text _startText = null;
    [SerializeField]
    private Text _descriptionText = null;
    [SerializeField]
    private Text _buttonText = null;
    [SerializeField]
    private Text _redResultadoText = null;
    [SerializeField]
    private Text _blueResultadoText = null;
}
