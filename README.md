*SteamVR Social*

Simple Unity Application to interact with objects in Virtual Reality while socializing with friends


Layer Uses (for collision, culling, raycasting, what is in each layer)
Tag Uses
GUI Depths for the layers
Scene Setup
Idiom Preferences
Prefab Structure
Animation Layers

Naming General Principles
Call a thing what it is. A bird should be called Bird.
Choose names that can be pronounced and remembered. If you make a Mayan game, do not name your level QuetzalcoatisReturn.
Be consistent. When you choose a name, stick to it.
Use Pascal case, like this: ComplicatedVerySpecificObject. Do not use spaces, underscores, or hyphens, with one exception (see Naming Different Aspects of the Same Thing).
Do not use version numbers, or words to indicate their progress (WIP, final).
Do not use abbreviations: DVamp@W should be DarkVampire@Walk.
Use the terminology in the design document: if the document calls the die animation Die, then use DarkVampire@Die, not DarkVampire@Death.
Keep the most specific descriptor on the left: DarkVampire, not VampireDark; PauseButton, not ButtonPaused. It is, for instance, easier to find the pause button in the inspector if not all buttons start with the word Button. [Many people prefer it the other way around, because that makes grouping more obvious visually. Names are not for grouping though, folders are. Names are to distinguish objects of the same type so that they can be located reliably and fast.]
Some names form a sequence. Use numbers in these names, for example, PathNode0, PathNode1. Always start with 0, not 1.
Do not use numbers for things that don’t form a sequence. For example, Bird0, Bird1, Bird2 should be Flamingo, Eagle, Swallow.
Prefix temporary objects with a double underscore __Player_Backup.
Naming Different Aspects of the Same Thing
Use underscores between the core name, and the thing that describes the “aspect”. For instance:

GUI buttons states EnterButton_Active, EnterButton_Inactive
Textures DarkVampire_Diffuse, DarkVampire_Normalmap
Skybox JungleSky_Top, JungleSky_North
LOD Groups DarkVampire_LOD0, DarkVampire_LOD1
Do not use this convention just to distinguish between different types of items, for instance Rock_Small, Rock_Large should be SmallRock, LargeRock.

Structure
The organisation of your scenes, project folder, and script folder should follow a similar pattern.

Folder Structure

Materials
GUI
Effects
Meshes
   Actors
      DarkVampire
      LightVampire
      ...
   Structures
      Buildings
      ...
   Props
      Plants
      ...
   ...
Plugins
Prefabs
   Actors
   Items
   ...
Resources
   Actors
   Items
   ...
Scenes
   GUI
   Levels
   TestScenes
Scripts
Textures
GUI
Effects
...
Scene Structure

Cameras
Dynamic Objects
Gameplay
   Actors
   Items
   ...
GUI
   HUD
   PauseMenu
   ...
Management
Lights
World
   Ground
   Props
   Structure
   ...
Scripts Folder Structure

ThirdParty
   ...
MyGenericScripts
   Debug
   Extensions
   Framework
   Graphics
   IO
   Math
   ...
MyGameScripts
   Debug
   Gameplay
      Actors
      Items
      ...
   Framework
   Graphics
   GUI
   ...