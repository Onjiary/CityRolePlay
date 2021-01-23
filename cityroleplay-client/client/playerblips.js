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
const Einkkaufsladen = new alt.PointBlip(-51.204395, -1754.6505, 29.414673);
Einkkaufsladen.sprite = 59;
Einkkaufsladen.color = 43;
Einkkaufsladen.name = "24/7";
Einkkaufsladen.shortRange = 1;

const Einkkaufsladen2 = new alt.PointBlip(28.905497, -1347.0461, 29.482056);
Einkkaufsladen2.sprite = 59;
Einkkaufsladen2.color = 43;
Einkkaufsladen2.name = "24/7";
Einkkaufsladen2.shortRange = 1;

// Kleiderläden:
const Kleiderladen = new alt.PointBlip(125.063736, -216.77802,  54.554565);
Kleiderladen.sprite = 73;
Kleiderladen.color = 47;
Kleiderladen.name = "Kleidungsgeschäft";
Kleiderladen.shortRange = 1;

const Kleiderladen2 = new alt.PointBlip(-819.53406,  -1075.6615,  11.317993);
Kleiderladen2.sprite = 73;
Kleiderladen2.color = 47;
Kleiderladen2.name = "Kleidungsgeschäft";
Kleiderladen2.shortRange = 1;

const WeazelNews = new alt.PointBlip(-599.61755, -930.3956, 23.854248);
WeazelNews.sprite = 590;
WeazelNews.color = 26;
WeazelNews.name = "Weazel News";
WeazelNews.shortRange = 1;

const Fleecabank = new alt.PointBlip(150.07912, -1038.5934, 29.364136);
Fleecabank.sprite = 605;
Fleecabank.color = 2;
Fleecabank.name = "Fleecabank";
Fleecabank.shortRange = 1;

const Zentralbank = new alt.PointBlip(236.33406, 217.04176, 106.28357);
Zentralbank.sprite = 500;
Zentralbank.color = 15;
Zentralbank.name = "Nationalbank Los Santos";
Zentralbank.shortRange = 1;

const Fahrschule = new alt.PointBlip(222.36923, -1394.2682, 30.57727);
Fahrschule.sprite = 595;
Fahrschule.color = 38;
Fahrschule.name = "Los Santos Driving School";
Fahrschule.shortRange = 1;

const Garage = new alt.PointBlip(215.52527, -803.9077, 30.762695);
Garage.sprite = 524;
Garage.color = 77;
Garage.name = "Los Santos Garage";
Garage.shortRange = 1;

const Gefängnis = new alt.PointBlip(1855.9121, 2592, 44.950195);
Gefängnis.sprite = 252;
Gefängnis.color = 1;
Gefängnis.name = "Los Santos Staatprison";
Gefängnis.shortRange = 1;

const Steinmine = new alt.PointBlip(2954.2021, 2781.7583, 39.9458);
Steinmine.sprite = 485;
Steinmine.color = 39;
Steinmine.name = "Steinbruch";
Steinmine.shortRange = 1;

const Kohleberg = new alt.PointBlip(2706, 2826.079, 39.238037);
Kohleberg.sprite = 486;
Kohleberg.color = 39;
Kohleberg.name = "Kohleberg";
Kohleberg.shortRange = 1;

const Mülldeponie = new alt.PointBlip(2354.4, 3133.9648, 47.47766);
Mülldeponie.sprite = 318;
Mülldeponie.color = 44;
Mülldeponie.name = "Müllabfuhr";
Mülldeponie.shortRange = 1;

const Weizenfeld = new alt.PointBlip(2638.4702, 4688.5054, 34.183105);
Weizenfeld.sprite = 85;
Weizenfeld.color = 36;
Weizenfeld.name = "Weizen";
Weizenfeld.shortRange = 1;


alt.on('gameEntityCreate', (entity) =>{
    if(entity.hasStreamSyncedMeta("cityroleplay:teamcolor"))
    {
        let color = entity.getStreamSyncedMeta('cityroleplay:teamcolor');
        let blip = native.getBlipFromEntity(entity.scriptID);
        if(blip === 0) blip = native.addBlipForEntity(entity.scriptID);
        native.setBlipColour(blip, isNaN(color) ? ß : color);
        native.setBlipCategory(blip,7);
        native.showHeadingIndicatorOnBlip(blip, true);
    }
})


alt.on('gameEntityDestroy', (entity) => {
    if(entity.hasStreamSyncedMeta('cityroleplay:teamcolor')){
        let blip = native.getBlipFromEntity(entity.scriptID);
        if(blip !== 0) native.removeBlip(blip);
    }
})

alt.on('streamSyncedMetaChange', (entity, key, value, oldvalue) => {
    if(key === 'cityroleplay:teamcolor'){
        let color = entity.getStreamSyncedMeta("cityroleplay:teamcolor");
        let blip = native.getBlipFromEntity(entity.scriptID);
        if(blip === 0) blip = native.addBlipForEntity(entity.scriptID);
        native.setBlipColour(blip, isNaN(color) ? 0 : color);
        native.setBlipCategory(blip, 7);
        native.showHeadingIndicatorOnBlip(blip, true); 
    }
})