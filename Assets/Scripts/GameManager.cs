using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [System.Serializable]
    public class Entity
    {
        public string playerName;
        public Stone[] myStones;
        public bool hastTurn;
        public enum playerTypes 
        {
            HUMAN,CPU,NOPLAYER

        }
        public playerTypes playerType;
        public bool hasWon;
    }
    public List<Entity> playerList = new List<Entity>();
    public enum States
    {
        WAITING,ROLL_DICE,SWITCH_PLAYER
    }
    public States state;
    public int activePlayer;
    bool switchingPlayer;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (playerList[activePlayer].playerType == Entity.playerTypes.CPU)
        {
            switch (state)
            {
                case States.ROLL_DICE:
                    {
                        StartCoroutine(RollDiceDisplay());
                        state = States.WAITING;
                    }
                    break;
                case States.WAITING:
                    {

                    }
                    break;
                case States.SWITCH_PLAYER:
                    {

                    }
                    break;
            }

        }
        
    }
    void RollDice()
    {
        int diceNumber = Random.Range(1, 7);
        if (diceNumber == 6)
        {
            Debug.Log(diceNumber);
            //CHECK START NODE
        }
        if (diceNumber < 6)
        {
            Debug.Log(diceNumber);
            //check kick
        }
    }
    IEnumerator RollDiceDisplay()
    {
        yield return new WaitForSeconds(2f);
        RollDice();

    }
    void checkStartNode()
    {
        bool startNodeFull =false;
        for (int i= 0;i< playerList[activePlayer].myStones.Length; i++)
        {
            if (playerList[activePlayer].myStones[i].currentNode == playerList[activePlayer].myStones[i].startNode)
            {
                startNodeFull = true;
                break;
            }
        }
        if (startNodeFull)
        {
           
        }
        else
        {
            for (int i = 0; i < playerList[activePlayer].myStones.Length; i++)
            {
                if (!playerList[activePlayer].myStones[i].ReturnIsOut())
                {
                    state = States.WAITING;
                    return;

                }
                   
            }
           
        }
    }
}
