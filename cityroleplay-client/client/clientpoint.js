/// <reference types="@altv/types-client" />
/// <reference types="@altv/types-natives" />
import * as alt from 'alt';
import Fingerpointing from 'client/fingerpointing.js';

let pointing = new Fingerpointing();

alt.on('keydown', (key) =>{
    if(key == 'b'.charCodeAt(0)){
        pointing.start();
    }
});

alt.on('keyup', (key) =>  {
    if(key == 'b'.charCodeAt(0))
    {
        pointing.stop();
    }
});