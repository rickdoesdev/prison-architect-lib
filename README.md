prison-architect-lib
====================

.NET 3.5 Library being built to manipulate the save files for Prison Architect. Currently targeting Alpha16.

Still very basic set of interactions, but as of 27/01/14 it can now generate a fully functional starting prison of any size you want. 

For testing purposes the pa-cli has a command line app included. It will allow different prisons to be made beyond the core set of 100x80, 150x120, 200x160. Tests with 80x60, 200x100, 320x240 generated correctly. (Though 320x240 is performance intensive). It defaults to 100x80 and requires a path to write the file to.


    PaCli.exe  --out "D:\Dropbox\games\Prison Architect\saves\paeditor.prison" -w 200 -h 60
    
This will create 200x60 map in the relavent folder. Prison is set to Day 1, 8 AM.

![](https://raw.github.com/wiki/wolflogic/prison-architect-lib/cli.png)

![](https://raw.github.com/wiki/wolflogic/prison-architect-lib/2014-01-27_00004.jpg)


Planned changes include terrain randomisation features (Generate Forests, Generate Lakes, as well as scattering patches of grass and sand) and Island Generation for maps such as http://steamcommunity.com/sharedfiles/filedetails/?id=217557027 to be made dynamically.


Eventually this might form the base of a full map editor, but that is a long term goal.

If you poke around in the code, you'll see that it's got the ground work to -LOAD- prisons as well, but this is still very WIP. Header block and Cells can be processed, Objects block is fairly complicated due to nested blocks for staff and prisonsers. Some of the later blocks are rather complicated in their nesting as well. This is why I changed focus to initial map generation instead of load/edit/save of existing prisons.

Why have I done this? I was bored. I wanted to learn .NET/C Sharp. I like Prison Architect and have grown a bit weary of hand editing save files.

I take no responsibility if you nuke a prison with this code. It's so pre-alpha it's not even funny! Also, I'm a PHP Developer and this is my first .NET project beyond hello world, so there's bound to be bad practice in this.
