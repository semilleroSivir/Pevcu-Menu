using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class text_about_proyect : MonoBehaviour {

	public GameObject textView;
	private int count;
	// Use this for initialization
	void Start () {
		count = 0;
		update_text(count);
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown (KeyCode.A)) {
			print ("space key was pressed");
			count--;
			if (count < 0) {
				count = 0;
			}
			update_text(count);
		}
		
		if (Input.GetKeyDown (KeyCode.D)) {
			print ("space key was pressed");
			count++;
			if (count > 7) {
				count = 7;
			}
			update_text(count);
		}
	}

	void update_text(int value){
		Text label = textView.GetComponent<Text> ();
		if (value == 0) {
			label.text = "\n\n\t\t\t\t\tSivir\n\n\t\t\tSeptiembre 2015" ;
		} else if (value == 1) {
			label.text = "Integrantes\n\n" +
				         "Estudiantes:\n" +
					     "\tCarlos Maximiliano Galván\n" +
					     "\tCarlos Arturo Galván\n" +
					     "\tRafael Eduardo Torres";
		}else if (value == 2) {
			label.text = "Estudiantes:\n" +
				         "\tLizeth Lozada Trejos\n" +
					     "\tAlex Anacona\n" +
					     "\tZen Salazar\n" +
					     "\tDaniel Trochez\n" +
					     "\tErik Fernandez";
		}else if (value == 3) {
			label.text = "Docentes:\n\n" +
				         "\tJacqueline D.Cardona\n" +
					     "\tSteve Rodriguez Guerrero";
		}else if (value == 4) {
			label.text = "Introducción:\n\n" +
				"Los simuladores son herramientas que permiten llevar a la práctica algunos conocimientos que de otra";
		}else if (value == 5) {
			label.text ="manera no sería viable hacerlos tangibles.\n\n" +
				        "La recreación de situaciones reales en entornos virtuales";
		}else if (value == 6) {
			label.text ="se presenta ahora como una vía para que muchas personas puedan experimentar y desarrollarn";
		}else if (value == 7) {
			label.text ="competencias desde cualquier lugar; en pocas palabras, en escenarios a los que a veces no tienen acceso.";
		}
	}
}
