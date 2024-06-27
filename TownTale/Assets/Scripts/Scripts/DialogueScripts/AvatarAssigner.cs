using System.Collections.Generic;

using UnityEngine;

public class AvatarAssigner : MonoBehaviour
{
    public List<DialogueScriptableObject> allDialogues;
    public List<CharacterSpriteMapping> characterSpriteMappings;

    public void AssignAvatars()
    {
        if (allDialogues == null || characterSpriteMappings == null)
        {
            Debug.LogError("AssignAvatars: allDialogues or characterSpriteMappings is not set.");
            return;
        }

        Dictionary<string, Sprite> nameToSprite = new Dictionary<string, Sprite>();

        // Fill the dictionary with mappings
        foreach (var mapping in characterSpriteMappings)
        {
            if (!nameToSprite.ContainsKey(mapping.characterName))
            {
                nameToSprite.Add(mapping.characterName, mapping.avatar);
                Debug.Log($"Mapping added: {mapping.characterName} -> {mapping.avatar.name}");
            }
        }

        // Assign avatars based on character name
        foreach (var dialogue in allDialogues)
        {
            if (nameToSprite.ContainsKey(dialogue.characterName))
            {
                dialogue.avatar = nameToSprite[dialogue.characterName];
                Debug.Log($"Assigned avatar for character: {dialogue.characterName} -> {nameToSprite[dialogue.characterName].name}");
            }
            else
            {
                Debug.LogWarning($"No avatar found for character: {dialogue.characterName}");
            }
        }

        Debug.Log("Avatars assigned successfully!");
    }
}

[System.Serializable]
public class CharacterSpriteMapping
{
    public string characterName;
    public Sprite avatar;
}