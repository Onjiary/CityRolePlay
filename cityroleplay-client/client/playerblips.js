/// <reference types="@altv/types-client" />
/// <reference types="@altv/types-natives" />

import * as alt from 'alt-client';
import * as native from 'natives';

//const player = alt.Player.local;


const LPSDBLIP = new alt.PointBlip(432.40878, -981.74506, 30.69519);
LPSDBLIP.sprite = 60;
LPSDBLIP.color = 3;
LPSDBLIP.name = "LSPD";
LPSDBLIP.shortRange = 1;


const flughafen = new alt.PointBlip(-1042.4967, -2745.8901, 21.343628);
flughafen.sprite = 572;
flughafen.color = 40;
flughafen.name = "Flughafen";
flughafen.shortRange = 1;

const waffenladen = new alt.PointBlip(18.672527, -1111.266, 29.7854);
waffenladen.sprite = 110;
waffenladen.color = 1;
waffenladen.name = "Waffenladen";
waffenladen.shortRange = 1;

const juwelier = new alt.PointBlip(-628.5231, -235.31868, 38.041748);
juwelier.sprite = 617;
juwelier.color = 46;
juwelier.name = "Juweliergeschäft";
juwelier.shortRange = 1;

//Tankstellen:
const Tankstelle = new alt.PointBlip(-66.92308, -1761.6263, 29.279907);
Tankstelle.sprite = 361;
Tankstelle.color = 81;
Tankstelle.name = "Tankstelle";
Tankstelle.shortRange = 1;

const Tankstelle2 = new alt.PointBlip(269.56482, -1258.5626, 29.128174);
Tankstelle2.sprite = 361;
Tankstelle2.color = 81;
Tankstelle2.name = "Tankstelle";
Tankstelle2.shortRange = 1;

const Autohaus = new alt.PointBlip(-40.65495, -1101.8901, 26.415405);
Autohaus.sprite = 225;
Autohaus.color = 0;
Autohaus.name = "Premium Deluxe Motorsport";
Autohaus.shortRange = 1;

// 24/7 Läden:
// -51.204395, -1754.6505, 29.414673

// 28.905497, -1347.0461, 29.482056

//

//