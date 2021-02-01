/// <reference types="@altv/types-client" />
/// <reference types="@altv/types-natives" />


import * as alt from 'alt-client';
import * as native from 'natives';

let logginView;

alt.on('connectionComplete', () =>{
    alt.log("connectionComplete");
    /*
    logginView = new alt.WebView("http://resource/client/login/index.html");
    logginView.focus();
    alt.showCursor(true);
    alt.toggleGameControls(false);
    native.doScreenFadeOut(0);

    logginView.on('CityRolePlay:login', (name, password) =>{
        alt.emitServer('CityRolePlay:loginAttempt', name, password);
    });

    logginView.on('CityRolePlay:register', (name, password) => {
        alt.emitServer('CityRolePlay:registerAttempt', name, password);
    });
    //*/
})

alt.onServer('CityRolePlay:loginSuccess', () => {
    alt.log("loginSuccess");
    /*
    alt.showCursor(false);
    alt.toggleGameControls(true);
    native.doScreenFadeIn(1000);
    if(logginView) logginView.destroy();
    //*/
})

alt.onServer('CityRolePlay:loginError', (type, msg) => {
    alt.log("loginError");
    if(logginView) logginView.emit('showError', type, msg);
})