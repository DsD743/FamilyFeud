using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject buttonAddTeamAScore;
	public GameObject buttonAddTeamBScore;
	public GameObject objX;
	public GameObject[] answerGroup;
	public GameObject[] buttonAnswers;
	public AnswerGroupSO[] answerGroupSO;
	public GameObject gameOverCanvas;
	[Space(15f)]
	public Text textQuestionIndex;
	public Text textTeamAScore;
	public Text textTeamBScore;

	public Text[] scores;
	public Text[] answers;

	[Space(15f)]
	public int teamAScore;
	public int teamBScore;

	public int currentQ = 0;
	public int currentQScore;

	void Start()
	{
		currentQ = 0;
		teamAScore = 0;
		teamBScore = 0;

		textTeamAScore.text = teamAScore.ToString ();
		textTeamBScore.text = teamBScore.ToString ();

		NexttAnswerGroup ();
	}

	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.X)){
			if (objX.activeSelf)
				objX.SetActive (false);
			else
				objX.SetActive (true);
		}
	}

	void NexttAnswerGroup()
	{
		if(currentQ < answerGroupSO.Length){
			currentQScore = 0;

			int totalAnswer = answerGroupSO [currentQ].answerGroup.Length;

			for(int i = 0;i<answerGroup.Length;i++){
				if (i < totalAnswer) {
					answerGroup [i].SetActive (true);
					scores [i].text = string.Empty;
					answers [i].text = string.Empty;
				}
				else answerGroup [i].SetActive (false);

				buttonAnswers [i].SetActive (true);
			}

			textQuestionIndex.text = (currentQ+1).ToString ();
		}else{
			gameOverCanvas.SetActive (true);
			StartCoroutine (Exiting ());
		}
	}

	public void ButtonAnswerOnClick(int index)
	{
		buttonAnswers [index].SetActive (false);
		int score = answerGroupSO [currentQ].answerGroup [index].score;
		scores [index].text = score.ToString();
		answers [index].text = answerGroupSO [currentQ].answerGroup [index].answer;

		currentQScore += score;
	}

	public void AddTeamAScore()
	{
		teamAScore += currentQScore;
		textTeamAScore.text = teamAScore.ToString ();
		buttonAddTeamAScore.SetActive (false);
		buttonAddTeamBScore.SetActive (false);
	}

	public void AddTeamBScore()
	{
		teamBScore += currentQScore;
		textTeamBScore.text = teamBScore.ToString ();
		buttonAddTeamAScore.SetActive (false);
		buttonAddTeamBScore.SetActive (false);
	}

	public void ButtonNextQOnClick()
	{
		currentQ++;
		NexttAnswerGroup ();
		buttonAddTeamAScore.SetActive (true);
		buttonAddTeamBScore.SetActive (true);
	}

	IEnumerator Exiting()
	{
		WaitForSeconds w = new WaitForSeconds (5f);
		yield return w;
		Application.Quit ();
	}
}
