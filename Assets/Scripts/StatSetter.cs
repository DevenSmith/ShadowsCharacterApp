using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSetter : MonoBehaviour
{
	public StatsEnum MyStat;

	public void SetStat(string _value)
	{
		SetStat(int.Parse(_value));
	}

   public void SetStat(int _value)
	{
		StatsDisplay.Instance.SetSkill(MyStat, _value);
	}
}
