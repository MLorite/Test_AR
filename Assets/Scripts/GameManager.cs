using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public void OnButtonClickCallback()
    {
        _onButtonClick = true;
    }
    private void Start()
    {
        _nextState = new StartState(this);
        NextState();
    }
    private void Update()
    {
        if (_currentState != null && _currentState.Update())
        {
            _currentState.End();
            NextState();
        }
        _onButtonClick = false;
    }

    private void NextState()
    {
        if (_currentState != null)
        {
            _currentState.End();
            _currentState = null; 
        }

        if (_nextState != null)
        {
            _currentState = _nextState;
            _currentState.Begin();
            _nextState = null;
        }
    }
    private void EvaluateGame()
    {
        List<VuforiaObjectsController> controllerOnTracking = new List<VuforiaObjectsController>();
        foreach (VuforiaObjectsController vuforiaObjectsController in VuforiaObjectsController.controllers)
        {
            if (vuforiaObjectsController.OnTracking)
            {
                controllerOnTracking.Add(vuforiaObjectsController);
            }
        }

        if (controllerOnTracking.Count != 2)
        {
            return;
        }

        VuforiaObjectsController redController = controllerOnTracking[0];
        VuforiaObjectsController blueController = controllerOnTracking[1];
        if(blueController.ScreenPosition.x < redController.ScreenPosition.x)
        {
            redController = controllerOnTracking[1];
            blueController = controllerOnTracking[0];
        }

        EvaluateResult(redController, blueController);
    }

    private void EvaluateResult(VuforiaObjectsController redController, VuforiaObjectsController blueController)
    {
        Type blueType = blueController.GetType();
        Type redType = redController.GetType();
        if(blueType == redType)
        {
            _currentResult = Result.Draw;
        } else
        {
            if(blueType == typeof(controladorSiquiero))
            {
                _currentResult = redType == typeof(controladorYoshi) ? Result.BlueWin : Result.RedWin;
            } else if (blueType == typeof(controladorYoshi))
            {
                _currentResult = redType == typeof(controladorDCA) ? Result.BlueWin : Result.RedWin;
            }
            else if (blueType == typeof(controladorDCA))
            {
                _currentResult = redType == typeof(controladorSiquiero) ? Result.BlueWin : Result.RedWin;
            }
        }
        if (_currentResult == Result.BlueWin)
        {
            _blueScore++;
        } else if(_currentResult == Result.RedWin)
        {
            _redScore++;
        }
        UpdateScoreView();
    }

    private enum Result
    {
        Draw,
        BlueWin,
        RedWin
    }

    private Result _currentResult;

    private State _currentState, _nextState;

    private int _blueScore, _redScore;

    private bool _onButtonClick = false;

}
