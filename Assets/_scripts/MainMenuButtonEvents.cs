using UnityEngine;
using System.Collections;

public class MainMenuButtonEvents : MonoBehaviour {

	public Canvas mainCanvas;
	public Canvas aboutCanvas;
	public Canvas aboutCanvas_2;
	public Canvas controlCanvas;

	public void BeginGame() {
		Application.LoadLevel("Game");
	}
	
	public void Main() {
		mainCanvas.gameObject.SetActive(true);
		aboutCanvas.gameObject.SetActive(false);
		aboutCanvas_2.gameObject.SetActive(false);
		controlCanvas.gameObject.SetActive(false);
	}
	
	public void About_1() {
		mainCanvas.gameObject.SetActive(false);
		aboutCanvas.gameObject.SetActive(true);
		aboutCanvas_2.gameObject.SetActive(false);
	}
	
	public void About_2() {
		mainCanvas.gameObject.SetActive(false);
		aboutCanvas.gameObject.SetActive(false);
		aboutCanvas_2.gameObject.SetActive(true);
	}
	
	public void Control() {
		mainCanvas.gameObject.SetActive(false);
		controlCanvas.gameObject.SetActive(true);
	}
	
	public void Quit() {
		Application.Quit();
	}
}
