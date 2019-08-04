using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VoxelBusters.NativePlugins;
using System.IO;

public class StatsDisplay : MonoBehaviour
{
	public static StatsDisplay Instance;
	public Stats BaseStats;
	public Stats ModifiedStats;

	public Image CharacterImage;

	public TextMeshProUGUI NameValue;
	public TextMeshProUGUI KeywordsValue;

	[Header ("Skills")]
	public TextMeshProUGUI AgilityValue;
	public TextMeshProUGUI CunningValue;
	public TextMeshProUGUI SpiritValue;
	public TextMeshProUGUI StrengthValue;
	public TextMeshProUGUI LoreValue;
	public TextMeshProUGUI LuckValue;

	[Header("Combat")]
	public TextMeshProUGUI InitiativeValue;
	public TextMeshProUGUI CombatValue;
	public TextMeshProUGUI GritValue;
	public TextMeshProUGUI RangedValue;
	public TextMeshProUGUI MeleeValue;

	[Header("Defense")]
	public TextMeshProUGUI HealthValue;
	public TextMeshProUGUI CurHealthValue;
	public TextMeshProUGUI SanityValue;
	public TextMeshProUGUI CurSanityValue;
	public TextMeshProUGUI CorruptionValue;
	public TextMeshProUGUI ResistanceValue;
	public TextMeshProUGUI DefenseValue;
	public TextMeshProUGUI WillpowerValue;

	public void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		else
			Instance = this;

		if (PlayerPrefs.HasKey(PrefsKeys.STATS))
		{
			BaseStats = JsonUtility.FromJson<Stats>(PlayerPrefs.GetString(PrefsKeys.STATS));
		}

		if(BaseStats.PicturePath != "")
		{
			CharacterImage.sprite = Sprite.Create(Resources.Load<Texture2D>(BaseStats.PicturePath),
				CharacterImage.rectTransform.rect, CharacterImage.rectTransform.pivot);
		}
	}

	public void GetPhoto()
	{
		NPBinding.MediaLibrary.PickImage(eImageSource.BOTH, 1.0f, PickImageFinished);
	}

	private void PickImageFinished(ePickImageFinishReason _reason, Texture2D _image)
	{
		Debug.Log("Reason = " + _reason);
		Debug.Log("Texture = " + _image);
		CharacterImage.sprite = Sprite.Create(_image, CharacterImage.rectTransform.rect, CharacterImage.rectTransform.pivot);
		SaveTextureToFile(_image, _image.name);
	}

	void SaveTextureToFile(Texture2D _texture, string _fileName)
	{
		BaseStats.PicturePath = Application.dataPath + "/Resources/" + _fileName;
		System.IO.File.WriteAllBytes(BaseStats.PicturePath, _texture.EncodeToPNG());  
	}

	public void Start()
	{
		UpdateDisplay();
	}

	public void SaveStats()
	{
		PlayerPrefs.SetString(PrefsKeys.STATS, JsonUtility.ToJson(BaseStats));
	}

	public void SetName(string _value)
	{
		BaseStats.Name = _value;
		SaveStats();
		UpdateDisplay();
	}

	public void SetKeywords(string _value)
	{
		BaseStats.Keywords.Clear();
		string[] _split = _value.Split(' ');
		for(int i = 0; i < _split.Length; i++)
		{
			BaseStats.Keywords.Add(_split[i]);
		}

		ShowKeywords();
		
		SaveStats();
	}

	public void ShowKeywords()
	{
		List<string> _used = new List<string>();
		foreach (string _s in BaseStats.Keywords)
		{
			if (!_used.Contains(_s))
			{
				_used.Add(_s);
			}
		}

		foreach (string _s in ModifiedStats.Keywords)
		{
			if (!_used.Contains(_s))
			{
				_used.Add(_s);
			}
		}

		string _display = "";
		foreach (string _s in _used)
		{
			_display = _display + " " + _s;
		}

		KeywordsValue.text = _display;
	}

	public void ModifyKeywords(string _value)
	{
		ModifiedStats.Keywords.Add(_value);
	}

	public void SetSkill(StatsEnum _enum, int _value)
	{
		switch(_enum)
		{
			case StatsEnum.Agility:
				BaseStats.Agility = _value;
				break;
			case StatsEnum.Combat:
				BaseStats.Combat = _value;
				break;
			case StatsEnum.Corruption:
				BaseStats.Corruption = _value;
				break;
			case StatsEnum.Cunning:
				BaseStats.Cunning = _value;
				break;
			case StatsEnum.CurHealth:
				BaseStats.CurHealth = _value;
				break;
			case StatsEnum.CurSanity:
				BaseStats.CurSanity = _value;
				break;
			case StatsEnum.Defense:
				BaseStats.Defense = _value;
				break;
			case StatsEnum.Grit:
				BaseStats.Grit = _value;
				break;
			case StatsEnum.Health:
				BaseStats.Health = _value;
				break;
			case StatsEnum.Initiative:
				BaseStats.Initiative = _value;
				break;
			case StatsEnum.Lore:
				BaseStats.Lore = _value;
				break;
			case StatsEnum.Luck:
				BaseStats.Luck = _value;
				break;
			case StatsEnum.Melee:
				BaseStats.Melee = _value;
				break;
			case StatsEnum.Ranged:
				BaseStats.Ranged = _value;
				break;
			case StatsEnum.Resistance:
				BaseStats.Resistance = _value;
				break;
			case StatsEnum.Sanity:
				BaseStats.Sanity = _value;
				break;
			case StatsEnum.Spirit:
				BaseStats.Spirit = _value;
				break;
			case StatsEnum.Strength:
				BaseStats.Strength = _value;
				break;
			case StatsEnum.Willpower:
				BaseStats.Willpower = _value;
				break;
		}
		UpdateDisplay();
		SaveStats();
	}

	public void ModifySkill(StatsEnum _enum, int _value)
	{
		switch (_enum)
		{
			case StatsEnum.Agility:
				ModifiedStats.Agility += _value;
				break;
			case StatsEnum.Combat:
				ModifiedStats.Combat += _value;
				break;
			case StatsEnum.Corruption:
				ModifiedStats.Corruption += _value;
				break;
			case StatsEnum.Cunning:
				ModifiedStats.Cunning += _value;
				break;
			case StatsEnum.CurHealth:
				ModifiedStats.CurHealth += _value;
				break;
			case StatsEnum.CurSanity:
				ModifiedStats.CurSanity += _value;
				break;
			case StatsEnum.Defense:
				ModifiedStats.Defense += _value;
				break;
			case StatsEnum.Grit:
				ModifiedStats.Grit += _value;
				break;
			case StatsEnum.Health:
				ModifiedStats.Health += _value;
				break;
			case StatsEnum.Initiative:
				ModifiedStats.Initiative += _value;
				break;
			case StatsEnum.Lore:
				ModifiedStats.Lore += _value;
				break;
			case StatsEnum.Luck:
				ModifiedStats.Luck += _value;
				break;
			case StatsEnum.Melee:
				ModifiedStats.Melee += _value;
				break;
			case StatsEnum.Ranged:
				ModifiedStats.Ranged += _value;
				break;
			case StatsEnum.Resistance:
				ModifiedStats.Resistance += _value;
				break;
			case StatsEnum.Sanity:
				ModifiedStats.Sanity += _value;
				break;
			case StatsEnum.Spirit:
				ModifiedStats.Spirit += _value;
				break;
			case StatsEnum.Strength:
				ModifiedStats.Strength += _value;
				break;
			case StatsEnum.Willpower:
				ModifiedStats.Willpower += _value;
				break;
		}
		UpdateDisplay();
	}

	public void UpdateDisplay()
	{
		NameValue.text = BaseStats.Name;
		ShowKeywords();
		//Skills
		AgilityValue.text = "(" + (BaseStats.Agility + ModifiedStats.Agility).ToString() + ")";
		CunningValue.text = "(" + (BaseStats.Cunning + ModifiedStats.Cunning).ToString() + ")";
		SpiritValue.text = "(" + (BaseStats.Spirit + ModifiedStats.Spirit).ToString() + ")";
		StrengthValue.text = "(" + (BaseStats.Strength + ModifiedStats.Strength).ToString() + ")";
		LoreValue.text = "(" + (BaseStats.Lore + ModifiedStats.Lore).ToString() + ")";
		LuckValue.text = "(" + (BaseStats.Luck + ModifiedStats.Luck).ToString() + ")";

		//Combat
		InitiativeValue.text = "(" + (BaseStats.Initiative + ModifiedStats.Initiative).ToString() + ")";
		CombatValue.text = "(" + (BaseStats.Combat + ModifiedStats.Combat).ToString() + ")";
		GritValue.text = "(" + (BaseStats.Grit + ModifiedStats.Grit).ToString() + ")";
		RangedValue.text = "(" + (BaseStats.Ranged + ModifiedStats.Ranged).ToString() + ")";
		MeleeValue.text = "(" + (BaseStats.Melee + ModifiedStats.Melee).ToString() + ")";

		//Defense
		HealthValue.text = "(" + (BaseStats.Health + ModifiedStats.Health).ToString() + ")";
		CurHealthValue.text = "(" + (BaseStats.CurHealth + ModifiedStats.CurHealth).ToString() + ")";
		SanityValue.text = "(" + (BaseStats.Sanity + ModifiedStats.Sanity).ToString() + ")";
		CurSanityValue.text = "(" + (BaseStats.CurSanity + ModifiedStats.CurSanity).ToString() + ")";
		CorruptionValue.text = "(" + (BaseStats.Corruption + ModifiedStats.Corruption).ToString() + ")";
		ResistanceValue.text = "(" + (BaseStats.Resistance + ModifiedStats.Resistance).ToString() + ")";
		DefenseValue.text = "(" + (BaseStats.Defense + ModifiedStats.Defense).ToString() + ")";
		WillpowerValue.text = "(" + (BaseStats.Willpower + ModifiedStats.Willpower).ToString() + ")";
	}
}
