# SharpCut

This is a public repository for recently open-sourced SharpCut v1.x. Keep in mind, the codebase is rather messy as it was never intended to become more complicated than it was in version v1.1 (nor to be seen by anyone).

## Development pre-requisites

1. FFMPEG
    - You need a static build of ffmpeg for SharpCut to run. You can grab it here:
    https://www.gyan.dev/ffmpeg/builds/

    - Place *ffmpeg.exe* and *ffprobe.exe* in the *SharpCutCommon* directory.
2. InnoSetup
    - To build an installer, you need a copy of InnoSetup. You can grab it here: https://jrsoftware.org/isdl.php
3. Development environment
    - SharpCut v1 is written in C# with WinForms and is targetting .NET Framework 4.8.x
    - Grab a copy of *Visual Studio 2022* and make sure you have the *.NET desktop development* workload installed.

## Submitting changes
If you want to submit changes, please try to not diverge too far off the code style established in SharpCut. I don't have any particularly strict rules, but I might ask you to refactor some of your changes when you submit a pull request.

You should branch off the *dev* branch rather than *master*, though.