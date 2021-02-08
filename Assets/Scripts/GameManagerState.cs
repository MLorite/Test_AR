using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private abstract class State
    {
        public State(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public abstract void Begin();
        public abstract bool Update();
        public abstract void End();

        protected GameManager _gameManager;
    }
    //El estado de empezar
    private class StartState : State
    {
        public StartState(GameManager gameManager) : base(gameManager)
        {
        }

        public override void Begin()
        {
            _gameManager._startText.text = "Bienvenido";
            _gameManager._descriptionText.text = "Por favor, fija la camara y reparte una carta de cada tipo a cada jugador. Cuando esten listos pulsar el boton siguiente";
            _gameManager._buttonText.text = "Siguiente";
        }

        public override void End()
        {
            _gameManager._nextState = new PutCardsState(_gameManager);
        }

        public override bool Update()
        {
            if (_gameManager._onButtonClick)
            {
                return true;
            }
            return false;
        }
    }
    //El estado de poner las cartas
    private class PutCardsState : State
    {
        public PutCardsState(GameManager gameManager) : base(gameManager)
        {
        }

        public override void Begin()
        {
            _gameManager._startText.text = "Poner las cartas";
            _gameManager._descriptionText.text = "Todos los jugadores ponen la carta elegida bocaabajo, en elc campo de vision de la camara. luego darle la vuelta y pulsar el boton Evaluar";
            _gameManager._buttonText.text = "Evaluar";
        }

        public override void End()
        {
            _gameManager._nextState = new EvaluateState(_gameManager);
        }

        public override bool Update()
        {
            if (_gameManager._onButtonClick)
            {
                return true;
            }
            return false;
        }
    }

    private class EvaluateState : State
    {
        public EvaluateState(GameManager gameManager) : base(gameManager)
        {
        }

        public override void Begin()
        {
            _gameManager.EvaluateGame();
            _gameManager._startText.text = "Resultado";
            _gameManager._descriptionText.text = _gameManager.GetResultText();
            _gameManager._buttonText.text = "Jugar Otra";
        }

        public override void End()
        {
            _gameManager._nextState = new PutCardsState(_gameManager);
            _gameManager._currentResult = Result.Draw;
        }

        public override bool Update()
        {
            if (_gameManager._onButtonClick)
            {
                return true;
            }
            return false;
        }
    }
}
