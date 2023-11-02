using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviourPunCallbacks
{
    public TMP_Text scoreOneText; // Player One Score text
    public TMP_Text scoreTwoText; // Player Two Score text

    private int scoreOne = 0; // Player One Score counter
    private int scoreTwo = 0; // Player Two Score counter

    // Call this method to increase the score for Player One.
    public void IncreaseScoreOne()
    {
        photonView.RPC("RPC_IncreaseScoreOne", RpcTarget.AllViaServer);
    }

    // Call this method to increase the score for Player Two.
    public void IncreaseScoreTwo()
    {
        photonView.RPC("RPC_IncreaseScoreTwo", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void RPC_IncreaseScoreOne()
    {
        scoreOne++;
        UpdateScoreText();
    }

    [PunRPC]
    void RPC_IncreaseScoreTwo()
    {
        scoreTwo++;
        UpdateScoreText();
    }

    // Update the Text component with the current score.
    private void UpdateScoreText()
    {
        scoreOneText.text = "Score: " + scoreOne.ToString();
        scoreTwoText.text = "Score: " + scoreTwo.ToString();
    }
}
