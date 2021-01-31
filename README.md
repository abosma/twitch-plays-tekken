# Twitch Plays Tekken

A Twitch Plays Pokemon clone for the game Tekken 7.

Currently only supports the character Paul.

Built using C# with the package InputSimulatorPlus to simulate move inputs.

## Quick info

Chat commands get split on , or whitespace into an input list. If it has more than 5 inputs, it will be ignored.

Each input first gets checked if it's a special input (think combos, wavedashing, qcf).

If it is, the special input gets split from the rest of the input. The special gets performed, and if it's needed (ex: qcf) the rest of the input gets returned.

If it is not a special, or the remaining input got returned, it will go to the MovePerformer.

The MovePerformer checks if any part of the input is in its dictionary of basic inputs (ex: d, u, b, f). If it is, get a list of virtual keys that need to be performed for that input.

Once it has a list of the keys it needs to perform, it will perform the inputs using the InputSimulator. Once it's done, it will continue to the next input.