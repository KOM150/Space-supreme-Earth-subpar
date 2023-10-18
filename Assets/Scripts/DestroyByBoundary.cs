﻿using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    //OnTriggerExit(): Collider(충돌체)간에 Trigger(충돌 감지)이 일어나면 호출
    void OnTriggerExit (Collider other) 
	{
		//객체 제거
		Destroy(other.gameObject);
	}
}