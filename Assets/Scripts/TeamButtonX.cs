using UnityEngine;

public class TeamButtonX : MonoBehaviour {
	public void ButtonTeamXOnClick(GameObject objX)
	{
		bool n = objX.activeSelf;
		objX.SetActive (!n);
	}
}