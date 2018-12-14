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
            s1.Add(new SpeechInstance("Wow this looks amazing! It looks exactly like it was described in the books i have read.", 6f, 6f, professor));
            s1.Add(new SpeechInstance("So... Professor Stone was it?", 4f, 4f, !professor));
            s1.Add(new SpeechInstance("Yes?", 3f, 3f, professor));
            s1.Add(new SpeechInstance("In the books you have read, did they mention any danger we should be aware of?", 6f, 6f, !professor));
            s1.Add(new SpeechInstance("There will be danger ahead, but sadly I do not know what kind of danger.", 6f, 6f, professor));
            s1.Add(new SpeechInstance("Great...", 6f, 6f, !professor));
            sequences.Add("Entry", new SpeechSequence(s1));

            // Middle room
            List<SpeechInstance> s2 = new List<SpeechInstance>();
            s2.Add(new SpeechInstance("Hmm.. this door seems different from the previous doors.", 6f, 6f, professor));
            s2.Add(new SpeechInstance("I wonder what’s behind it.", 4f, 4f, professor));
            s2.Add(new SpeechInstance("You’re right, but how do we get the door open?", 6f, 6f, !professor));
            s2.Add(new SpeechInstance("If we had some explosives we could blow it up.", 6f, 6f, !professor));
            s2.Add(new SpeechInstance("Look here! It seems like there is something missing beside the door, some kind of round object.", 6f, 6f, professor));
            s2.Add(new SpeechInstance("I wonder if it is some kind of gizmo to open the door.", 6f, 6f, professor));
            s2.Add(new SpeechInstance("I vote for blowing up the door.", 6f, 6f, !professor));
            s2.Add(new SpeechInstance("I mean, we don’t even know if this “missing object” is even in the temple?!", 6f, 6f, !professor));
            sequences.Add("MiddleRoom", new SpeechSequence(s2));

            // Explosive room
            List<SpeechInstance> s3 = new List<SpeechInstance>();
            s3.Add(new SpeechInstance("Look, I think there’s something in those jars over there.", 6f, 6f, !professor));
            s3.Add(new SpeechInstance("It looks like some kind of gunpowder. Maybe we could use this to blow open the door!", 6f, 6f, !professor));
            s3.Add(new SpeechInstance("I really don’t think we should do that! We don’t know what is on the other side, we might destroy something precious.", 6f, 6f, professor));
            s3.Add(new SpeechInstance("I’m sure it will be fine, don’t worry about it.", 6f, 6f, !professor));
            s3.Add(new SpeechInstance("I don’t know, it just doesn’t seem right.", 6f, 6f, professor));
            s3.Add(new SpeechInstance("We should take the gunpowder, we can always decide what to do later!", 6f, 6f, !professor));
            sequences.Add("ExplosiveRoom", new SpeechSequence(s3));

            // Medallion room
            List<SpeechInstance> s4 = new List<SpeechInstance>();
            s4.Add(new SpeechInstance("There is something written on the wall over there.", 6f, 6f, professor));
            s4.Add(new SpeechInstance("It says something about a medallion.", 6f, 6f, professor));
            s4.Add(new SpeechInstance("I remember reading something about a medaljon once. As far as I recall it belonged to a Mayan God who protected travellers, soldiers and explorers, I think his name was Ekchuah.", 8f, 8f, professor));
            s4.Add(new SpeechInstance("I wonder if this is the key we are looking for...", 6f, 6f, professor));
            s4.Add(new SpeechInstance("But isn’t it just a medallion, I don’t think it unlocks anything.", 6f, 6f, !professor));
            s4.Add(new SpeechInstance("We should try to use it by the door, it wouldn’t hurt to try.", 6f, 6f, professor));
            sequences.Add("MedallionRoom", new SpeechSequence(s4));

            // Death room
            List<SpeechInstance> s5 = new List<SpeechInstance>();
            s5.Add(new SpeechInstance("...", 4f, 4f, professor));
            s5.Add(new SpeechInstance("Oh my god, I’ve never seen anything like this!", 6f, 6f, !professor));
            s5.Add(new SpeechInstance("I think we should leave here, immediately!", 6f, 6f, professor));
            s5.Add(new SpeechInstance("Let’s just take a look around, there doesn’t seems to be any threat at the moment.", 6f, 6f, !professor));
            s5.Add(new SpeechInstance("Okay, but be careful what you touch.", 6f, 6f, professor));
            sequences.Add("DeathRoom", new SpeechSequence(s5));

        }
    }
}
