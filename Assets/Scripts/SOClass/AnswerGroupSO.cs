using UnityEngine;

[System.Serializable]
public struct AnswerGroup{
	public int score;
	public string answer;
}

[CreateAssetMenu(fileName = "AnswerGroup_",menuName = "SOData/AnswerGroup",order = 1)]
public class AnswerGroupSO : ScriptableObject {
	public AnswerGroup[] answerGroup;
}

