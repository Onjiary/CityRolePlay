/// <reference types="@altv/types-client" />
/// <reference types="@altv/types-natives" />

import * as alt from 'alt-client';
import * as native from 'natives';

const player = alt.Player.local;

alt.onServer('CityRoleplay:configflags', () => {
    native.setPedConfigFlag(player.scriptID, 241, true) // Disable Stopping Engine
    native.setPedConfigFlag(player.scriptID, 429, true) // Disable Starting Engine
    native.setPedConfigFlag(player.scriptID, 184, true) // Disable Seat Shuffling
})

alt.on('keydown', (key) => {
    if(key === 77){ //m.Key
    let vehicle = player.vehicle;
    if(!vehicle) return;
    vehicle.engineOn = !vehicle.engineOn;
    native.setVehicleEngineOn(vehicle.scriptID, vehicle.engineOn, false, true);
}
})