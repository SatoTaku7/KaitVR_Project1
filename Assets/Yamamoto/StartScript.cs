using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

	//�@�X�^�[�g�{�^��������������s����
	public void StartGame()
	{
		SceneManager.LoadScene("PlayScene");
	}
}