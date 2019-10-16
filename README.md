<b>Welcome to Homebrew Devkit Project</b>

It provides help with importing and editing parts in Homebrew

https://store.steampowered.com/app/325420/Homebrew__Patent_Unknown/


<b>install:</b>

get unity 5.6.4 https://unity3d.com/get-unity/download/archive

download the devkit project form github, click [Clone or downlaod]

start unity 5.6.4 > click "open project" > select the root folder of Homebrew Devkit Project


<b>Homebrew Assets:</b>

assets are saved as .hbp files 

you can find them in 2 places 

official assets are found in "(steam install folder)/HB/StreamingAssets"

user created assets are found in "C:\Users\<user>\AppData\LocalLow\CopyBugPaste\Homebrew14\UserData"


<b>Opening parts:</b>

ok lets try opening an existing official part...

first open the "from scratch" scene wich can be found in "HBParts/Examples/from scratch"

in the utility bar go: "Homebrew/Asset/Import/Part"

browse to  "(steam install folder)/HB/StreamingAssets/Parts/Engines" and pick "V8.hbp"

you should now have the part open inside the devkit project


<b>Saving parts:</b>

now lets try saving a part...

first select the root gameObject of the part you want to save

( you know its a part root when it has the "PartContainer" component on it )


in the utility bar go: "Homebrew/Asset/Export Selected/Part"

save it as "myExportedPart.hbp" in "C:\Users\(user)\AppData\LocalLow\CopyBugPaste\Homebrew14\UserData/MyParts/<here>"


once saved you should be able to find in your parts browser in the builder

( in unity you can "save scene as..." under a new name, to keep a copy of your part in the project )


<b>your own models:</b>

models will transfer to  the game on export

to import your model into the devkit project simply export it as fbx or any (unity compatible format) insde the "Homebrew Devkit Project/Assets"  folder

( models may have bones / weights / blendshapes )


<b>your own materials and textures:</b>

materials and textures will not transfer to the game on export, your parts should use the "colorScheme" material provided in "HBCore/SharedASsets/Resources"


<b>your own part code:</b>

creating your own part code is not possible trough the devkit project, contact the devs on how to tackle this 

https://discord.gg/homebrew


<b>help grow the devkit project:</b>

tutorials and example scenes are appreciated 


for more help get on discord ^^
https://discord.gg/homebrew
