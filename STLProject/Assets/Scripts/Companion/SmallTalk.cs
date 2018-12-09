using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTalk : MonoBehaviour {

    public CompanionInterface c1;
    public CompanionInterface c2;
    public float delayMin;
    public float delayMax;
    [HideInInspector]
    public bool smallTalkEnabled;
    List<SpeechSequence> c1Sequences = new List<SpeechSequence>();
    List<SpeechSequence> c2Sequences = new List<SpeechSequence>();

    Coroutine stpCoroutine;

    private void Start() {
        getData();
        smallTalkEnabled = true;
        startST();
    }

    public void startST() {
        stpCoroutine = StartCoroutine(smallTalkProcess());
    }

    public void stopST() {
        StopCoroutine(stpCoroutine);
    }

    IEnumerator smallTalkProcess() {
        while (smallTalkEnabled) {
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax)); // Wait for next small talk

            int randomInt = Random.Range(0, c1Sequences.Count);
            print(c1Sequences.Count);
            SpeechSequence sequence = c1Sequences[randomInt];

            while (!sequence.isDone()) {
                SpeechInstance speech = sequence.getNext();

                // Output speech
                if (speech.c1Speaker) {
                    c1.companionSpeechController.say(speech.message, speech.lifetime);
                }
                else {
                    c2.companionSpeechController.say(speech.message, speech.lifetime);
                }

                yield return new WaitForSeconds(speech.replyTime); //Wait for finishing talking
            }
        }
    }


    // DATA // (Rework to parse file)
    void getData() {
        // c1
        switch (c1.companionName) {
            case "Specialist":
                //print(c1.companionName);
                c1Sequences.AddRange(specialistData(c2, true));
                //print(c1Sequences.Count);
                break;

            default:
                break;
        }

        // c2
        switch (c2.name) {
            case "Specialist":
                c2Sequences.AddRange(specialistData(c1, false));
                break;

            default:
                break;
        }
    }

    List<SpeechSequence> specialistData(CompanionInterface otherCompanion, bool c1) {
        List<SpeechSequence> output = new List<SpeechSequence>();

        if (otherCompanion.companionName == "Professor") { // All professor
            // S1
            List<SpeechInstance> s1 = new List<SpeechInstance>();
            s1.Add(new SpeechInstance("All this running is good for your health Professor", 6f, 5f, c1));
            s1.Add(new SpeechInstance("I fear it will end my life before it does it any good though", 6f, 5f, !c1));
            s1.Add(new SpeechInstance("'Chuckles'", 6f, 5f, c1));
            output.Add(new SpeechSequence(s1));
        }

        return output;
    }
}

public struct SpeechSequence {
    List<SpeechInstance> sequence;
    int i;

    public SpeechSequence(List<SpeechInstance> isq) {
        sequence = isq;
        i = 0;
    }

    public SpeechInstance getNext() {
        SpeechInstance output = sequence[i];
        i++;
        return output;
    }

    public bool isDone() {
        if (i < sequence.Count)
            return false;
        return true;
    }

    public void reset() {
        i = 0;
    }
}

public struct SpeechInstance {
    public SpeechInstance(string im, float il, float ir, bool c1s) {
        message = im;
        lifetime = il;
        replyTime = ir;
        c1Speaker = c1s;
    }
    public string message;
    public float lifetime;
    public float replyTime;
    public bool c1Speaker;
}