using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedSpeech : MonoBehaviour {

    public SmallTalk st;
    public CompanionInterface c1;
    public CompanionInterface c2;

    Dictionary<string, SpeechSequence> sequences = new Dictionary<string, SpeechSequence>();

    private void Start() {
        setupSequences();
    }

    public void playSequence(string name) {
        if (!sequences.ContainsKey(name))
            return;

        SpeechSequence s = sequences[name];
        StartCoroutine(speechProcess(s));
    }

    IEnumerator speechProcess(SpeechSequence s) {
        st.stopST();
        SpeechInstance speech = new SpeechInstance();
        while (!s.isDone()) {
            speech = s.getNext();

            // Output speech
            if (speech.c1Speaker) {
                c1.companionSpeechController.say(speech.message, speech.lifetime);
            }
            else {
                c2.companionSpeechController.say(speech.message, speech.lifetime);
            }

            yield return new WaitForSeconds(speech.replyTime); //Wait for finishing talking
        }
        yield return new WaitForSeconds(speech.replyTime);
        st.startST();
    }

    void setupSequences() {
        string nameCompound = c1.companionName + c2.companionName;

        if (nameCompound.Contains("Professor") && nameCompound.Contains("Specialist")) {
            // Is c1 the professor?
            bool professor;
            if (c1.companionName == "Professor")
                professor = true;
            else
                professor = false;

            // Entry
            List<SpeechInstance> s1 = new List<SpeechInstance>();
            s1.Add(new SpeechInstance("What magnificent interior, look at the details on the walls!", 6f, 5f, professor));
            s1.Add(new SpeechInstance("This would make for great outpost, cool and pretty looking", 6f, 5f, !professor));
            s1.Add(new SpeechInstance("Don't you even think about doing that to this extraordinary place!", 6f, 5f, professor));
            s1.Add(new SpeechInstance("Relax prof I was joking, jeez", 6f, 5f, !professor));
            sequences.Add("Entry", new SpeechSequence(s1));
        }
    }
}
