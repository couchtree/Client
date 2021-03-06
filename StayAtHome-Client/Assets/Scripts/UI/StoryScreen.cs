﻿using System.Collections;
using System.Collections.Generic;
using Core.Map;
using UnityEngine;
using TMPro;

namespace UI
{
    /// <summary>
    /// Manages the story-scene by providing the next text snipped or advancing to the next scene if story was read completely.
    /// </summary>
    public class StoryScreen : MonoBehaviour
    {
        private List<string> storyParts = new List<string>();
        public TextMeshProUGUI text;

        private int storyIndex = 0;


        // Start is called before the first frame update
        void Start()
        {
            storyParts.Add(
                "Als dich am heutigen Morgen die ersten Sonnenstrahlen aus dem Schlaf reißen, nimmst du noch im Bett liegend dein Smartphone in die Hand und liest wie jeden morgen durch die täglichen News. \"Blattlausplage bedroht unsere Pflanzen! Nun zählt die Hilfe eines jeden Einzelnen!\" siehst du als erste Schlagzeile und fällst vor Schreck aus dem Bett.");
            storyParts.Add(
                "Nachdem du aufgestanden und dich vom ersten Schock erholt hast, liest du den Artikel weiter. Nach diesem sei eine Plage an neuartigen Blattläusen ausgebrochen, welche jegliche Art an Pflanzen befällt, welche sich im Freien befinden und von Menschen umgeben sind.");
            storyParts.Add(
                "Pflanzen in geschlossenen Räumen, mit wenig Menschen in der Nähe seien weniger anfällig. Daher werde jeder Bürger gebeten sich so viel wie möglich daheim aufzuhalten und eigene Pflanzen zu halten, um die Plage nicht zu fördern, bis diese vorüber ist und um jeglichen Verlust an Pflanzen so niedrig wie möglich zu halten.");
            storyParts.Add(
                "Natürlich darf man sich weiterhin im Freien aufhalten, dennoch sollte dies allein und nicht zu lange geschehen, um die eigenen Pflanzen zu schützen. Es ist wichtig zusammenzuhalten, jeder sollte sich gegenseitig unterstützen, um neben der Pflanzenpflege anderen wichtigen Erledigungen nachkommen zu können, ohne dabei die aktuelle Lage zu verschlimmern.");
            storyParts.Add(
                "Am Ende des Artikel liest du noch den Satz: “Pflanzt Bäume und verschiedene Pflanzen, bleibt zu Hause, kümmert euch um sie und seid Helden!”. Du merkst, dass alle eine gemeinsame Mission haben und dass du deinen Beitrag dazu leisten möchtest.");
            storyParts.Add(
                "Eine Blattlausplage bedroht all unsere Pflanzen. Nur wenn jeder zu Hause einen eigenen kleinen Garten anlegt, diesen pflegt und beschützt, kann die Krise gut überstanden werden. Sei ein Gärtner, sei ein Held.");
            text.SetText(storyParts[storyIndex]);
            storyIndex++;
        }

        /// <summary>
        /// Advances to the next part of the story. If the whole story was displayed, it triggers the next scene loading.
        /// </summary>
        public void showNextStoryPart()
        {
            if (storyIndex < storyParts.Count)
            {
                text.SetText(storyParts[storyIndex]);
                storyIndex++;
            }
            else
            {
                PlayerPrefs.SetInt("story.startstory.read", 1);
                switchToNextScene();
            }
        }

        private void switchToNextScene()
        {
            SceneLoading sceneLoading = GetComponent<SceneLoading>();
            sceneLoading.LoadScene(2);
        }
    }
}