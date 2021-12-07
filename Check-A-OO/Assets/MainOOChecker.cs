using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOOChecker : MonoBehaviour {

    void Start() {

        MyAbility FA = MyAbility.Attack | MyAbility.Run;
        Debug.Log($"Name = {FA}, Value = {(int)FA}");

        var a = (MyAbility)FA;
        Debug.Log(a);
    }

}
