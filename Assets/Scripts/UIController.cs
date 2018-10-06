using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject ausgangsbild;
    public GameObject steingrab;
    public GameObject dolmengoettin;
    public GameObject wachturm;
    public GameObject karte;
    public GameObject museumAussen;
    public GameObject museumInnen;

    public void ChangeToAusgangsbild()
    {
        ausgangsbild.SetActive(true);
        steingrab.SetActive(false);
        dolmengoettin.SetActive(false);
        wachturm.SetActive(false);
        karte.SetActive(false);
        museumAussen.SetActive(false);
        museumInnen.SetActive(false);
    }

    public void ChangeToSteingrab()
    {
        ausgangsbild.SetActive(false);
        steingrab.SetActive(true);
        dolmengoettin.SetActive(false);
        wachturm.SetActive(false);
        karte.SetActive(false);
        museumAussen.SetActive(false);
        museumInnen.SetActive(false);
    }
    public void ChangeToDolmengoettin()
    {
        ausgangsbild.SetActive(false);
        steingrab.SetActive(false);
        dolmengoettin.SetActive(true);
        wachturm.SetActive(false);
        karte.SetActive(false);
        museumAussen.SetActive(false);
        museumInnen.SetActive(false);
    }
    public void ChangeToWachturm()
    {
        ausgangsbild.SetActive(false);
        steingrab.SetActive(false);
        dolmengoettin.SetActive(false);
        wachturm.SetActive(true);
        karte.SetActive(false);
        museumAussen.SetActive(false);
        museumInnen.SetActive(false);
    }
    public void ChangeToKarte()
    {
        ausgangsbild.SetActive(false);
        steingrab.SetActive(false);
        dolmengoettin.SetActive(false);
        wachturm.SetActive(false);
        karte.SetActive(true);
        museumAussen.SetActive(false);
        museumInnen.SetActive(false);
    }
    public void ChangeToMuseumAussen()
    {
        ausgangsbild.SetActive(false);
        steingrab.SetActive(false);
        dolmengoettin.SetActive(false);
        wachturm.SetActive(false);
        karte.SetActive(false);
        museumAussen.SetActive(true);
        museumInnen.SetActive(false);
    }
    public void ChangeToMuseumInnen()
    {
        ausgangsbild.SetActive(false);
        steingrab.SetActive(false);
        dolmengoettin.SetActive(false);
        wachturm.SetActive(false);
        karte.SetActive(false);
        museumAussen.SetActive(false);
        museumInnen.SetActive(true);
    }

}
