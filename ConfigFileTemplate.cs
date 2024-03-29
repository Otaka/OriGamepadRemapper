﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriGamepadRemapper {
    class ConfigFileTemplate {
        public static String CONFIG_TEMPLATE =
@"Controller Button Remapping - remaps controller buttons to different DirectInput button IDs
Only for DirectInput controllers
--------
Activate DirectInput Button Rebinding: true
--------
A: ${A}
B: ${B}
X: ${X}
Y: ${Y}
LShoulder: ${LShoulder}
RShoulder: ${RShoulder}
Select: ${Select}
Start: ${Start}
LStick: ${LStick}
RStick: ${RStick}
LTrigger: ${LTrigger}
RTrigger: ${RTrigger}
--------
Usage:
- There is no guarantee of the game still being playable after button remapping. Please use with caution and delete this file in case of breakage
- Syntactical errors will result in the key rebindings not registering properly, and the button bindings will get set to default
- Only numbers ranging from 1-12 should be used (with the exception of LTrigger and RTrigger)
- Deleting this file will result in this file being recreated by the game, containing the default settings
--------
Don't forget to restart the game after editing this file!
Don't forget to close this file before restarting the game!
--------
To determine the correct button remaps you need, you can look at:
    ""Game Controllers""->your controller->""properties""; and bash buttons until you know your current button IDs.
    Alternatively, you could look up controller test software that does the same.
After you found your controller's button mapping, you can fill them in accordingly, in the above list.
Leave left and right trigger at 13 and 14 to keep them working as controller axes 9 and 10";
    }
}
