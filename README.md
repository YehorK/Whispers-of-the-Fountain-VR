# Whispers of the Fountain VR
The vitrual reality game that combines immersive storytelling & interactive experiences.

Creators: Alex Deaconu, Dina El-Kholy, Yehor Karpichev

The project also has an [AR implementation](https://github.com/YehorK/Whispers-of-the-Fountain-AR)! Check it out for a demo.

## Table of Contents
- [Project Setup](#project-setup)
- [Video Demo](#video-demo)
- [Storyline Overview](#storyline-overview)
- [Project Features](#project-features)
- [Acknowledgement](#acknowledgement)

## Project Setup
- You can simply git clone the main branch, and you should be able to start playing; no further setup steps required.
- The project is using Unity 2022.3.45f version.
- Additionally, the build (.apk file) made for Quest 2 headset can be found here: 

## Video demo:
[![Watch the video](https://img.youtube.com/vi/AP2FHY7DFlo/maxresdefault.jpg)](https://youtu.be/AP2FHY7DFlo)

## Storyline Overview
Our project is an immersive VR experience taking players on a treasure-hunting adventure, blending mystery, humor, and local Okanagan lore. The story begins with the protagonist discovering an ancient journal at their house. The journal reveals the legend of Ogopogo, a spirit imprisoned beneath a fountain, whose freedom hinges on the retrieval of his scattered soul fragments. Guided by the journal, the player explores the UBCO Courtyard, solving puzzles and interacting with landmarks. 

Whispering fragments offer both guiding clues and comic relief via 3D localized audio, as the player pieces together Ogopogo's spirit. The journey culminates at the fountain, where the player reunites the fragments to free Ogopogo. The story ends with a twist as Ogopogo’s sarcastic remarks challenge the expectations of treasure and reward. With our project, we hope to showcase potential for immersive storytelling, combining exploration, problem-solving, and a humor-driven narrative to create a captivating player experience. 

## Project Features
In the game progression order we explain the storyline elements, the game logic as well as the implemented game core mechanics.

### Journal Discovery
<img src="Images/bedroom scene view.png" alt="Bedroom scene" style="width: 100%; max-width: 600px; height: auto;"/>

The player spawns in their bedroom at the house, where an ancient journal reveals a clue about a hidden treasure. The player can interact with the journal by picking it up. After touching the doorknob, the scene transitions to the UBCO (main) scene.

### UBCO Courtyard Scene Features
<img src="Images/ubco scene view.png" alt="UBCO scene" style="width: 100%; max-width: 600px; height: auto;">

- The player is spawned at the edge of the gameplay area.
- The main area is made to be teleportable.
- The barriers are added to the map in the form of dense forest to ensure the player stays within the game area and for the overall visual appearance.
- The fog is added to create a more mysterious and immersive atmosphere.


### Fragment Features

<b>Whispers:</b> 
- Every soul fragment emits random auditory “whispers” with 3D sound for the practical purpose of providing hints to the player about the location of the next soul fragment. These are implemented as voice acting of 12 different funny comments and philosophical musings from the scattered pieces of Ogopogo’s soul.
  - *“If a soul fragment whispers in an empty courtyard, does it make a sound?”*

<b>Visual appearance:</b>
- The fragments vary their colors within a rainbow spectrum (changing the hue, while keeping full saturation/brightness).
- The fragments float in space, moving slightly up & down, waiting for the player to collect them.
- A sound is played when the fragment is collected by the player.


### Fragment 1 Interactions
- The journal provides a sense of direction for locating the first fragment.
- Green glowing crystals appear one by one, guiding the player toward the center of the map where the first fragment is located.
- Interaction with the fragment is collider-based.
- Upon collecting the fragment, a journal appears with a new clue for finding the second fragment. The journal includes both audio and text and remains active in the scene until the second fragment is successfully collected.
- This principle is repeated for the second and third fragments, allowing the player to revisit clues as needed.


### Fragment 2 Interactions
- The player discovers the second fragment at the deer stand, but a nearly invisible barrier surrounds the area.
- To remove the barrier, the player must use a carrot (spawned nearby) to guide a deer toward it.
- Deer Behavior:
  - The deer moves between two points (A and B) by default.
  - If the carrot game object comes within a modifiable proximity threshold, the deer follows it.
  - Once the carrot is no longer in proximity (or has been "eaten"), the deer returns to its regular A-B movement path.
- Barrier Interactions:
  - The player cannot pass through the barrier.
  - The carrot and deer can pass through. If the deer collides with the barrier, the barrier disappears.
- Carrot Behavior:
  - The carrot resets to its original position under the following conditions: it remains stationary for 8 seconds, its y-axis position becomes negative (immediate reset), the deer "eats" the carrot too early, before the barrier is destroyed (resets after 8 seconds).
- Once the fragment is collected, a journal with a new clue appears, mirroring the interaction from Fragment 1.


### Fragment 3 Interactions
- The 3rd fragment interaction is practically the same as the 1st – it only has to be found and collected. There is no challenge or puzzle that must be solved.
- When the fragment is collected, the journal appears and sends the player back to the fountain.


### The Ending
- When the player comes back to the fountain, they are greeted again by the journal, requesting to throw 3 fragments into the fountain along with the journal. The interactions are implemented by detecting the colliders of different elements in the game.
- When all the above-mentioned objects are destroyed, the Ogopogo rises from the center of the fountain & gives a humorous ending monologue.
- After the speech has finished, the Ogopogo game object keeps rising until it disappears, ending the game. 

## Acknowledgement
The list of used assets is available in the Attributions file under Assets.

