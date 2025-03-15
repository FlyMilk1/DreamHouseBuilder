using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    public TMP_Text text;
    public int curOpt = 0;
    int maxOpt = 2;
    string[] bgsettings = { "Ниско", "Средно", "Високо" };
    public Setting settings = new Setting();
    private string settingsFilePath;
    public AudioMixer SFXMixer;
    public AudioMixer MusicMixer;
    public Slider[] sliders;
    [Serializable]
    public class Setting
    {
        public int video;
        public float sfxvolume;
        public float musicvolume;
    }
    private void Start()
    {
        settingsFilePath = Path.Combine(Application.persistentDataPath, "Settings.json");

        if (!File.Exists(settingsFilePath))
        {
            settings.video = 2;
            settings.sfxvolume = 0;
            settings.musicvolume = 0;
            WriteToFile();
        }
        else
        {
            string json = File.ReadAllText(settingsFilePath);
            settings = JsonUtility.FromJson<Setting>(json);
        }
        
        curOpt = settings.video;
        text.text = bgsettings[curOpt];
        sliders[0].value = settings.sfxvolume;
        sliders[1].value = settings.musicvolume;
        QualitySettings.SetQualityLevel(settings.video);
    }

    

    public void ChangeDown()
    {
        if (curOpt <= 0)
        {
            curOpt = maxOpt;
        }
        else
        {
            curOpt--;
        }
        text.text = bgsettings[curOpt];
        VideoSet();
    }

    public void ChangeUp()
    {
        if (curOpt >= maxOpt)
        {
            curOpt = 0;
        }
        else
        {
            curOpt++;
        }
        text.text = bgsettings[curOpt];
        VideoSet();
    }
    public void ChangeSliderUp(Slider slider)
    {
        
        
            slider.value = Math.Clamp(slider.value + 10, -80, 0);
        
    }
    public void ChangeSliderDown(Slider slider)
    {
       
            slider.value = Math.Clamp(slider.value - 10, -80, 0);
        
       
    }
    public void SfxSlider(Slider slider)
    {
        
        settings.sfxvolume = slider.value;
        SFXMixer.SetFloat("Master", slider.value);
        WriteToFile();
    }
    public void MusicSlider(Slider slider)
    {
        settings.musicvolume = slider.value;
        MusicMixer.SetFloat("Master", slider.value);
        WriteToFile();
    }
    private float ValueToVolume(float value)
    {
        return Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * (0 - -80) / 4f + 0;
    }

    void VideoSet()
    {
        settings.video = curOpt;
        QualitySettings.SetQualityLevel(settings.video);
        WriteToFile();
    }

    void WriteToFile()
    {
        string json = JsonUtility.ToJson(settings);
        try
        {
            File.WriteAllText(settingsFilePath, json);
        }
        catch (IOException ex)
        {
            Debug.LogError("Failed to write to file: " + ex.Message);
        }
    }
}