prison-architect-lib
====================

.NET 3.5 Library being built to manipulate the save files for Prison Architect

Still very basic set of interactions, but as of 27/01/14 it can now generate a fully functional starting prison of any size you want. 

For testing purposes the pa-cli has a command line script which when run will spit out a prison file of 100x80. Changing the paramaters to the Prison constructor will allow different prisons to be made beyond the core set of 100x80, 150x120, 200x160. Tests with 80x60, 200x100, 320x240 generated correctly. (Though 320x240 is performance intensive)

Planned changes include terrain randomisation features (Generate Forests, Generate Lakes) and Island Generation for maps such as http://steamcommunity.com/sharedfiles/filedetails/?id=217557027 to be made dynamically.

Eventually this might form the base of a full map editor, but that is a longer term idea.
