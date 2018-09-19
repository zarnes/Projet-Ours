using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	public Text Chrono;
	public Text Meill;
	public float Temps_de_depart;
	private string MinutesLastS;
	private float MinutesLast;
	private string MinutesS;
	private float Minutes;
    private float MinutesTemp;
    private string SecondesLastS;
	private float SecondesLast;
	private string SecondesS;
	private float Secondes;
    private float SecondesTemp;
    public bool Fin;

	void Start () {
		Temps_de_depart = Time.time;
	}

	void Update () {
		float t = Time.time - Temps_de_depart;
		Secondes = (t % 60);
		Minutes = ((int) t / 60);
		SecondesS = (Secondes - SecondesLast).ToString ("F2");
		MinutesS = (Minutes - MinutesLast).ToString();
		Chrono.text = "Actuel : " + MinutesS + ":" + SecondesS;

	if (Fin == true){
        MinutesTemp = Minutes;
        SecondesTemp = Secondes;
        MinutesLast = Minutes - MinutesTemp;
		SecondesLast = Secondes - SecondesTemp;
		MinutesLastS = MinutesLast.ToString();
		SecondesLastS = SecondesLast.ToString();
        Meill.text = "Dernier : " + MinutesLastS + ":" + SecondesLastS;
        }		
}
}