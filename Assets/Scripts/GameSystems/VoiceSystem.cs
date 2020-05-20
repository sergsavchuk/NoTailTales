﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSystem : MonoBehaviour, IGameListener
{
    [SerializeField]
    private RectTransform voiceTemplate;

    [SerializeField]
    private VoiceDiagramGenerator voiceDiagramPrefab;

    [SerializeField]
    private SpawnSystem spawnSystem;

    [SerializeField]
    private AudioSystem audioSystem;

    [SerializeField]
    private AnimalTypes animalTypes;

    private bool diagramAdded = true;
    private Animal currentAnimal = null;

    public void addVoiceDiagram()
    {
        if (diagramAdded)
            return;

        audioSystem.playAnimalVoice();

        AnimalType animalType = animalTypes.getTypeById(currentAnimal.typeId);

        VoiceDiagramGenerator voiceDiagram = spawnSystem.spawnPrefab(voiceDiagramPrefab.GetComponent<RectTransform>()).GetComponent<VoiceDiagramGenerator>();
        voiceDiagram.init(animalType.voiceMin, animalType.voiceMax, true, 2);
        voiceDiagram.generate();

        diagramAdded = true;
    }

    public void OnAnimalCome(GameControllerScript game, Animal animal)
    {
        diagramAdded = false;
        currentAnimal = animal;
    }

    public void OnGameInit(GameControllerScript game, Day day)
    {

    }

    public bool isDiagramAdded()
    {
        return diagramAdded;
    }
}